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
            // Sl� av lampan
            targetLight.enabled = false;

            // V�nta en slumpm�ssig tid innan n�sta blinkning
            yield return new WaitForSeconds(Random.Range(minPauseDuration, maxPauseDuration));

            // Sl� p� lampan
            targetLight.enabled = true;

            // V�nta en slumpm�ssig tid f�r blinkningens l�ngd
            yield return new WaitForSeconds(Random.Range(minBlinkDuration, maxBlinkDuration));
        }
    }
}
