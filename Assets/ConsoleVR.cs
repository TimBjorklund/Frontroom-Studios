using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConsoleVR : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI consoleDisplay;
    
    string error = "";
    //TestInputs inputs;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError("");
        Application.logMessageReceived += HandleLog;
        consoleDisplay = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        //inputs = new TestInputs();
        //inputs.Enable();
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        //inputs.Disable();
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {

        if (type == LogType.Error)
        {
            error = error + "\n" + logString;
            consoleDisplay.text = error;
        }
    }

}
