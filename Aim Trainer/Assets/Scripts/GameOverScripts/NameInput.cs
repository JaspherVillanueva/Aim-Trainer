using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NameInput : MonoBehaviour
{
    public InputField playerInput;
    public static string playerName;
    private static int score;

    void Start()
    {
        playerInput = gameObject.GetComponent<InputField>();
        playerInput.onEndEdit.AddListener(updateField);
        
    }

    private void updateField(string arg0)
    {
        playerName = arg0;
        Debug.Log(playerName);
    }
}
