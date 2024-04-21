using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooleanExtra : MonoBehaviour
{
    public void ChangeTurnForButton()
    {
        GameManager.playerTurn = !GameManager.playerTurn;
    }
    public void ChangeBooleanHorn()
    {
        PrefabClick.boolForHorn = !PrefabClick.boolForHorn;
    }
}
