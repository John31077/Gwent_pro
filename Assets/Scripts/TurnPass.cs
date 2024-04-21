using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPass : MonoBehaviour
{
    public void turnPassPlayer1()
    {
        GameObject.Find("Player1").GetComponent<Player>().hasPassTurn = true;
    }
    public void turnPassPlayer2()
    {
        GameObject.Find("Player2").GetComponent<Player>().hasPassTurn = true;
    }
}
