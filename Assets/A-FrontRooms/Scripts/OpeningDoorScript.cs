using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoorScript : MonoBehaviour
{

    public enum state { Open, Close, None}
   public state currentState = state.None;

    public Transform openGoal;
    public Transform closeGoal;
    float t = 0;

    public bool Openingdoor = false;
    [SerializeField]
    KeyHoleScript keyholescript;

    [SerializeField]
    GameObject Doorholder;

    void OnCollisionEnter(Collision collision)
    {
        if (keyholescript.Unlocked == true)
        { 
            if (collision.gameObject.name == "Left Controller" || collision.gameObject.name == "Right Controller" || collision.gameObject.name == "Test")
            {
              Openingdoor = !Openingdoor;
                if (Openingdoor)
                {
                    currentState = state.Open;
                }
                else
                {
                    currentState = state.Close;
                }
            }
        }
    }

        public void Update()
        {
          if (currentState == state.Open)
          {
            t += Time.deltaTime;
            Doorholder.transform.rotation = Quaternion.Lerp(closeGoal.rotation, openGoal.rotation, t);
            if (t >= 1)
            {
                currentState = state.None;
                t = 0;
           }
        }
        else if (currentState == state.Close)
        {
            t += Time.deltaTime;
            Doorholder.transform.rotation = Quaternion.Lerp(openGoal.rotation, closeGoal.rotation, t);
            if (t >= 1)
            {
                currentState = state.None;
                t = 0;
            }
        }
    }
}
