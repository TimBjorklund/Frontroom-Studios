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

    public Transform enemyTransform;
    public AudioSource heartbeatsound;
    public float maxDistance = 10f;

    public float shakeduration;
    public float shakeamount;

    public AudioSource violin;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camerashake>().shakeDuration = shakeduration;
        GetComponent<Camerashake>().shakeAmount = shakeamount;
        GetComponent<Player_Movement>().sprintTime = sprint;
        GetComponent<Player_Movement>().isRunning = isrun;
        FindObjectOfType<Camera>();
        if (postProcessProfile != null)
        {
            // Exempel: Ändra fältdjupens skärpedjup till 0.5
            DepthOfField depthOfField;
            if (postProcessProfile.TryGetSettings(out depthOfField))
            {
                depthOfField.focusDistance.value = 1f;
            }

            // Du kan göra liknande för andra inställningar i profilen
        }
        else
        {
            Debug.LogError("PostProcessProfile är null. Se till att tilldela det i inspektören.");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyTransform == null || heartbeatsound == null)
        {
            Debug.LogError("Player Transform or AudioSource not assigned.");
            return;
        }

        // Beräkna avståndet mellan spelaren och fienden
        float distance = Vector3.Distance(transform.position, enemyTransform.position);

        // Beräkna relativ volym baserat på avståndet
        float relativeVolume = Mathf.Clamp01(1 - distance / maxDistance);

        // Uppdatera ljudvolymen
        heartbeatsound.volume = relativeVolume;

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

            RaycastHit _hit = new RaycastHit();
            if (Physics.Raycast(transform.position, transform.forward, out _hit, 10f))
            {
            if (_hit.transform.tag == "Monster")
            {
                violin.Play();
                shakeamount = 0.2f;
                shakeduration = 3;
            }
            else
            {
                shakeamount = 0.7f;
                shakeduration = 0;
            }

            }



        }
}
