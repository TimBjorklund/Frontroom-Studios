using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoorScript : MonoBehaviour
{
    private float timer = 0.0f;
    private float nextscripttimer = 0.0f;

    public enum state { Open, Close, None}
   public state currentState = state.None;

    public Transform openGoal;
    public Transform closeGoal;
    float t = 0;

    public bool Openingdoor = false;
    [SerializeField]
    OpeningDoorScript openingDoorScript;
    [SerializeField]
    ClosingDoorScript closingDoorScript;
    [SerializeField]
    KeyHoleScript keyholescript;

    [SerializeField]
    GameObject Doorholder;
    [SerializeField]
    GameObject HandleCombined;

    [SerializeField]
    float xR;
    [SerializeField]
    float yR;
    [SerializeField]
    float zR;

    void OnCollisionEnter(Collision collision)
    {
        if (keyholescript.Unlocked == true)
        { 
            if (collision.gameObject.name == "Left Controller" || collision.gameObject.name == "Right Controller" || collision.gameObject.name == "Test")
            {
               //print("OpeningDoor");
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
    
    private void Start()
    {
        Openingdoor = false;
        GameObject varGameObject = GameObject.Find("HandleCombined");
        if (varGameObject.GetComponent<OpeningDoorScript>().enabled == true)
        {
          //  varGameObject.GetComponent<ClosingDoorScript>().enabled = false;
            //  varGameObject.GetComponent<OpeningDoorScript>().enabled = true;
            // varGameObject.GetComponent<ClosingDoorScript>().enabled = false;
           // Reset();
        }
     
    }
    
  public  void Reset()
    {
        this.enabled = true;
        Openingdoor = true;
        GetComponent<ClosingDoorScript>().enabled = false;
        print("Openingdoor = true");
        print("ClosingDoor = false");
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
            /*
            //print("RotatingOpeningDoor");
            if (Doorholder.transform.rotation.eulerAngles.y < openGoal.transform.rotation.eulerAngles.y) // yr = 90f
            {
                Doorholder.transform.Rotate(xR, 90f * Time.deltaTime, zR); // yR = 90f

            }
            else
            {
                currentState = state.None;
            }*/
           /* timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                Openingdoor = false;
                //print("FinishedRotatingOpeningDoor");
                GetComponent<ClosingDoorScript>().Reset();
                //does not reset the enable for ClosingDoorScript, so when OpeningDoorScript gets enabled it will still have ClosingDoorScript as true from start;
                nextscripttimer += Time.deltaTime;
                if(nextscripttimer >= 1.0f)
                {
                }

               

            }*/


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

        /*    if (Doorholder.transform.rotation.eulerAngles.y < 270) //-90
            {

                Doorholder.transform.Rotate(xR, -90 * Time.deltaTime, zR); //-180.0f
            }
            else
            {
                currentState = state.None;
            }*/
        }
    }
}
