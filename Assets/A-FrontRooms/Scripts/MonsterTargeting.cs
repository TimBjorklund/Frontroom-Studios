using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pathfinding
{
    public class MonsterTargeting : MonoBehaviour
    {
        IAstarAI ai;
        Transform aroundSoundTransform;
        public Transform SoundTransform;
        Transform PlayerLocation;
        bool seenPlayer = false;
        [SerializeField]
        GameObject lookForPlayer;
        bool CheckAroundSoundArea = false;
        float CheckSoundTimer;
        float CheckPlayerAreaTimer;
        [SerializeField]
        GameObject[] PatrollPoints;
        void Start()
        {
            ai.destination = new Vector3(100,0,0);
        }
        void Update()
        {
            lookForPlayer.transform.Rotate(0, 3, 0, Space.Self);
            if (SoundTransform != null && ai != null && CheckAroundSoundArea == false && seenPlayer == false)
            {
                CheckSoundTimer = 0;
                GoToSound();
                CheckAroundSoundArea = true;
            }
            if (CheckAroundSoundArea == true && seenPlayer == false && ai.reachedDestination == true)
            {
                CheckSoundTimer += Time.deltaTime;
                if (CheckSoundTimer >= 60)
                {
                    SoundTransform = null;
                    aroundSoundTransform = null;
                    CheckAroundSoundArea = false;
                }
                else if (ai.reachedDestination == true)
                {
                    SeekSoundArea();
                }
            }
            RaycastHit hit;
            if (Physics.Raycast(gameObject.transform.position, lookForPlayer.transform.forward, out hit, 100))
            {
                if (hit.collider.tag == "Player")
                {
                    CheckPlayerAreaTimer = 0;
                    seenPlayer = true;
                    PlayerLocation = hit.collider.transform;
                    ai.destination = PlayerLocation.position;
                }
            }
            if (seenPlayer == true)
            {
                CheckPlayerAreaTimer += Time.deltaTime;
                if (CheckPlayerAreaTimer >= 60)
                {
                    PlayerLocation = null;
                    seenPlayer = false;
                }
                else if (ai.reachedDestination == true || ai.reachedEndOfPath == true)
                {
                    ai.destination = PlayerLocation.position + new Vector3(Random.Range(10,30), 0, Random.Range(10, 30));
                }
            }
            if (seenPlayer == false && CheckAroundSoundArea == false && (ai.reachedDestination == true || ai.reachedEndOfPath == true))
            {
                int RPP = Random.Range(0, PatrollPoints.Length);
                ai.destination = PatrollPoints[RPP].transform.position;
            }
        }
        public void GoToSound()
        {
            if (SoundTransform != null && ai != null)
            {
                ai.destination = SoundTransform.position;
            }

        }
        private void SeekSoundArea()
        {
            aroundSoundTransform.position = SoundTransform.position + new Vector3(Random.Range(5,20), 0, Random.Range(5,20));
            if (aroundSoundTransform != null && ai != null)
            {
                ai.destination = aroundSoundTransform.position;
            }
        }
    }
}