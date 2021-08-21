using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameBox : MonoBehaviour
{
    public PlayerNameManager manager;
    private TMP_InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
        manager.names.player1Name = "P1";
        manager.names.player2Name = "P2";
    }

    public void SetPlayer1Name()
    {
        manager.names.player1Name = inputField.text;
    }

    public void SetPlayer2Name()
    {
        manager.names.player2Name = inputField.text;
    }
}
