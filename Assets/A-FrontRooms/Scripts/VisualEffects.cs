using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class VisualEffects : MonoBehaviour
{
    public float stamina;
    public PostProcessProfile postProcessProfile;
    float sprint;
    bool isrun;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Player_Movement>().sprintTime = sprint;
        GetComponent<Player_Movement>().isRunning = isrun;
        FindObjectOfType<Camera>();
        if (postProcessProfile != null)
        {
            // Exempel: �ndra f�ltdjupens sk�rpedjup till 0.5
            DepthOfField depthOfField;
            if (postProcessProfile.TryGetSettings(out depthOfField))
            {
                depthOfField.focusDistance.value = 1f;
            }

            // Du kan g�ra liknande f�r andra inst�llningar i profilen
        }
        else
        {
            Debug.LogError("PostProcessProfile �r null. Se till att tilldela det i inspekt�ren.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        DepthOfField depthOfField;
        if (isrun)
        {
            if (postProcessProfile.TryGetSettings(out depthOfField))
            {

                depthOfField.focalLength.value += 30f * Time.deltaTime;
            }
        }
        if (postProcessProfile.TryGetSettings(out depthOfField))
        {
            if(depthOfField.focalLength > 32)
            {
                depthOfField.focalLength.value -= 10f * Time.deltaTime;    
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {

            if (postProcessProfile.TryGetSettings(out depthOfField))
            {
                depthOfField.aperture.value += 5f;
            }
        }
    }
}
