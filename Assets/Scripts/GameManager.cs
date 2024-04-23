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



    public GameObject mBuffSection1;
    public GameObject mCount1;
    public GameObject rBuffSection1;
    public GameObject rCount1;
    public GameObject sBuffSection1;
    public GameObject sCount1;
    public GameObject mBuffSection2;
    public GameObject mCount2;
    public GameObject rBuffSection2;
    public GameObject rCount2;
    public GameObject sBuffSection2;
    public GameObject sCount2;


    public GameObject meleeSection1;
    public GameObject meleeSection2;

    public GameObject rangeSection1;
    public GameObject siegeSection1;
    public GameObject rangeSection2;
    public GameObject siegeSection2;

    public GameObject weatherSection;

    
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
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public  void HornEffect(GameObject buffSection, GameObject sectionCount)
    {
        int sectionAttack = 0;
        if (buffSection.transform.IsChildOf(GameObject.Find("MeleeSection1").transform))
        {  
            RealDeck cardList = GameObject.Find("MeleeSection1").GetComponent<RealDeck>();
            foreach (GameObject card in cardList.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType == Level_type.Golden)
                {
                    sectionAttack += card.GetComponent<PreF_UnitCard>().unit_Card.Power;
                }
                else sectionAttack += 2 * card.GetComponent<PreF_UnitCard>().unit_Card.Power;
            }
            sectionCount.GetComponent<TextMeshPro>().text = sectionAttack.ToString();
            int total = int.Parse(mCount1.GetComponent<TextMeshPro>().text) + int.Parse(rCount1.GetComponent<TextMeshPro>().text) + int.Parse(sCount1.GetComponent<TextMeshPro>().text);
            totalCount1.GetComponent<TextMeshPro>().text = total.ToString();
        }
        if (buffSection.transform.IsChildOf(GameObject.Find("RangeSection1").transform))
        {  
            RealDeck cardList = GameObject.Find("RangeSection1").GetComponent<RealDeck>();
            foreach (GameObject card in cardList.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType == Level_type.Golden)
                {
                    sectionAttack += card.GetComponent<PreF_UnitCard>().unit_Card.Power;
                }
                else sectionAttack += 2 * card.GetComponent<PreF_UnitCard>().unit_Card.Power;
            }
            sectionCount.GetComponent<TextMeshPro>().text = sectionAttack.ToString();
            int total = int.Parse(mCount1.GetComponent<TextMeshPro>().text) + int.Parse(rCount1.GetComponent<TextMeshPro>().text) + int.Parse(sCount1.GetComponent<TextMeshPro>().text);
            totalCount1.GetComponent<TextMeshPro>().text = total.ToString();

        }
        if (buffSection.transform.IsChildOf(GameObject.Find("SiegeSection1").transform))
        {  
            RealDeck cardList = GameObject.Find("SiegeSection1").GetComponent<RealDeck>();
            foreach (GameObject card in cardList.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType == Level_type.Golden)
                {
                    sectionAttack += card.GetComponent<PreF_UnitCard>().unit_Card.Power;
                }
                else sectionAttack += 2 * card.GetComponent<PreF_UnitCard>().unit_Card.Power;
            }
            sectionCount.GetComponent<TextMeshPro>().text = sectionAttack.ToString();
            int total = int.Parse(mCount1.GetComponent<TextMeshPro>().text) + int.Parse(rCount1.GetComponent<TextMeshPro>().text) + int.Parse(sCount1.GetComponent<TextMeshPro>().text);
            totalCount1.GetComponent<TextMeshPro>().text = total.ToString();
        }
        if (buffSection.transform.IsChildOf(GameObject.Find("MeleeSection2").transform))
        {  
            RealDeck cardList = GameObject.Find("MeleeSection2").GetComponent<RealDeck>();
            foreach (GameObject card in cardList.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType == Level_type.Golden)
                {
                    sectionAttack += card.GetComponent<PreF_UnitCard>().unit_Card.Power;
                }
                else sectionAttack += 2 * card.GetComponent<PreF_UnitCard>().unit_Card.Power;
            }
            sectionCount.GetComponent<TextMeshPro>().text = sectionAttack.ToString();
            int total = int.Parse(mCount2.GetComponent<TextMeshPro>().text) + int.Parse(rCount2.GetComponent<TextMeshPro>().text) + int.Parse(sCount2.GetComponent<TextMeshPro>().text);
            totalCount2.GetComponent<TextMeshPro>().text = total.ToString();
        }
        if (buffSection.transform.IsChildOf(GameObject.Find("RangeSection2").transform))
        {  
            RealDeck cardList = GameObject.Find("RangeSection2").GetComponent<RealDeck>();
            foreach (GameObject card in cardList.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType == Level_type.Golden)
                {
                    sectionAttack += card.GetComponent<PreF_UnitCard>().unit_Card.Power;
                }
                else sectionAttack += 2 * card.GetComponent<PreF_UnitCard>().unit_Card.Power;
            }
            sectionCount.GetComponent<TextMeshPro>().text = sectionAttack.ToString();
            int total = int.Parse(mCount2.GetComponent<TextMeshPro>().text) + int.Parse(rCount2.GetComponent<TextMeshPro>().text) + int.Parse(sCount2.GetComponent<TextMeshPro>().text);
            totalCount2.GetComponent<TextMeshPro>().text = total.ToString();
        }
        if (buffSection.transform.IsChildOf(GameObject.Find("SiegeSection2").transform))
        {  
            RealDeck cardList = GameObject.Find("SiegeSection2").GetComponent<RealDeck>();
            foreach (GameObject card in cardList.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType == Level_type.Golden)
                {
                    sectionAttack += card.GetComponent<PreF_UnitCard>().unit_Card.Power;
                }
                else sectionAttack += 2 * card.GetComponent<PreF_UnitCard>().unit_Card.Power;
            }
            sectionCount.GetComponent<TextMeshPro>().text = sectionAttack.ToString();
            int total = int.Parse(mCount2.GetComponent<TextMeshPro>().text) + int.Parse(rCount2.GetComponent<TextMeshPro>().text) + int.Parse(sCount2.GetComponent<TextMeshPro>().text);
            totalCount2.GetComponent<TextMeshPro>().text = total.ToString();
        }
    }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void WheatherEffect() //Efecto para los climas distintos de "soleado"
    {
        if (weatherSection.GetComponent<RealDeck>().Real_Cards.Count != 0)
        {
            foreach (GameObject card in weatherSection.GetComponent<RealDeck>().Real_Cards)
            {
                if (card.name == "Escarcha")
                {
                    int attackMelee1 = 0;
                    int attackMelee2 = 0;
                    int count1 = 0;
                    int count2 = 0;
                    foreach (GameObject meleeCard in meleeSection1.GetComponent<RealDeck>().Real_Cards)
                    {
                        if (meleeCard.GetComponent<PreF_UnitCard>().unit_Card.LType == Level_type.Golden)
                        {
                            attackMelee1 += meleeCard.GetComponent<PreF_UnitCard>().unit_Card.Power;
                        }
                        else
                        {
                            count1++;
                        }
                    }
                    attackMelee1 += count1;
                    mCount1.GetComponent<TextMeshPro>().text = attackMelee1.ToString();
                    int total1 = int.Parse(mCount1.GetComponent<TextMeshPro>().text) + int.Parse(rCount1.GetComponent<TextMeshPro>().text) + int.Parse(sCount1.GetComponent<TextMeshPro>().text);
                    totalCount1.GetComponent<TextMeshPro>().text = total1.ToString();

                    foreach (GameObject meleeCard in meleeSection2.GetComponent<RealDeck>().Real_Cards)
                    {
                        if (meleeCard.GetComponent<PreF_UnitCard>().unit_Card.LType == Level_type.Golden)
                        {
                            attackMelee2 += meleeCard.GetComponent<PreF_UnitCard>().unit_Card.Power;
                        }
                        else
                        {
                            count2++;
                        }
                    }
                    attackMelee2 += count2;
                    mCount2.GetComponent<TextMeshPro>().text = attackMelee2.ToString();
                    int total2 = int.Parse(mCount2.GetComponent<TextMeshPro>().text) + int.Parse(rCount2.GetComponent<TextMeshPro>().text) + int.Parse(sCount2.GetComponent<TextMeshPro>().text);
                    totalCount2.GetComponent<TextMeshPro>().text = total2.ToString();

                }
                if (card.name == "Niebla")
                {
                    int attackRange1 = 0;
                    int attackRange2 = 0;
                    int count1 = 0;
                    int count2 = 0;
                    foreach (GameObject rangeCard in rangeSection1.GetComponent<RealDeck>().Real_Cards)
                    {
                        if (rangeCard.GetComponent<PreF_UnitCard>().unit_Card.LType == Level_type.Golden)
                        {
                            attackRange1 += rangeCard.GetComponent<PreF_UnitCard>().unit_Card.Power;
                        }
                        else
                        {
                            count1++;
                        }
                    }
                    attackRange1 += count1;
                    rCount1.GetComponent<TextMeshPro>().text = attackRange1.ToString();
                    int total1 = int.Parse(mCount1.GetComponent<TextMeshPro>().text) + int.Parse(rCount1.GetComponent<TextMeshPro>().text) + int.Parse(sCount1.GetComponent<TextMeshPro>().text);
                    totalCount1.GetComponent<TextMeshPro>().text = total1.ToString();

                    foreach (GameObject rangeCard in rangeSection2.GetComponent<RealDeck>().Real_Cards)
                    {
                        if (rangeCard.GetComponent<PreF_UnitCard>().unit_Card.LType == Level_type.Golden)
                        {
                            attackRange2 += rangeCard.GetComponent<PreF_UnitCard>().unit_Card.Power;
                        }
                        else
                        {
                            count2++;
                        }
                    }
                    attackRange2 += count2;
                    rCount2.GetComponent<TextMeshPro>().text = attackRange2.ToString();
                    int total2 = int.Parse(mCount2.GetComponent<TextMeshPro>().text) + int.Parse(rCount2.GetComponent<TextMeshPro>().text) + int.Parse(sCount2.GetComponent<TextMeshPro>().text);
                    totalCount2.GetComponent<TextMeshPro>().text = total2.ToString();
                }
                if (card.name == "Lluvia")
                {
                    int attackSiege1 = 0;
                    int attackSiege2 = 0;
                    int count1 = 0;
                    int count2 = 0;
                    foreach (GameObject siegeCard in siegeSection1.GetComponent<RealDeck>().Real_Cards)
                    {
                        if (siegeCard.GetComponent<PreF_UnitCard>().unit_Card.LType == Level_type.Golden)
                        {
                            attackSiege1 += siegeCard.GetComponent<PreF_UnitCard>().unit_Card.Power;
                        }
                        else
                        {
                            count1++;
                        }
                    }
                    attackSiege1 += count1;
                    sCount1.GetComponent<TextMeshPro>().text = attackSiege1.ToString();
                    int total1 = int.Parse(mCount1.GetComponent<TextMeshPro>().text) + int.Parse(rCount1.GetComponent<TextMeshPro>().text) + int.Parse(sCount1.GetComponent<TextMeshPro>().text);
                    totalCount1.GetComponent<TextMeshPro>().text = total1.ToString();

                    foreach (GameObject siegeCard in siegeSection2.GetComponent<RealDeck>().Real_Cards)
                    {
                        if (siegeCard.GetComponent<PreF_UnitCard>().unit_Card.LType == Level_type.Golden)
                        {
                            attackSiege2 += siegeCard.GetComponent<PreF_UnitCard>().unit_Card.Power;
                        }
                        else
                        {
                            count2++;
                        }
                    }
                    attackSiege2 += count2;
                    sCount2.GetComponent<TextMeshPro>().text = attackSiege2.ToString();
                    int total2 = int.Parse(mCount2.GetComponent<TextMeshPro>().text) + int.Parse(rCount2.GetComponent<TextMeshPro>().text) + int.Parse(sCount2.GetComponent<TextMeshPro>().text);
                    totalCount2.GetComponent<TextMeshPro>().text = total2.ToString();
                }
            }
        }
    }





























