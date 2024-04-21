using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UIElements;

public class AddToList : MonoBehaviour //Recopilación de métodos que de una forma u otra añaden cartas a determinados lugares
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
    public static void AddToGraveyarBuff(GameObject buffSection)
    {
        if (buffSection.transform.IsChildOf(GameObject.Find("Player1").transform))
        {
            RealDeck graveyard = GameObject.Find("Graveyard1").GetComponent<RealDeck>();
            graveyard.GetComponent<RealDeck>().Real_Cards.Add(buffSection.GetComponent<HornSection>().hornCard);
            buffSection.GetComponent<HornSection>().hornCard.GetComponent<Transform>().SetParent(graveyard.transform);
            buffSection.GetComponent<HornSection>().hornCard.GetComponent<Transform>().position = new Vector3 (-251.8f,67,0);
            buffSection.GetComponent<HornSection>().hornCard = null;
        }
        if (buffSection.transform.IsChildOf(GameObject.Find("Player2").transform))
        {
            RealDeck graveyard = GameObject.Find("Graveyard2").GetComponent<RealDeck>();
            graveyard.GetComponent<RealDeck>().Real_Cards.Add(buffSection.GetComponent<HornSection>().hornCard);
            buffSection.GetComponent<HornSection>().hornCard.GetComponent<Transform>().SetParent(graveyard.transform);
            buffSection.GetComponent<HornSection>().hornCard.GetComponent<Transform>().position = new Vector3 (-251.8f,117.5f,0);
            buffSection.GetComponent<HornSection>().hornCard = null;
        }
    }
    public static void AddToGraveyardOneCards(GameObject cardToSend, RealDeck origin)//ATENCION: NO REMUEVE LA CARTA DE LA LISTA DE ORIGEN
    {
        if (cardToSend.transform.IsChildOf(GameObject.Find("Player1").transform))
        {
            RealDeck graveyard = GameObject.Find("Graveyard1").GetComponent<RealDeck>();
            if (graveyard.Real_Cards.Contains(cardToSend))
            {
                Debug.Log("La carta ya se encuentra en el cementerio");
            }
            else if (origin.Real_Cards.Contains(cardToSend))
            {
                graveyard.GetComponent<RealDeck>().Real_Cards.Add(cardToSend);
                cardToSend.GetComponent<Transform>().SetParent(graveyard.transform);
                cardToSend.GetComponent<Transform>().position = new Vector3 (-251.8f,67,0);
            }
        }
        if (cardToSend.transform.IsChildOf(GameObject.Find("Player2").transform) || cardToSend.GetComponent<Pref_WeatherCard>() != null)
        {
            RealDeck graveyard = GameObject.Find("Graveyard2").GetComponent<RealDeck>();
            if (graveyard.Real_Cards.Contains(cardToSend))
            {
                Debug.Log("La carta ya se encuentra en el cementerio");
            }
            else if (origin.Real_Cards.Contains(cardToSend))
            {
                graveyard.GetComponent<RealDeck>().Real_Cards.Add(cardToSend);
                cardToSend.GetComponent<Transform>().SetParent(graveyard.transform);
                cardToSend.GetComponent<Transform>().position = new Vector3 (-251.8f,117.5f,0);
            }
        }   
    }


    public static void AddToGraveyardAllCards()// no sé si formatear el tablero o solamente limpiar las cartas
    {
        RealDeck meleeSection1 = GameObject.Find("MeleeSection1").GetComponent<RealDeck>();
        GameObject meleeHornSection1 = GameObject.Find("MeleeBuffSection1");

        RealDeck rangeSection1 = GameObject.Find("RangeSection1").GetComponent<RealDeck>();
        GameObject rangeHornSection1 = GameObject.Find("RangeBuffSection1");

        RealDeck siegeSection1 = GameObject.Find("SiegeSection1").GetComponent<RealDeck>();
        GameObject siegeHornSection1 = GameObject.Find("SiegeBuffSection1");

        RealDeck meleeSection2 = GameObject.Find("MeleeSection2").GetComponent<RealDeck>();
        GameObject meleeHornSection2 = GameObject.Find("MeleeBuffSection2");

        RealDeck rangeSection2 = GameObject.Find("RangeSection2").GetComponent<RealDeck>();
        GameObject rangeHornSection2 = GameObject.Find("RangeBuffSection2");

        RealDeck siegeSection2 = GameObject.Find("SiegeSection2").GetComponent<RealDeck>();
        GameObject siegeHornSection2 = GameObject.Find("SiegeBuffSection2");

        RealDeck weatherSectiom = GameObject.Find("WeatherSection").GetComponent<RealDeck>();

        if (meleeHornSection1.GetComponent<HornSection>().hornCard != null)
        AddToGraveyarBuff(meleeHornSection1);
        if (rangeHornSection1.GetComponent<HornSection>().hornCard != null)
        AddToGraveyarBuff(rangeHornSection1);
        if (siegeHornSection1.GetComponent<HornSection>().hornCard != null)
        AddToGraveyarBuff(siegeHornSection1);
        if (meleeHornSection2.GetComponent<HornSection>().hornCard != null)
        AddToGraveyarBuff(meleeHornSection2);
        if (rangeHornSection2.GetComponent<HornSection>().hornCard != null)
        AddToGraveyarBuff(rangeHornSection2);
        if (siegeHornSection2.GetComponent<HornSection>().hornCard != null)
        AddToGraveyarBuff(siegeHornSection2);

        if (meleeSection1.Real_Cards.Count != 0)
        {    
            foreach (GameObject card in meleeSection1.Real_Cards)
            {
                AddToGraveyardOneCards(card, meleeSection1);
            }
            meleeSection1.Real_Cards.Clear();
        }
        if (rangeSection1.Real_Cards.Count != 0)
        {    
            foreach (GameObject card in rangeSection1.Real_Cards)
            {
                AddToGraveyardOneCards(card, rangeSection1);
            }
            rangeSection1.Real_Cards.Clear();
        }
        if (siegeSection1.Real_Cards.Count != 0)
        {    
            foreach (GameObject card in siegeSection1.Real_Cards)
            {
                AddToGraveyardOneCards(card, siegeSection1);
            }
            siegeSection1.Real_Cards.Clear();
        }
        if (meleeSection2.Real_Cards.Count != 0)
        {    
            foreach (GameObject card in meleeSection2.Real_Cards)
            {
                AddToGraveyardOneCards(card, meleeSection2);
            }
            meleeSection2.Real_Cards.Clear();
        }
        if (rangeSection2.Real_Cards.Count != 0)
        {    
            foreach (GameObject card in rangeSection2.Real_Cards)
            {
                AddToGraveyardOneCards(card, rangeSection2);
            }
            rangeSection2.Real_Cards.Clear();
        }
        if (siegeSection2.Real_Cards.Count != 0)
        {    
            foreach (GameObject card in siegeSection2.Real_Cards)
            {
                AddToGraveyardOneCards(card, siegeSection2);
            }
            siegeSection2.Real_Cards.Clear();
        }
        if (weatherSectiom.Real_Cards.Count != 0)
        {    
            foreach (GameObject card in weatherSectiom.Real_Cards)
            {
                AddToGraveyardOneCards(card, weatherSectiom);
            }
            weatherSectiom.Real_Cards.Clear();
        }      
    }
    public static void AddToMelee(GameObject cardToTranslate, RealDeck destination, RealDeck origin)
    {      
        if (destination.Real_Cards.Contains(cardToTranslate))
        {
            //Debug.Log("La carta ya se encuentra en la sección Melee");
            AddToGraveyardAllCards();
        }
        else
        {
            Vector3 position1 = new Vector3(-285.799988f,75.5f,0);
            Vector3 position2 = new Vector3(-285.799988f,102.8f,0);
            destination.Real_Cards.Add(cardToTranslate);
            origin.Real_Cards.Remove(cardToTranslate);
            if (cardToTranslate.transform.IsChildOf(GameObject.Find("Player1").transform))
            {
                cardToTranslate.transform.SetParent(GameObject.Find("MeleeSection1").transform);
                if (destination.Real_Cards.Count == 1)
                {
                    position1 = new Vector3(-285.799988f,75.5f,0);
                    Debug.Log(position1);
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

    public static void AddToWeather(GameObject weatherCard) //Se usa para trabajar con las cartas de clima
    {
        if (weatherCard.GetComponent<Pref_WeatherCard>().weatherCard.Tittle == "Soleado") //Entra si la carta es Soleado
        {
            if (weatherCard.transform.IsChildOf(GameObject.Find("Player1").transform)) //Entra si el prefab es del jugador 1
                {
                    RealDeck hand1 =  GameObject.Find("Hand1").GetComponent<RealDeck>();
                    if (GameObject.Find("Graveyard1").GetComponent<RealDeck>().Real_Cards.Contains(weatherCard))
                    {
                        //Evita que se vuelva a activar el efecto de la carta estando en el cementerio
                        Debug.Log("Se evitó el efecto");
                    }
                    else
                    {
                        //Se envía al cementerio aplicando su efecto (no tiene sentido colocarse en la sección de clima para después al instante quitarla)
                        AddToGraveyardOneCards(weatherCard, hand1);
                        //Aplica el efecto
                        Debug.Log("Se activó el efecto de Soleado");
                        GameObject card = hand1.Real_Cards.Find(x => x == weatherCard);
                        hand1.Real_Cards.Remove(card);
                    }
                }    
                if (weatherCard.transform.IsChildOf(GameObject.Find("Player2").transform)) //Entra si el prefab es del jugador 2
                {
                    RealDeck hand2 =  GameObject.Find("Hand2").GetComponent<RealDeck>();
                    if (GameObject.Find("Graveyard2").GetComponent<RealDeck>().Real_Cards.Contains(weatherCard))
                    {
                        //Evita que se vuelva a activar el efecto de la carta estando en el cementerio
                        Debug.Log("Se evitó el efecto");
                    }
                    else
                    {
                        //Se envía al cementerio aplicando su efecto (no tiene sentido colocarse en la sección de clima para después al instante quitarla)
                        AddToGraveyardOneCards(weatherCard, hand2);
                        //Aplica el efecto
                        Debug.Log("Se activó el efecto de Soleado");
                        GameObject card = hand2.Real_Cards.Find(x => x == weatherCard);
                        hand2.Real_Cards.Remove(card);
                    }
                }
        }
        else //Entra si la carta NO es Soleado (Escarcha,Niebla,Lluvia)
        {
            GameObject weatherSection = GameObject.Find("WeatherSection");
            RealDeck weatherList = weatherSection.GetComponent<RealDeck>();
            RealDeck hand = GameObject.Find("Hand1").GetComponent<RealDeck>(); //No se puede quedar vacío
            if (weatherCard.transform.IsChildOf(GameObject.Find("Player1").transform))
            {
                //hand se mantiene con el valor anterior
            }
            else if (weatherCard.transform.IsChildOf(GameObject.Find("Player2").transform))
            {
                hand = GameObject.Find("Hand2").GetComponent<RealDeck>();
            }
            foreach (GameObject wCard in weatherList.Real_Cards)
            {
                if (wCard.GetComponent<Pref_WeatherCard>().weatherCard.Tittle == weatherCard.GetComponent<Pref_WeatherCard>().weatherCard.Tittle)
                {
                    if (weatherCard.transform.IsChildOf(GameObject.Find("Player1").transform))
                    {
                        AddToGraveyardOneCards(weatherCard, GameObject.Find("Hand1").GetComponent<RealDeck>());
                        GameObject.Find("Hand1").GetComponent<RealDeck>().Real_Cards.Remove(weatherCard);
                        return;
                    }
                    if (weatherCard.transform.IsChildOf(GameObject.Find("Player2").transform))
                    {
                        AddToGraveyardOneCards(weatherCard, GameObject.Find("Hand2").GetComponent<RealDeck>());
                        GameObject.Find("Hand2").GetComponent<RealDeck>().Real_Cards.Remove(weatherCard);
                        return;
                    }
                }
            }
            weatherList.Real_Cards.Add(weatherCard);
            hand.Real_Cards.Remove(weatherCard);
            Vector3 position = new Vector3(-518f,87.5f,0);
            weatherCard.transform.SetParent(GameObject.Find("WeatherSection").transform);
            if (weatherList.Real_Cards.Count == 1)
            {
                position = new Vector3(-518f,87.5f,0);
                weatherCard.GetComponent<Transform>().position = position;
            }
            else
            {
                position = new Vector3(weatherList.Real_Cards[weatherList.Real_Cards.Count-2].GetComponent<Transform>().position.x-15.5709f,position.y, 0);
                weatherCard.GetComponent<Transform>().position = position;
            }
        }
    }
}
