using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLights : MonoBehaviour
{
    public Light targetLight;
    public float minBlinkDuration = 0.01f;
    public float maxBlinkDuration = 0.02f;
    public float minPauseDuration = 0.01f;
    public float maxPauseDuration = 0.02f;

    void Start()
    {
        StartCoroutine(RandomBlink());
    }

    IEnumerator RandomBlink()
    {
        while (true)
        {
            // Slå av lampan
            targetLight.enabled = false;

            // Vänta en slumpmässig tid innan nästa blinkning
            yield return new WaitForSeconds(Random.Range(minPauseDuration, maxPauseDuration));

            // Slå på lampan
            targetLight.enabled = true;

            // Vänta en slumpmässig tid för blinkningens längd
            yield return new WaitForSeconds(Random.Range(minBlinkDuration, maxBlinkDuration));
        }
    }
}
