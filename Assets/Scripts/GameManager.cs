using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    public static bool playerTurn; //Si es false, es turno del jugador 1 y si es true es turno del jugador 2.(El jugador 1 siempre comienza)
    public GameObject player1;
    public GameObject player2;
    void Update()
    {   
        if (PrefabClick.boolForHorn)
        {}
        else if (playerTurn == false)
        {
            ColliderEditor.DisablePlayerCollider();
            ColliderEditor.EnablePlayerCollider();
        }
        else if (playerTurn)
        {
            ColliderEditor.DisablePlayerCollider();
            ColliderEditor.EnablePlayerCollider();
        }
    }

}
