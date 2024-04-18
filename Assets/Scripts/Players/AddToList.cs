using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddToList : MonoBehaviour
{
    public RealDeck Deck;
    public RealDeck Destination;
    public GameObject parent;
    public Vector3 newPosition;

    public void AddToHand()
    {
        List<GameObject> temp = Deck.Real_Cards.GetRange(0,10);
        Destination.Real_Cards.AddRange(temp);
        Deck.Real_Cards.RemoveRange(0,10);
        foreach (GameObject card in Destination.Real_Cards)
        {
            card.transform.SetParent(parent.transform);
            card.GetComponent<Transform>().position = newPosition;
            newPosition = new Vector3 (card.transform.position.x - 19.69f, card.transform.position.y, 0);
        }
    }

    public void AddToGraveyard()
    {

    }

    public void AddToBuff()
    {

    }

    public void AddToMelee()
    {
        
    }

    public void AddToRange()
    {

    }

    public void AddToSiege()
    {

    }
}
