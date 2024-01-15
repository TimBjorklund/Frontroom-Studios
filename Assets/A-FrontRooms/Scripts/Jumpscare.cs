using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject Player;
    public GameObject JumpCam;
    // public AudioSource JumpscareSound;
    private void Start()
    {
       JumpCam.SetActive(false);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("MainCamera"))     //om triggern kolliderar med objectet med detectionTag s� slutar fienden r�ra p� sig
        {
            print("Jumpscare");
            //JumpscareSound.Play();
            JumpCam.SetActive(true);
            Player.SetActive(false);

          
            StartCoroutine(Disableobject());
        }
    }
  IEnumerator Disableobject()
    {
        yield return new WaitForSeconds(2);
        Player.SetActive(true);
        JumpCam.SetActive(false);
    }
}
