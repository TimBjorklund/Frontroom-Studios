using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnThrow : MonoBehaviour
{
    private Pathfinding.MonsterTargeting MT;
    GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        MT = monster.GetComponent<Pathfinding.MonsterTargeting>();
    }
    void OnCollisionEnter(Collision collision)
    {
        Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;
        print(collisionForce);
        if (collisionForce.x >= 200 || collisionForce.y >= 200 || collisionForce.z >= 200)
        {
            MT.SoundTransform = gameObject.transform;
            //Play Sound Here
        }
    }
}
