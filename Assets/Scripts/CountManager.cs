using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountManager : MonoBehaviour 
{
    public GameObject meleeCount1;
    public GameObject rangeCount1;
    public GameObject siegeCount1;
    public GameObject totalCount1;
    public GameObject meleeCount2;
    public GameObject rangeCount2;
    public GameObject siegeCount2;
    public GameObject totalCount2;

    public RealDeck meleeSection1;
    public RealDeck rangeSection1;
    public RealDeck siegeSection1;
    public RealDeck meleeSection2;
    public RealDeck rangeSection2;
    public RealDeck siegeSection2;

    void Update()
    {   
        if (meleeSection1.Real_Cards.Count > 0)
        {
            int attack = 0;
            foreach (GameObject card in meleeSection1.Real_Cards)
            {
                attack += card.GetComponent<PreF_UnitCard>().unit_Card.Power;
                meleeCount1.GetComponent<TextMeshPro>().text = attack.ToString();
            }
        }
        else  meleeCount1.GetComponent<TextMeshPro>().text = "0";
        if (rangeSection1.Real_Cards.Count > 0)
        {
            int attack = 0;
            foreach (GameObject card in rangeSection1.Real_Cards)
            {
                attack += card.GetComponent<PreF_UnitCard>().unit_Card.Power;
                rangeCount1.GetComponent<TextMeshPro>().text = attack.ToString();
            }
        }
        else  rangeCount1.GetComponent<TextMeshPro>().text = "0";
        if (siegeSection1.Real_Cards.Count > 0)
        {
            int attack = 0;
            foreach (GameObject card in siegeSection1.Real_Cards)
            {
                attack += card.GetComponent<PreF_UnitCard>().unit_Card.Power;
                siegeCount1.GetComponent<TextMeshPro>().text = attack.ToString();
            }
        }
        else  siegeCount1.GetComponent<TextMeshPro>().text = "0";
        int totalAttack1 = int.Parse(meleeCount1.GetComponent<TextMeshPro>().text) + int.Parse(rangeCount1.GetComponent<TextMeshPro>().text) + int.Parse(siegeCount1.GetComponent<TextMeshPro>().text);
        totalCount1.GetComponent<TextMeshPro>().text = totalAttack1.ToString();

        if (meleeSection2.Real_Cards.Count > 0)
        {
            int attack = 0;
            foreach (GameObject card in meleeSection2.Real_Cards)
            {
                attack += card.GetComponent<PreF_UnitCard>().unit_Card.Power;
                meleeCount2.GetComponent<TextMeshPro>().text = attack.ToString();
            }
        }
        else  meleeCount2.GetComponent<TextMeshPro>().text = "0";
        if (rangeSection2.Real_Cards.Count > 0)
        {
            int attack = 0;
            foreach (GameObject card in rangeSection2.Real_Cards)
            {
                attack += card.GetComponent<PreF_UnitCard>().unit_Card.Power;
                rangeCount2.GetComponent<TextMeshPro>().text = attack.ToString();
            }
        }
        else  rangeCount2.GetComponent<TextMeshPro>().text = "0";
        if (siegeSection2.Real_Cards.Count > 0)
        {
            int attack = 0;
            foreach (GameObject card in siegeSection2.Real_Cards)
            {
                attack += card.GetComponent<PreF_UnitCard>().unit_Card.Power;
                siegeCount2.GetComponent<TextMeshPro>().text = attack.ToString();
            }
        }
        else  siegeCount2.GetComponent<TextMeshPro>().text = "0";
        int totalAttack2 = int.Parse(meleeCount2.GetComponent<TextMeshPro>().text) + int.Parse(rangeCount2.GetComponent<TextMeshPro>().text) + int.Parse(siegeCount2.GetComponent<TextMeshPro>().text);
        totalCount2.GetComponent<TextMeshPro>().text = totalAttack2.ToString();
    }   
}
