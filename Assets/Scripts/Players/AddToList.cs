using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddToList : MonoBehaviour
{
    public RealDeck Deck;
    public RealDeck Destination;
    public GameObject parent;
    public GameObject P1_PanelHand;

    public void AddToHand()
    {
        List<GameObject> temp = Deck.Real_Cards.GetRange(0,10);
        Destination.Real_Cards.AddRange(temp);
        Deck.Real_Cards.RemoveRange(0,10);
        foreach (GameObject card in Destination.Real_Cards)
        {
            card.transform.SetParent(P1_PanelHand.transform);
        }
    }
}
