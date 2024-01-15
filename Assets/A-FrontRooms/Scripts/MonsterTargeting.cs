using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pathfinding
{
    public class MonsterTargeting : MonoBehaviour
    {
        IAstarAI ai;
        [SerializeField]
        Transform aroundSoundTransform;
        [SerializeField]
        Transform SoundTransform;
        bool seenPlayer = false;
        [SerializeField]
        Vector3 direction;
        private void Update()
        {/*
            direction.transform.rotation.x 
            RaycastHit hit;
            Debug.DrawRay(gameObject.transform.position, direction.transform.forward, Color.red);
            if (Physics.Raycast(gameObject.transform.position, direction.transform.forward, out hit, 100))
            {
                if (hit.collider.tag == "Player")
                {
                    print("Player in sight at: " + hit.collider.transform.position);
                }
                else
                {
                    print("No Player in sight");
                }
            }*/
            //Ray LineOfSightRaycast = new Ray(gameObject.transform.position, direction);
            if (ai != null && ai.reachedDestination == true && seenPlayer == false)
            {
                SeekSoundArea();
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
        private void SeePlayer() 
        {
            seenPlayer = true;
        }
        private void lastSeenPlayer()
        {

        }
    }
}