//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Update()
    {
       

        ///////////////////////////////////////////////////////////////////////////////////////
        foreach (GameObject card in siegeSection1.GetComponent<RealDeck>().Real_Cards)
        {
            if (card.name == "General Tulio")
            {
                if (sBuffSection1.GetComponent<HornSection>().hornCard != null)
                {
                    //Se evita que se aplique dos veces el efecto de Horn
                    break;
                }
                else
                {
                    HornEffect(sBuffSection1, sCount1);
                    break;
                }
            }
        }
        foreach (GameObject card in siegeSection2.GetComponent<RealDeck>().Real_Cards)
        {
            if (card.name == "General Tulio")
            {
                if (sBuffSection2.GetComponent<HornSection>().hornCard != null)
                {
                    //Se evita que se aplique dos veces el efecto de Horn
                    break;
                }
                else
                {
                    HornEffect(sBuffSection2, sCount2);
                    break;
                }
            }
        }
        foreach (GameObject card in rangeSection1.GetComponent<RealDeck>().Real_Cards)
        {
            if (card.name == "Dagoth Ur")
            {
                if (rBuffSection1.GetComponent<HornSection>().hornCard != null)
                {
                    //Se evita que se aplique dos veces el efecto de Horn
                    break;
                }
                else
                {
                    HornEffect(rBuffSection1, rCount1);
                    break;
                }
            }
        }
        foreach (GameObject card in rangeSection2.GetComponent<RealDeck>().Real_Cards)
        {
            if (card.name == "Dagoth Ur")
            {
                if (rBuffSection2.GetComponent<HornSection>().hornCard != null)
                {
                    //Se evita que se aplique dos veces el efecto de Horn
                    break;
                }
                else
                {
                    HornEffect(rBuffSection2, rCount2);
                    break;
                }
            }
        }
        if (mBuffSection1.GetComponent<HornSection>().hornCard != null)
        {
            HornEffect(mBuffSection1, mCount1);
        }
        if (rBuffSection1.GetComponent<HornSection>().hornCard != null)
        {
            HornEffect(rBuffSection1, rCount1);
        }
        if (sBuffSection1.GetComponent<HornSection>().hornCard != null)
        {
            HornEffect(sBuffSection1,sCount1);
        }
        if (mBuffSection2.GetComponent<HornSection>().hornCard != null)
        {
            HornEffect(mBuffSection2, mCount2);
        }
        if (rBuffSection2.GetComponent<HornSection>().hornCard != null)
        {
            HornEffect(rBuffSection2, rCount2);
        }
        if (sBuffSection2.GetComponent<HornSection>().hornCard != null)
        {
            HornEffect(sBuffSection2, sCount2);
        }
        /////////////////////////////////////////////////////////////////////////////////////////
        WheatherEffect();
        /////////////////////////////////////////////////////////////////////////////////////////








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
