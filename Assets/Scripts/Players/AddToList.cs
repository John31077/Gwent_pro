using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UIElements;

public class AddToList : MonoBehaviour //Recopilación de métodos que de una forma u otra añaden cartas a determinados lugares. También contiene algunos efectos de cartas.
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
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static void AddToHand2Cards()
    {
        List<GameObject> deck1 = GameObject.Find("Deck_Real1").GetComponent<RealDeck>().Real_Cards;
        List<GameObject> hand1 = GameObject.Find("Hand1").GetComponent<RealDeck>().Real_Cards;
        Vector3 position1 = new Vector3(-274.299988f,-4.5999999f,0);
        List<GameObject> temp1 = deck1.GetRange(0,2);
        hand1.AddRange(temp1);
        deck1.RemoveRange(0,2);
        foreach (GameObject card in hand1)
        {
            card.transform.SetParent(GameObject.Find("Hand1").transform);
            card.GetComponent<Transform>().position = position1;
            position1 = new Vector3 (card.transform.position.x - 19.69f, card.transform.position.y, 0);
        }

        List<GameObject> deck2 = GameObject.Find("Deck_Real2").GetComponent<RealDeck>().Real_Cards;
        List<GameObject> hand2 = GameObject.Find("Hand2").GetComponent<RealDeck>().Real_Cards;
        Vector3 position2 = new Vector3(-274.299988f,180.289993f,0);
        List<GameObject> temp2 = deck2.GetRange(0,2);
        hand2.AddRange(temp2);
        deck2.RemoveRange(0,2);
        foreach (GameObject card in hand2)
        {
            card.transform.SetParent(GameObject.Find("Hand2").transform);
            card.GetComponent<Transform>().position = position2;
            position2 = new Vector3 (card.transform.position.x - 19.69f, card.transform.position.y, 0);
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static void AddOneCardEffect(GameObject effectCard)
    {
        if (effectCard.transform.IsChildOf(GameObject.Find("Player1").transform))
        {
            List<GameObject> deck1 = GameObject.Find("Deck_Real1").GetComponent<RealDeck>().Real_Cards;
            List<GameObject> hand1 = GameObject.Find("Hand1").GetComponent<RealDeck>().Real_Cards;
            Vector3 position1 = new Vector3(-274.299988f,-4.5999999f,0);
            List<GameObject> temp1 = deck1.GetRange(0,1);
            hand1.AddRange(temp1);
            deck1.RemoveRange(0,1);
            foreach (GameObject card in hand1)
            {
                card.transform.SetParent(GameObject.Find("Hand1").transform);
                card.GetComponent<Transform>().position = position1;
                position1 = new Vector3 (card.transform.position.x - 19.69f, card.transform.position.y, 0);
            }
        }
        if (effectCard.transform.IsChildOf(GameObject.Find("Player2").transform))
        {
            List<GameObject> deck2 = GameObject.Find("Deck_Real2").GetComponent<RealDeck>().Real_Cards;
            List<GameObject> hand2 = GameObject.Find("Hand2").GetComponent<RealDeck>().Real_Cards;
            Vector3 position2 = new Vector3(-274.299988f,180.289993f,0);
            List<GameObject> temp2 = deck2.GetRange(0,1);
            hand2.AddRange(temp2);
            deck2.RemoveRange(0,1);
            foreach (GameObject card in hand2)
            {
                card.transform.SetParent(GameObject.Find("Hand2").transform);
                card.GetComponent<Transform>().position = position2;
                position2 = new Vector3 (card.transform.position.x - 19.69f, card.transform.position.y, 0);
            }
        }
    }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    public static void SwitchCard(GameObject switchCard)
    {
        if (switchCard.transform.IsChildOf(GameObject.Find("Player1").transform))
        {
            RealDeck deck = GameObject.Find("Deck_Real1").GetComponent<RealDeck>();// se busca el deck del jugador
            RealDeck hand = GameObject.Find("Hand1").GetComponent<RealDeck>();// se busca la mano del jugador
            Vector3 cardPosition = switchCard.GetComponent<Transform>().position; //se guarda la posicion de la carta en la mano
            Vector3 deckPosition = deck.Real_Cards[0].GetComponent<Transform>().position; // se guarda la posicion del deck
            deck.Real_Cards[0].GetComponent<Transform>().position = cardPosition; // se cambia la posicion de la carta del deck por la de la mano
            hand.Real_Cards.Add(deck.Real_Cards[0]); //se añade a la mano la carta del deck
            deck.Real_Cards[0].transform.SetParent(GameObject.Find("Hand1").transform); // la carta del deck se vuelve hijo de la mano
            deck.Real_Cards.RemoveAt(0); //se elimina la carta que estaba en el deck, del deck

            deck.Real_Cards.Add(switchCard); //se añade al deck la carta a cambiar
            switchCard.GetComponent<Transform>().position = deckPosition;//se cambia la coordenada de la carta a cambiar por la del deck
            switchCard.transform.SetParent(GameObject.Find("Deck_Real1").transform); //la carta a cambiar se hace hijo del deck
            hand.Real_Cards.Remove(switchCard); //se elimina la carta de la mano

            ShuffleScript.Shuffle<GameObject>(deck.Real_Cards);
            return;
        }
        if (switchCard.transform.IsChildOf(GameObject.Find("Player2").transform))
        {
            RealDeck deck = GameObject.Find("Deck_Real2").GetComponent<RealDeck>();// se busca el deck del jugador
            RealDeck hand = GameObject.Find("Hand2").GetComponent<RealDeck>();// se busca la mano del jugador
            Vector3 cardPosition = switchCard.GetComponent<Transform>().position; //se guarda la posicion de la carta en la mano
            Vector3 deckPosition = deck.Real_Cards[0].GetComponent<Transform>().position; // se guarda la posicion del deck
            deck.Real_Cards[0].GetComponent<Transform>().position = cardPosition; // se cambia la posicion de la carta del deck por la de la mano
            hand.Real_Cards.Add(deck.Real_Cards[0]); //se añade a la mano la carta del deck
            deck.Real_Cards[0].transform.SetParent(GameObject.Find("Hand2").transform); // la carta del deck se vuelve hijo de la mano
            deck.Real_Cards.RemoveAt(0); //se elimina la carta que estaba en el deck, del deck

            deck.Real_Cards.Add(switchCard); //se añade al deck la carta a cambiar
            switchCard.GetComponent<Transform>().position = deckPosition;//se cambia la coordenada de la carta a cambiar por la del deck
            switchCard.transform.SetParent(GameObject.Find("Deck_Real2").transform); //la carta a cambiar se hace hijo del deck
            hand.Real_Cards.Remove(switchCard); //se elimina la carta de la mano

            ShuffleScript.Shuffle<GameObject>(deck.Real_Cards);
            return;
        }
    }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
            if (GameObject.Find("Player1").GetComponent<Player>().SeñueloActivate)
            {
                SeñueloEffect2(cardToTranslate, GameObject.Find("MeleeSection1"), GameObject.Find("Hand1"));
            }
            else if (GameObject.Find("Player2").GetComponent<Player>().SeñueloActivate)
            {
                SeñueloEffect2(cardToTranslate, GameObject.Find("MeleeSection2"), GameObject.Find("Hand2"));
            }
            else
            return;
        }
        else
        {
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Burn)
            {
                Burn();
            }
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.little_Burn)
            {
                LittleBurn(cardToTranslate);
            }
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Steal)
            {
                AddOneCardEffect(cardToTranslate);
            }
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Clear)
            {
                ClearSectionWithMinTroops();
            }
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Average)
            {
                AverageEffect();
            }
            
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
                    cardToTranslate.GetComponent<Transform>().position = position1;
                    GameManager.playerTurn = !GameManager.playerTurn;
                }
                else
                {
                    position1 = new Vector3(destination.Real_Cards[destination.Real_Cards.Count-2].GetComponent<Transform>().position.x-15.5709f,position1.y, 0);
                    cardToTranslate.GetComponent<Transform>().position = position1;
                    GameManager.playerTurn = !GameManager.playerTurn;
                }

                if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Companion)
                {
                    Debug.Log("Sé identificó como companion");
                    CompanionEffect(cardToTranslate, GameObject.Find("MeleeSection1"));
                }






            }
            else if (cardToTranslate.transform.IsChildOf(GameObject.Find("Player2").transform))
            {
                cardToTranslate.transform.SetParent(GameObject.Find("MeleeSection2").transform);
                if (destination.Real_Cards.Count == 1)
                {
                    position2 = new Vector3(-285.799988f,102.8f,0);
                    cardToTranslate.GetComponent<Transform>().position = position2;
                    GameManager.playerTurn = !GameManager.playerTurn;
                }
                else
                {
                    position2 = new Vector3(destination.Real_Cards[destination.Real_Cards.Count-2].GetComponent<Transform>().position.x-15.5709f,position2.y, 0);
                    cardToTranslate.GetComponent<Transform>().position = position2;
                    GameManager.playerTurn = !GameManager.playerTurn;
                }


                if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Companion)
                {
                    Debug.Log("Sé identificó como companion");
                    CompanionEffect(cardToTranslate, GameObject.Find("MeleeSection2"));
                }


            }
        }
    }
    public static void AddToRange(GameObject cardToTranslate, RealDeck destination, RealDeck origin)
    {
        if (destination.Real_Cards.Contains(cardToTranslate))
        {
            if (GameObject.Find("Player1").GetComponent<Player>().SeñueloActivate)
            {
                SeñueloEffect2(cardToTranslate, GameObject.Find("RangeSection1"), GameObject.Find("Hand1"));
            }
            else if (GameObject.Find("Player2").GetComponent<Player>().SeñueloActivate)
            {
                SeñueloEffect2(cardToTranslate, GameObject.Find("RangeSection2"), GameObject.Find("Hand2"));
            }
            else
            return;
        }
        else
        {
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Burn)
            {
                Burn();
            }
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.little_Burn)
            {

                LittleBurn(cardToTranslate);
            }
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Steal)
            {
                AddOneCardEffect(cardToTranslate);
            }
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Clear)
            {
                ClearSectionWithMinTroops();
            }
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Average)
            {
                AverageEffect();
            }
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
                    GameManager.playerTurn = !GameManager.playerTurn;
                }
                else
                {
                    position1 = new Vector3(destination.Real_Cards[destination.Real_Cards.Count-2].GetComponent<Transform>().position.x-15.5709f,position1.y, 0);
                    cardToTranslate.GetComponent<Transform>().position = position1;
                    GameManager.playerTurn = !GameManager.playerTurn;
                }


                if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Companion)
                {
                    Debug.Log("Sé identificó como companion");
                    CompanionEffect(cardToTranslate, GameObject.Find("RangeSection1"));
                }



            }
            else if (cardToTranslate.transform.IsChildOf(GameObject.Find("Player2").transform))
            {
                cardToTranslate.transform.SetParent(GameObject.Find("RangeSection2").transform);
                if (destination.Real_Cards.Count == 1)
                {
                    position2 = new Vector3(-285.799988f,128.8f,0);
                    cardToTranslate.GetComponent<Transform>().position = position2;
                    GameManager.playerTurn = !GameManager.playerTurn;
                }
                else
                {
                    position2 = new Vector3(destination.Real_Cards[destination.Real_Cards.Count-2].GetComponent<Transform>().position.x-15.5709f,position2.y, 0);
                    cardToTranslate.GetComponent<Transform>().position = position2;
                    GameManager.playerTurn = !GameManager.playerTurn;
                }


                if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Companion)
                {
                    Debug.Log("Sé identificó como companion");
                    CompanionEffect(cardToTranslate, GameObject.Find("RangeSection2"));
                }



            }
        }
    }
    public static void AddToSiege(GameObject cardToTranslate, RealDeck destination, RealDeck origin)
    {
        if (destination.Real_Cards.Contains(cardToTranslate))
        {
            if (GameObject.Find("Player1").GetComponent<Player>().SeñueloActivate)
            {
                SeñueloEffect2(cardToTranslate, GameObject.Find("SiegeSection1"), GameObject.Find("Hand1"));
            }
            else if (GameObject.Find("Player2").GetComponent<Player>().SeñueloActivate)
            {
                SeñueloEffect2(cardToTranslate, GameObject.Find("SiegeSection2"), GameObject.Find("Hand2"));
            }
            else
            return;
        }
        else
        {
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Burn)
            {
                Burn();
            }
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.little_Burn)
            {
                LittleBurn(cardToTranslate);
            }
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Steal)
            {
                AddOneCardEffect(cardToTranslate);
            }
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Clear)
            {
                ClearSectionWithMinTroops();
            }
            if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Average)
            {
                AverageEffect();
            }
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
                    GameManager.playerTurn = !GameManager.playerTurn;
                }
                else
                {
                    position1 = new Vector3(destination.Real_Cards[destination.Real_Cards.Count-2].GetComponent<Transform>().position.x-15.5709f,position1.y, 0);
                    cardToTranslate.GetComponent<Transform>().position = position1;
                    GameManager.playerTurn = !GameManager.playerTurn;
                }

                if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Companion)
                {
                    Debug.Log("Sé identificó como companion");
                    CompanionEffect(cardToTranslate, GameObject.Find("SiegeSection1"));
                }



            }
            else if (cardToTranslate.transform.IsChildOf(GameObject.Find("Player2").transform))
            {
                cardToTranslate.transform.SetParent(GameObject.Find("SiegeSection2").transform);
                if (destination.Real_Cards.Count == 1)
                {
                    position2 = new Vector3(-285.799988f,155.8f,0);
                    cardToTranslate.GetComponent<Transform>().position = position2;
                    GameManager.playerTurn = !GameManager.playerTurn;
                }
                else
                {
                    position2 = new Vector3(destination.Real_Cards[destination.Real_Cards.Count-2].GetComponent<Transform>().position.x-15.5709f,position2.y, 0);
                    cardToTranslate.GetComponent<Transform>().position = position2;
                    GameManager.playerTurn = !GameManager.playerTurn;
                }


                if (cardToTranslate.GetComponent<PreF_UnitCard>().unit_Card.Efect == eEfect.Companion)
                {
                    Debug.Log("Sé identificó como companion");
                    CompanionEffect(cardToTranslate, GameObject.Find("SiegeSection2"));
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
                        return;
                    }
                    else
                    {
                        //Se envía al cementerio aplicando su efecto (no tiene sentido colocarse en la sección de clima para después al instante quitarla)
                        AddToGraveyardOneCards(weatherCard, hand1);
                        //Aplica el efecto
                        SunnyEffect();
                        GameObject card = hand1.Real_Cards.Find(x => x == weatherCard);
                        hand1.Real_Cards.Remove(card);
                        GameManager.playerTurn = !GameManager.playerTurn;
                    }
                }    
                if (weatherCard.transform.IsChildOf(GameObject.Find("Player2").transform)) //Entra si el prefab es del jugador 2
                {
                    RealDeck hand2 =  GameObject.Find("Hand2").GetComponent<RealDeck>();
                    if (GameObject.Find("Graveyard2").GetComponent<RealDeck>().Real_Cards.Contains(weatherCard))
                    {
                        //Evita que se vuelva a activar el efecto de la carta estando en el cementerio
                        return;
                    }
                    else
                    {
                        //Se envía al cementerio aplicando su efecto (no tiene sentido colocarse en la sección de clima para después al instante quitarla)
                        AddToGraveyardOneCards(weatherCard, hand2);
                        //Aplica el efecto
                        SunnyEffect();
                        GameObject card = hand2.Real_Cards.Find(x => x == weatherCard);
                        hand2.Real_Cards.Remove(card);
                        GameManager.playerTurn = !GameManager.playerTurn;
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
                        GameManager.playerTurn = !GameManager.playerTurn;
                        return;
                    }
                    if (weatherCard.transform.IsChildOf(GameObject.Find("Player2").transform))
                    {
                        AddToGraveyardOneCards(weatherCard, GameObject.Find("Hand2").GetComponent<RealDeck>());
                        GameObject.Find("Hand2").GetComponent<RealDeck>().Real_Cards.Remove(weatherCard);
                        GameManager.playerTurn = !GameManager.playerTurn;
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
                GameManager.playerTurn = !GameManager.playerTurn;
            }
            else
            {
                position = new Vector3(weatherList.Real_Cards[weatherList.Real_Cards.Count-2].GetComponent<Transform>().position.x-15.5709f,position.y, 0);
                weatherCard.GetComponent<Transform>().position = position;
                GameManager.playerTurn = !GameManager.playerTurn;
            }
        }
    }

    public static void SunnyEffect()
    {
        RealDeck weatherSection = GameObject.Find("WeatherSection").GetComponent<RealDeck>();
        if (weatherSection.Real_Cards.Count != 0)
        {

            foreach (GameObject weatherCard in weatherSection.Real_Cards)
            {
                AddToGraveyardOneCards(weatherCard, weatherSection);
            }
            weatherSection.Real_Cards.Clear();
        }
    }

    public static void Burn()
    {
        RealDeck mSection1 = GameObject.Find("MeleeSection1").GetComponent<RealDeck>();
        RealDeck rSection1 = GameObject.Find("RangeSection1").GetComponent<RealDeck>();
        RealDeck sSection1 = GameObject.Find("SiegeSection1").GetComponent<RealDeck>();
        RealDeck mSection2 = GameObject.Find("MeleeSection2").GetComponent<RealDeck>();
        RealDeck rSection2 = GameObject.Find("RangeSection2").GetComponent<RealDeck>();
        RealDeck sSection2 = GameObject.Find("SiegeSection2").GetComponent<RealDeck>();

        int[] attackList = new int[]{0,0,0,0,0,0};
        //Abajo se encuentra todos los valores de ataque máximos de cada fila sin contar cartas de Héroe
        attackList[0] = GetMaxValue(attackList[0], mSection1.GetComponent<RealDeck>().Real_Cards);
        attackList[1] = GetMaxValue(attackList[1], rSection1.GetComponent<RealDeck>().Real_Cards);
        attackList[2] = GetMaxValue(attackList[2], sSection1.GetComponent<RealDeck>().Real_Cards);
        attackList[3] = GetMaxValue(attackList[3], mSection2.GetComponent<RealDeck>().Real_Cards);
        attackList[4] = GetMaxValue(attackList[4], rSection2.GetComponent<RealDeck>().Real_Cards);
        attackList[5] = GetMaxValue(attackList[5], sSection2.GetComponent<RealDeck>().Real_Cards);

        int MaxPower = 0; //Aquí se reserva el mayor ataque del campo

        for (int i = 0; i < attackList.Length; i++) //Consigue el mayor ataque del campo sin contar cartas de Héroe
        {
            if (attackList[i] > MaxPower)
            {
                MaxPower = attackList[i];
            }
        }

        if (mSection1.Real_Cards.Count != 0)
        {   List<GameObject> objectsName = new List<GameObject>();
            foreach (GameObject card in mSection1.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().powerAttack == MaxPower && card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    AddToGraveyardOneCards(card, mSection1);
                    objectsName.Add(card);
                }
            }
            foreach (GameObject name in objectsName)
            {
                mSection1.Real_Cards.Remove(name);
            }
        }
        if (rSection1.Real_Cards.Count != 0)
        {   List<GameObject> objectsName = new List<GameObject>();
            foreach (GameObject card in rSection1.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().powerAttack == MaxPower && card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    AddToGraveyardOneCards(card, rSection1);
                    objectsName.Add(card);
                }
            }
            foreach (GameObject name in objectsName)
            {
                rSection1.Real_Cards.Remove(name);
            }
        }
        if (sSection1.Real_Cards.Count != 0)
        {   List<GameObject> objectsName = new List<GameObject>();
            foreach (GameObject card in sSection1.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().powerAttack == MaxPower && card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    AddToGraveyardOneCards(card, sSection1);
                    objectsName.Add(card);
                }
            }
            foreach (GameObject name in objectsName)
            {
                sSection1.Real_Cards.Remove(name);
            }
        }
        if (mSection2.Real_Cards.Count != 0)
        {   List<GameObject> objectsName = new List<GameObject>();
            foreach (GameObject card in mSection2.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().powerAttack == MaxPower && card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    AddToGraveyardOneCards(card, mSection2);
                    objectsName.Add(card);
                }
            }
            foreach (GameObject name in objectsName)
            {
                mSection2.Real_Cards.Remove(name);
            }
        }
        if (rSection2.Real_Cards.Count != 0)
        {   List<GameObject> objectsName = new List<GameObject>();
            foreach (GameObject card in rSection2.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().powerAttack == MaxPower && card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    AddToGraveyardOneCards(card, rSection2);
                    objectsName.Add(card);
                }
            }
            foreach (GameObject name in objectsName)
            {
                rSection2.Real_Cards.Remove(name);
            }
        }
        if (sSection2.Real_Cards.Count != 0)
        {   List<GameObject> objectsName = new List<GameObject>();
            foreach (GameObject card in sSection2.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().powerAttack == MaxPower && card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    AddToGraveyardOneCards(card, sSection2);
                    objectsName.Add(card);
                }
            }
            foreach (GameObject name in objectsName)
            {
                sSection2.Real_Cards.Remove(name);
            }
        }
    }






    public static void LittleBurn(GameObject Card)
    {
        if (Card.transform.IsChildOf(GameObject.Find("Player1").transform))
        {
            RealDeck mSection2 = GameObject.Find("MeleeSection2").GetComponent<RealDeck>();
            RealDeck rSection2 = GameObject.Find("RangeSection2").GetComponent<RealDeck>();
            RealDeck sSection2 = GameObject.Find("SiegeSection2").GetComponent<RealDeck>();
            int[] attackList = new int[]{int.MaxValue,int.MaxValue,int.MaxValue};
            //Abajo se encuentra todos los valores de ataque mínimos de cada fila sin contar cartas de Héroe
            attackList[0] = GetMinValue(attackList[0], mSection2.GetComponent<RealDeck>().Real_Cards);
            attackList[1] = GetMinValue(attackList[1], rSection2.GetComponent<RealDeck>().Real_Cards);
            attackList[2] = GetMinValue(attackList[2], sSection2.GetComponent<RealDeck>().Real_Cards);
            
            int MinPower = int.MaxValue; //Aquí se reserva el menor ataque del campo

            for (int i = 0; i < attackList.Length; i++) //Consigue el menor ataque del campo sin contar cartas de Héroe
            {
                if (attackList[i] < MinPower && attackList[i] != 0)
                {
                    MinPower = attackList[i];
                }
            }

            if (mSection2.Real_Cards.Count != 0)
            {   
                List<GameObject> objectsName = new List<GameObject>();
                foreach (GameObject card in mSection2.Real_Cards)
                {
                    if (card.GetComponent<PreF_UnitCard>().powerAttack == MinPower && card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                    {
                        AddToGraveyardOneCards(card, mSection2);
                        objectsName.Add(card);
                    }
                }
                foreach (GameObject name in objectsName)
                {
                    if (mSection2.Real_Cards.Contains(name))
                    {
                        mSection2.Real_Cards.Remove(name);
                    }
                }
            }
            if (rSection2.Real_Cards.Count != 0)
            {   
                List<GameObject> objectsName = new List<GameObject>();
                foreach (GameObject card in rSection2.Real_Cards)
                {
                    if (card.GetComponent<PreF_UnitCard>().powerAttack == MinPower && card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                    {
                        AddToGraveyardOneCards(card, rSection2);
                        objectsName.Add(card);
                    }
                }
                foreach (GameObject name in objectsName)
                {
                    rSection2.Real_Cards.Remove(name);
                }
            }
            if (sSection2.Real_Cards.Count != 0)
            {   
                List<GameObject> objectsName = new List<GameObject>();
                foreach (GameObject card in sSection2.Real_Cards)
                {
                    if (card.GetComponent<PreF_UnitCard>().powerAttack == MinPower && card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                    {
                        AddToGraveyardOneCards(card, sSection2);
                        objectsName.Add(card);
                    }
                }
                foreach (GameObject name in objectsName)
                {
                    sSection2.Real_Cards.Remove(name);
                }
            }

            
        }
        if (Card.transform.IsChildOf(GameObject.Find("Player2").transform))
        {
            
            RealDeck mSection1 = GameObject.Find("MeleeSection1").GetComponent<RealDeck>();
            RealDeck rSection1 = GameObject.Find("RangeSection1").GetComponent<RealDeck>();
            RealDeck sSection1 = GameObject.Find("SiegeSection1").GetComponent<RealDeck>();
            int[] attackList = new int[]{int.MaxValue,int.MaxValue,int.MaxValue};
            //Abajo se encuentra todos los valores de ataque mínimos de cada fila sin contar cartas de Héroe
            
            attackList[0] = GetMinValue(attackList[0], mSection1.GetComponent<RealDeck>().Real_Cards);
            attackList[1] = GetMinValue(attackList[1], rSection1.GetComponent<RealDeck>().Real_Cards);
            attackList[2] = GetMinValue(attackList[2], sSection1.GetComponent<RealDeck>().Real_Cards);
            Debug.Log(attackList[0] + " " + attackList[1] + " " + attackList[2]);

            int MinPower = int.MaxValue; //Aquí se reserva el menor ataque del campo

            for (int i = 0; i < attackList.Length; i++) //Consigue el menor ataque del campo sin contar cartas de Héroe
            {
                if (attackList[i] < MinPower && attackList[i] != 0)
                {
                    MinPower = attackList[i];
                }
            }
            if (mSection1.Real_Cards.Count != 0)
            {   
                List<GameObject> objectsName = new List<GameObject>();
                foreach (GameObject card in mSection1.Real_Cards)
                {
                    if (card.GetComponent<PreF_UnitCard>().powerAttack == MinPower && card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                    {
                        AddToGraveyardOneCards(card, mSection1);
                        objectsName.Add(card);
                    }
                }
                foreach (GameObject name in objectsName)
                {
                    mSection1.Real_Cards.Remove(name);
                }
            }
            if (rSection1.Real_Cards.Count != 0)
            {   
                List<GameObject> objectsName = new List<GameObject>();
                foreach (GameObject card in rSection1.Real_Cards)
                {
                    if (card.GetComponent<PreF_UnitCard>().powerAttack == MinPower && card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                    {
                        AddToGraveyardOneCards(card, rSection1);
                        objectsName.Add(card);
                    }
                }
                foreach (GameObject name in objectsName)
                {
                    rSection1.Real_Cards.Remove(name);
                }
            }
            if (sSection1.Real_Cards.Count != 0)
            {   
                List<GameObject> objectsName = new List<GameObject>();
                foreach (GameObject card in sSection1.Real_Cards)
                {
                    if (card.GetComponent<PreF_UnitCard>().powerAttack == MinPower && card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                    {
                        AddToGraveyardOneCards(card, sSection1);
                        objectsName.Add(card);
                    }
                }
                foreach (GameObject name in objectsName)
                {   
                    sSection1.Real_Cards.Remove(name);
                }
            }
        }     
    }


    public static int GetMaxValue(int receptor, List<GameObject> section)
    {
        foreach (GameObject card in section)
        {
            if (card.GetComponent<PreF_UnitCard>().powerAttack > receptor && card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
            {
                receptor = card.GetComponent<PreF_UnitCard>().powerAttack;
            }
        }
        return receptor;
    }
    public static int GetMinValue(int receptor, List<GameObject> section)
    {
        if (section.Count != 0)
        {
            foreach (GameObject card in section)
            {
                if (card.GetComponent<PreF_UnitCard>().powerAttack < receptor && card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    receptor = card.GetComponent<PreF_UnitCard>().powerAttack;
                }
            }
            return receptor;
        }
        receptor = 0;
        return receptor;
    }

    public static void ClearSectionWithMinTroops()
    {
        RealDeck mSection1 = GameObject.Find("MeleeSection1").GetComponent<RealDeck>();
        RealDeck rSection1 = GameObject.Find("RangeSection1").GetComponent<RealDeck>();
        RealDeck sSection1 = GameObject.Find("SiegeSection1").GetComponent<RealDeck>();
        RealDeck mSection2 = GameObject.Find("MeleeSection2").GetComponent<RealDeck>();
        RealDeck rSection2 = GameObject.Find("RangeSection2").GetComponent<RealDeck>();
        RealDeck sSection2 = GameObject.Find("SiegeSection2").GetComponent<RealDeck>();

        List<int> counts = new List<int>();
        int Total = int.MaxValue;
        counts.Add(mSection1.Real_Cards.Count);
        counts.Add(rSection1.Real_Cards.Count);
        counts.Add(sSection1.Real_Cards.Count);
        counts.Add(mSection2.Real_Cards.Count);
        counts.Add(rSection2.Real_Cards.Count);
        counts.Add(sSection2.Real_Cards.Count);
        foreach (int number in counts)
        {
            if (number < Total && number != 0)
            {
                Total = number;
            }
        }
        if (Total == int.MaxValue)
        {
            return;
        }
        if (mSection1.Real_Cards.Count == Total)
        {
            List<GameObject> help = new List<GameObject>();
            foreach (GameObject card in mSection1.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    AddToGraveyardOneCards(card,mSection1);
                    help.Add(card);
                }
            }
            foreach (GameObject name in help)
            {
                mSection1.Real_Cards.Remove(name);
            }
        }
        if (rSection1.Real_Cards.Count == Total)
        {
            List<GameObject> help = new List<GameObject>();
            foreach (GameObject card in rSection1.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    AddToGraveyardOneCards(card,rSection1);
                    help.Add(card);
                }
            }
            foreach (GameObject name in help)
            {
                rSection1.Real_Cards.Remove(name);
            }
        }
        if (sSection1.Real_Cards.Count == Total)
        {
            List<GameObject> help = new List<GameObject>();
            foreach (GameObject card in sSection1.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    AddToGraveyardOneCards(card,sSection1);
                    help.Add(card);
                }
            }
            foreach (GameObject name in help)
            {
                sSection1.Real_Cards.Remove(name);
            }
        }
        if (mSection2.Real_Cards.Count == Total)
        {
            List<GameObject> help = new List<GameObject>();
            foreach (GameObject card in mSection2.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    AddToGraveyardOneCards(card,mSection2);
                    help.Add(card);
                }
            }
            foreach (GameObject name in help)
            {
                mSection2.Real_Cards.Remove(name);
            }
        }
        if (rSection2.Real_Cards.Count == Total)
        {
            List<GameObject> help = new List<GameObject>();
            foreach (GameObject card in rSection2.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    AddToGraveyardOneCards(card,rSection2);
                    help.Add(card);
                }
            }
            foreach (GameObject name in help)
            {
                rSection2.Real_Cards.Remove(name);
            }
        }
        if (sSection2.Real_Cards.Count == Total)
        {
            List<GameObject> help = new List<GameObject>();
            foreach (GameObject card in sSection2.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    AddToGraveyardOneCards(card,sSection2);
                    help.Add(card);
                }
            }
            foreach (GameObject name in help)
            {
                sSection2.Real_Cards.Remove(name);
            }
        } 
    }

    public static void CompanionEffect(GameObject companionCard, GameObject Section)
    {
        int companionCount = 0;
        ////////////////////////////////////////////////////////////////////////////////////
        int originalPower = companionCard.GetComponent<PreF_UnitCard>().powerAttack;//unit_Card.Power;
        ////////////////////////////////////////////////////////////////////////////////////
        foreach (GameObject card in Section.GetComponent<RealDeck>().Real_Cards)
        {
            if (card.name == companionCard.name)
            {
                companionCount++;
            }
        }
        Debug.Log("Companion count " + companionCount);
        if (companionCount == 1)
        {
            Debug.Log("Entré donde no era");
            return;
        }
        foreach (GameObject card in Section.GetComponent<RealDeck>().Real_Cards)
        {
            if (card.name == companionCard.name)
            {
                card.GetComponent<PreF_UnitCard>().powerAttack = originalPower * companionCount;
                Debug.Log("la carta ahora tiene de ataque " + card.GetComponent<PreF_UnitCard>().powerAttack);
            }
        }
        Debug.Log("En teoría salí bien del metodo");
    }

    public static void AverageEffect()
    {
        RealDeck mSection1 = GameObject.Find("MeleeSection1").GetComponent<RealDeck>();
        RealDeck rSection1 = GameObject.Find("RangeSection1").GetComponent<RealDeck>();
        RealDeck sSection1 = GameObject.Find("SiegeSection1").GetComponent<RealDeck>();
        RealDeck mSection2 = GameObject.Find("MeleeSection2").GetComponent<RealDeck>();
        RealDeck rSection2 = GameObject.Find("RangeSection2").GetComponent<RealDeck>();
        RealDeck sSection2 = GameObject.Find("SiegeSection2").GetComponent<RealDeck>();
        
        int powerMelee1 = 0;
        int powerRange1 = 0;
        int powerSiege1 = 0;
        int powerMelee2 = 0;
        int powerRange2 = 0;
        int powerSiege2 = 0;
        int cantCards = 0;

        if (mSection1.Real_Cards.Count != 0)
        {
            foreach (GameObject card in mSection1.Real_Cards)
            {
                powerMelee1 += card.GetComponent<PreF_UnitCard>().powerAttack;
                cantCards++;
            }
        }
        if (rSection1.Real_Cards.Count != 0)
        {
            foreach (GameObject card in rSection1.Real_Cards)
            {
                powerRange1 += card.GetComponent<PreF_UnitCard>().powerAttack;
                cantCards++;
            }
        }
        if (sSection1.Real_Cards.Count != 0)
        {
            foreach (GameObject card in sSection1.Real_Cards)
            {
                powerSiege1 += card.GetComponent<PreF_UnitCard>().powerAttack;
                cantCards++;
            }
        }
        if (mSection2.Real_Cards.Count != 0)
        {
            foreach (GameObject card in mSection2.Real_Cards)
            {
                powerMelee2 += card.GetComponent<PreF_UnitCard>().powerAttack;
                cantCards++;
            }
        }
        if (rSection2.Real_Cards.Count != 0)
        {
            foreach (GameObject card in rSection2.Real_Cards)
            {
                powerRange2 += card.GetComponent<PreF_UnitCard>().powerAttack;
                cantCards++;
            }
        }
        if (sSection2.Real_Cards.Count != 0)
        {
            foreach (GameObject card in sSection2.Real_Cards)
            {
                powerSiege2 += card.GetComponent<PreF_UnitCard>().powerAttack;
                cantCards++;
            }
        }

        int total = powerMelee1 + powerRange1 + powerSiege1 + powerMelee2 + powerRange2 + powerSiege2;
        if (cantCards == 0)
        {
            return;
        }
        /////////////////////////////////////
        int average = total / cantCards;
        /////////////////////////////////////
        if (mSection1.Real_Cards.Count != 0)
        {
            foreach (GameObject card in mSection1.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    card.GetComponent<PreF_UnitCard>().powerAttack = average;
                }
            }
        }
        if (rSection1.Real_Cards.Count != 0)
        {
            foreach (GameObject card in rSection1.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    card.GetComponent<PreF_UnitCard>().powerAttack = average;
                }
            }
        }
        if (sSection1.Real_Cards.Count != 0)
        {
            foreach (GameObject card in sSection1.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    card.GetComponent<PreF_UnitCard>().powerAttack = average;
                }
            }
        }
        if (mSection2.Real_Cards.Count != 0)
        {
            foreach (GameObject card in mSection2.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    card.GetComponent<PreF_UnitCard>().powerAttack = average;
                }
            }
        }
        if (rSection2.Real_Cards.Count != 0)
        {
            foreach (GameObject card in rSection2.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    card.GetComponent<PreF_UnitCard>().powerAttack = average;
                }
            }
        }
        if (sSection2.Real_Cards.Count != 0)
        {
            foreach (GameObject card in sSection2.Real_Cards)
            {
                if (card.GetComponent<PreF_UnitCard>().unit_Card.LType != Level_type.Golden)
                {
                    card.GetComponent<PreF_UnitCard>().powerAttack = average;
                }
            }
        }
    }

    public static void SeñueloEffect(GameObject señueloCard, GameObject player)
    {
        player.GetComponent<Player>().SeñueloActivate = true;
        ColliderEditor.StaticDisableAllColliders();
        if (player.name == "Player1")
        {
            GameObject mSection = GameObject.Find("MeleeSection1");
            GameObject rSection = GameObject.Find("RangeSection1");
            GameObject sSection = GameObject.Find("SiegeSection1");

            ColliderEditor.SeñueloCollider(mSection,rSection,sSection);




        }
        if (player.name == "Player2")
        {
            GameObject mSection = GameObject.Find("MeleeSection2");
            GameObject rSection = GameObject.Find("RangeSection2");
            GameObject sSection = GameObject.Find("SiegeSection2");

            ColliderEditor.SeñueloCollider(mSection,rSection,sSection);

            


        }
    }

    public static void SeñueloEffect2(GameObject cardToSwitch ,GameObject section, GameObject hand)
    {
        if (GameObject.Find("Player1").GetComponent<Player>().SeñueloActivate)
        {
            Vector3 position1 = new Vector3(0,0,0);
            Vector3 positionInSection = cardToSwitch.GetComponent<Transform>().position;
            foreach (GameObject card in hand.GetComponent<RealDeck>().Real_Cards) //encuentra el señuelo en la mano
            {
                if (card.name == "Señuelo") // cuando encuentra el señuelo
                {
                    position1 = card.GetComponent<Transform>().position; // guarda la posicion del señuelo en la mano
                    section.GetComponent<RealDeck>().Real_Cards.Add(card); //añade el señuelo a la lista de la seccion
                    card.transform.SetParent(section.transform); //convierte al señuelo en hijo de la seccion
                    hand.GetComponent<RealDeck>().Real_Cards.Remove(card); //remueve al señuelo de la lista de la mano
                    card.GetComponent<Transform>().position = positionInSection; //le da al señuelo la posicion de la carta a cambiar

                    hand.GetComponent<RealDeck>().Real_Cards.Add(cardToSwitch); //añade la carta a cambiar a la lista de la mano
                    section.GetComponent<RealDeck>().Real_Cards.Remove(cardToSwitch); // remueve la carta a cambiar de la seccion
                    cardToSwitch.transform.SetParent(hand.transform); //convierte la carta a cambiar en hijo de la mano
                    cardToSwitch.GetComponent<Transform>().position = position1; //le da la posicion anterior del señuelo a la carta a cambiar

                    GameObject.Find("Player1").GetComponent<Player>().SeñueloActivate = false;
                    GameObject.Find("Player2").GetComponent<Player>().SeñueloActivate = false;
                    ColliderEditor.StaticEnableAllColliders();
                    GameManager.playerTurn = !GameManager.playerTurn;
                    ColliderEditor.EnablePlayerCollider();
                    ColliderEditor.DisablePlayerCollider();


                    return;
                }
            }
        }
        if (GameObject.Find("Player2").GetComponent<Player>().SeñueloActivate)
        {
            Vector3 position1 = new Vector3(0,0,0);
            Vector3 positionInSection = cardToSwitch.GetComponent<Transform>().position;
            foreach (GameObject card in hand.GetComponent<RealDeck>().Real_Cards) //encuentra el señuelo en la mano
            {
                if (card.name == "Señuelo") // cuando encuentra el señuelo
                {
                    position1 = card.GetComponent<Transform>().position; // guarda la posicion del señuelo en la mano
                    section.GetComponent<RealDeck>().Real_Cards.Add(card); //añade el señuelo a la lista de la seccion
                    card.transform.SetParent(section.transform); //convierte al señuelo en hijo de la seccion
                    hand.GetComponent<RealDeck>().Real_Cards.Remove(card); //remueve al señuelo de la lista de la mano
                    card.GetComponent<Transform>().position = positionInSection; //le da al señuelo la posicion de la carta a cambiar

                    hand.GetComponent<RealDeck>().Real_Cards.Add(cardToSwitch); //añade la carta a cambiar a la lista de la mano
                    section.GetComponent<RealDeck>().Real_Cards.Remove(cardToSwitch); // remueve la carta a cambiar de la seccion
                    cardToSwitch.transform.SetParent(hand.transform); //convierte la carta a cambiar en hijo de la mano
                    cardToSwitch.GetComponent<Transform>().position = position1; //le da la posicion anterior del señuelo a la carta a cambiar

                    GameObject.Find("Player2").GetComponent<Player>().SeñueloActivate = false;
                    GameObject.Find("Player1").GetComponent<Player>().SeñueloActivate = false;
                    ColliderEditor.StaticEnableAllColliders();
                    GameManager.playerTurn = !GameManager.playerTurn;
                    ColliderEditor.EnablePlayerCollider();
                    ColliderEditor.DisablePlayerCollider();

                    return;
                }
            }
        }
    }
    
}