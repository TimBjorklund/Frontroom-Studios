using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerDeath : MonoBehaviour
{
    public Camera playercam;
    public Camerashake Camerashake;
    public PostProcessProfile postProcessProfile;
    public ChromaticAberration chromaticAberration;
    public LensDistortion lensDistortion;
    public AutoExposure autoExposure;
    public ColorGrading colorGrading;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        Camerashake.shakeDuration = 0;
        if (postProcessProfile != null)
        {
            // Exempel: Ändra fältdjupens skärpedjup till 0.5
            if (postProcessProfile.TryGetSettings(out chromaticAberration))
            {
                chromaticAberration.intensity.value = 0f;
            }
            if (postProcessProfile.TryGetSettings(out lensDistortion))
            {
                lensDistortion.intensity.value = 0f;
            }
            if (postProcessProfile.TryGetSettings(out autoExposure))
            {
                autoExposure.keyValue.value = 1;
            }
            if (postProcessProfile.TryGetSettings(out colorGrading))
            {
                colorGrading.contrast.value = 0;
                colorGrading.postExposure.value = 0;
            }

        }
    }
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            die();
        }
        if (Camerashake.shakeDuration >= 0.1f && Camerashake.shakeDuration <= 0.2f)
        {

            Destroy(gameObject);
           
        }
    }
    public void die()
    {
        audioSource.Play();
        Camerashake.shakeDuration = 3;
        Camerashake.shakeAmount = 0.4f;

        if (postProcessProfile != null)
        {
            // Exempel: Ändra fältdjupens skärpedjup till 0.5
            if (postProcessProfile.TryGetSettings(out chromaticAberration))
            {
                chromaticAberration.intensity.value = 1f;
            }
            if(postProcessProfile.TryGetSettings(out lensDistortion))
            {
                lensDistortion.intensity.value = -34f;
            }
            if(postProcessProfile.TryGetSettings(out autoExposure))
            {
                autoExposure.keyValue.value = 10;
            }
            if(postProcessProfile.TryGetSettings(out colorGrading))
            {
                colorGrading.contrast.value = 50;
            }

        }
        StartCoroutine(Blink());



    }
    IEnumerator Blink()
    {
        while (true)
        {
            print("sug");
            if (postProcessProfile.TryGetSettings(out colorGrading))
            {
                colorGrading.postExposure.value = 0f;
            }

            yield return new WaitForSeconds(0.01f);
            if (postProcessProfile.TryGetSettings(out colorGrading))
            {
                colorGrading.postExposure.value = 5f;
            }

            yield return new WaitForSeconds(0.01f);
        }
    }
}
