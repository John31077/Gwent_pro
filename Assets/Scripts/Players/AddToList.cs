using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

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

    public void AddToGraveyardAllCards()
    {

    }

    public void AddToBuff()
    {

    }

    public static void AddToMelee(GameObject cardToTranslate, RealDeck destination, RealDeck origin)
    {
        if (destination.Real_Cards.Contains(cardToTranslate))
        {
            Debug.Log("La carta ya se encuentra en la sección Melee");
        }
        else
        {
            destination.Real_Cards.Add(cardToTranslate);
            origin.Real_Cards.Remove(cardToTranslate);
            Vector3 position1 = new Vector3(-285.799988f,75.5f,0);
            Vector3 position2 = new Vector3(-285.799988f,102.8f,0);
            if (cardToTranslate.transform.IsChildOf(GameObject.Find("Player1").transform))
            {
                cardToTranslate.transform.SetParent(GameObject.Find("MeleeSection1").transform);
                if (destination.Real_Cards.Count == 1)
                {
                    position1 = new Vector3(-285.799988f,75.5f,0);
                    cardToTranslate.GetComponent<Transform>().position = position1;
                }
                else
                {
                    position1 = new Vector3(destination.Real_Cards[destination.Real_Cards.Count-2].GetComponent<Transform>().position.x-15.5709f,position1.y, 0);
                    cardToTranslate.GetComponent<Transform>().position = position1;
                }
            }
            else if (cardToTranslate.transform.IsChildOf(GameObject.Find("Player2").transform))
            {
                cardToTranslate.transform.SetParent(GameObject.Find("MeleeSection2").transform);
                if (destination.Real_Cards.Count == 1)
                {
                    position2 = new Vector3(-285.799988f,102.8f,0);
                    cardToTranslate.GetComponent<Transform>().position = position2;
                }
                else
                {
                    position2 = new Vector3(destination.Real_Cards[destination.Real_Cards.Count-2].GetComponent<Transform>().position.x-15.5709f,position2.y, 0);
                    cardToTranslate.GetComponent<Transform>().position = position2;
                }
            }
        }
    }


    public static void AddToRange(GameObject cardToTranslate, RealDeck destination, RealDeck origin)
    {
        if (destination.Real_Cards.Contains(cardToTranslate))
        {
            Debug.Log("La carta ya se encuentra en la sección Range");
        }
        else
        {
            destination.Real_Cards.Add(cardToTranslate);
            origin.Real_Cards.Remove(cardToTranslate);
            Vector3 position1 = new Vector3(-285.799988f,48.5f,0);
            Vector3 position2 = new Vector3(-285.799988f,128.8f,0);
            if (cardToTranslate.transform.IsChildOf(GameObject.Find("Player1").transform))
            {
                cardToTranslate.transform.SetParent(GameObject.Find("RangeSection1").transform);
                if (destination.Real_Cards.Count == 1)
                {
                    position1 = new Vector3(-285.799988f,48.5f,0);
                    cardToTranslate.GetComponent<Transform>().position = position1;
                }
                else
                {
                    position1 = new Vector3(destination.Real_Cards[destination.Real_Cards.Count-2].GetComponent<Transform>().position.x-15.5709f,position1.y, 0);
                    cardToTranslate.GetComponent<Transform>().position = position1;
                }
            }
            else if (cardToTranslate.transform.IsChildOf(GameObject.Find("Player2").transform))
            {
                cardToTranslate.transform.SetParent(GameObject.Find("RangeSection2").transform);
                if (destination.Real_Cards.Count == 1)
                {
                    position2 = new Vector3(-285.799988f,128.8f,0);
                    cardToTranslate.GetComponent<Transform>().position = position2;
                }
                else
                {
                    position2 = new Vector3(destination.Real_Cards[destination.Real_Cards.Count-2].GetComponent<Transform>().position.x-15.5709f,position2.y, 0);
                    cardToTranslate.GetComponent<Transform>().position = position2;
                }
            }
        }
    }

    public static void AddToSiege(GameObject cardToTranslate, RealDeck destination, RealDeck origin)
    {
        if (destination.Real_Cards.Contains(cardToTranslate))
        {
            Debug.Log("La carta ya se encuentra en la sección Siege");
        }
        else
        {
            destination.Real_Cards.Add(cardToTranslate);
            origin.Real_Cards.Remove(cardToTranslate);
            Vector3 position1 = new Vector3(-285.799988f,22.5f,0);
            Vector3 position2 = new Vector3(-285.799988f,155.8f,0);
            if (cardToTranslate.transform.IsChildOf(GameObject.Find("Player1").transform))
            {
                cardToTranslate.transform.SetParent(GameObject.Find("SiegeSection1").transform);
                if (destination.Real_Cards.Count == 1)
                {
                    position1 = new Vector3(-285.799988f,22.5f,0);
                    cardToTranslate.GetComponent<Transform>().position = position1;
                }
                else
                {
                    position1 = new Vector3(destination.Real_Cards[destination.Real_Cards.Count-2].GetComponent<Transform>().position.x-15.5709f,position1.y, 0);
                    cardToTranslate.GetComponent<Transform>().position = position1;
                }
            }
            else if (cardToTranslate.transform.IsChildOf(GameObject.Find("Player2").transform))
            {
                cardToTranslate.transform.SetParent(GameObject.Find("SiegeSection2").transform);
                if (destination.Real_Cards.Count == 1)
                {
                    position2 = new Vector3(-285.799988f,155.8f,0);
                    cardToTranslate.GetComponent<Transform>().position = position2;
                }
                else
                {
                    position2 = new Vector3(destination.Real_Cards[destination.Real_Cards.Count-2].GetComponent<Transform>().position.x-15.5709f,position2.y, 0);
                    cardToTranslate.GetComponent<Transform>().position = position2;
                }
            }
        }
    }
}
