using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool playerTurn; //Si es false, es turno del jugador 1 y si es true es turno del jugador 2.(El jugador 1 siempre comienza)
    public GameObject player1;
    public GameObject totalCount1;
    public GameObject player1LifeGem1;
    public GameObject player1LifeGem2;
    public RealDeck hand1;
    public GameObject player2;
    public GameObject totalCount2;
    public GameObject player2LifeGem1;
    public GameObject player2LifeGem2;
    public RealDeck hand2;
    public Sprite lightGem;
    public Sprite darkGem;
    public void MyUpdate()
    {
        AddToList.AddToGraveyardAllCards();
        player1.GetComponent<Player>().hasPlayed = false;
        player1.GetComponent<Player>().hasPassTurn = false;
        player2.GetComponent<Player>().hasPlayed = false;
        player2.GetComponent<Player>().hasPassTurn = false;
        ColliderEditor.DisablePlayerCollider();
        ColliderEditor.EnablePlayerCollider();
    }




    void Update()
    {   
        if (player1.GetComponent<Player>().life2 == false && player2.GetComponent<Player>().life2 == false)
        {
            ColliderEditor.StaticDisableAllColliders();
            Debug.Log("Empate");
        }
        else if (player1.GetComponent<Player>().life2 == false && player2.GetComponent<Player>().life2)
        {
            ColliderEditor.StaticDisableAllColliders();
            Debug.Log("Ganó el jugador 2");
        }
        else if (player1.GetComponent<Player>().life2 && player2.GetComponent<Player>().life2 == false)
        {
            ColliderEditor.StaticDisableAllColliders();
            Debug.Log("Ganó el jugador 1");
        }




        else if (player1.GetComponent<Player>().hasPassTurn && player2.GetComponent<Player>().hasPassTurn)
        {
            Debug.Log("Se acabó la ronda");
            ColliderEditor.StaticDisableAllColliders();
            int count1 = int.Parse(totalCount1.GetComponent<TextMeshPro>().text);
            int count2 = int.Parse(totalCount2.GetComponent<TextMeshPro>().text);
            if (count1 > count2)
            {
                if (player2.GetComponent<Player>().life1 == false)
                {
                    player2.GetComponent<Player>().life2 = false;
                    player2LifeGem2.GetComponent<SpriteRenderer>().sprite = darkGem;
                    AddToList.AddToHand2Cards();
                    playerTurn = false;
                    MyUpdate();
                }
                else
                {
                    player2.GetComponent<Player>().life1 = false;
                    player2LifeGem1.GetComponent<SpriteRenderer>().sprite = darkGem;
                    AddToList.AddToHand2Cards();
                    playerTurn = false;
                    MyUpdate();
                }
            }
            else if (count1 < count2)
            {
                if (player1.GetComponent<Player>().life1 == false)
                {
                    player1.GetComponent<Player>().life2 = false;
                    player1LifeGem2.GetComponent<SpriteRenderer>().sprite = darkGem;
                    AddToList.AddToHand2Cards();
                    playerTurn = true;
                    MyUpdate();
                }
                else
                {
                    player1.GetComponent<Player>().life1 = false;
                    player1LifeGem1.GetComponent<SpriteRenderer>().sprite = darkGem;
                    AddToList.AddToHand2Cards();
                    playerTurn = true;
                    MyUpdate();
                }
            }
            else if (count1 == count2)
            {
                if (player1.GetComponent<Player>().life1 && player2.GetComponent<Player>().life1)
                {
                    player1.GetComponent<Player>().life1 = false;
                    player1LifeGem1.GetComponent<SpriteRenderer>().sprite = darkGem;
                    player2.GetComponent<Player>().life1 = false;
                    player2LifeGem1.GetComponent<SpriteRenderer>().sprite = darkGem;
                    AddToList.AddToHand2Cards();
                    MyUpdate();
                }
                else if (player1.GetComponent<Player>().life1 == false && player2.GetComponent<Player>().life1 == false)
                {
                    player1.GetComponent<Player>().life2 = false;
                    player1LifeGem2.GetComponent<SpriteRenderer>().sprite = darkGem;
                    player2.GetComponent<Player>().life2 = false;
                    player2LifeGem2.GetComponent<SpriteRenderer>().sprite = darkGem;
                    AddToList.AddToHand2Cards();
                    MyUpdate();
                }
                else if (player1.GetComponent<Player>().life1 && player2.GetComponent<Player>().life1 == false)
                {
                    player1.GetComponent<Player>().life1 = false;
                    player1LifeGem1.GetComponent<SpriteRenderer>().sprite = darkGem;
                    player2.GetComponent<Player>().life2 = false;
                    player2LifeGem2.GetComponent<SpriteRenderer>().sprite = darkGem;
                    AddToList.AddToHand2Cards();
                    MyUpdate();
                }
                else if (player1.GetComponent<Player>().life1 == false && player2.GetComponent<Player>().life1)
                {
                    player1.GetComponent<Player>().life2 = false;
                    player1LifeGem2.GetComponent<SpriteRenderer>().sprite = darkGem;
                    player2.GetComponent<Player>().life1 = false;
                    player2LifeGem1.GetComponent<SpriteRenderer>().sprite = darkGem;
                    AddToList.AddToHand2Cards();
                    MyUpdate();
                }
            }

        }
        else if (PrefabClick.boolForHorn)
        {}
        else if (playerTurn == false && ColliderEditor.colliderSupport == false)
        {
            if (player1.GetComponent<Player>().hasPassTurn)
            {
                playerTurn = true;
            }
            else
            {
                ColliderEditor.DisablePlayerCollider();
                ColliderEditor.EnablePlayerCollider();
            }
        }
        else if (playerTurn && ColliderEditor.colliderSupport == false)
        {
            if (player2.GetComponent<Player>().hasPassTurn)
            {
                playerTurn = false;
            }
            else
            {
                ColliderEditor.DisablePlayerCollider();
                ColliderEditor.EnablePlayerCollider();
            }
        }


        if (hand1.Real_Cards.Count > 0 && hand2.Real_Cards.Count > 0)
        {
            if (hand1.Real_Cards.Count > 10)
            {
                AddToList.AddToGraveyardOneCards(hand1.Real_Cards[hand1.Real_Cards.Count-1], hand1);
                hand1.Real_Cards.Remove(hand1.Real_Cards[hand1.Real_Cards.Count-1]);
            }
            if (hand2.Real_Cards.Count > 10)
            {
                AddToList.AddToGraveyardOneCards(hand2.Real_Cards[hand2.Real_Cards.Count-1], hand2);
                hand2.Real_Cards.Remove(hand2.Real_Cards[hand2.Real_Cards.Count-1]);
            }
        }
    }

}
