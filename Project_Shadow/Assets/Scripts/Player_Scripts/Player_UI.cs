using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_UI : MonoBehaviour
{
    [SerializeField] private TMP_Text promptMessage;

    private void Start()
    {
        Cursor.visible = false;
    }

    public void UpdatePromptMessage(string message)
    {
        promptMessage.text = message;
    }
}
