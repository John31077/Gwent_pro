using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEditor.AssetImporters;
using UnityEngine;

public class PrefabClick : MonoBehaviour
{
    public static GameObject cardGameObject; 
    public static bool boolForHorn; //Solamente hace falta para que funcione bien el cambio de turno cuando se usa "Cuerno de Guerra"
    private void OnMouseDown()
    {
        cardGameObject = this.gameObject; //Se define la instancia especifica del prefab que contiene el botón.
        if (cardGameObject.GetComponent<PreF_UnitCard>() != null) //Entra si el prefab es una carta de unidad.
        {
            if (cardGameObject.GetComponent<PreF_UnitCard>().unit_Card.AType == Attack_type.Melee)//Entra si es de melee
            {
                if (cardGameObject.transform.IsChildOf(GameObject.Find("Player1").transform)) //Entra si el prefab es del jugador 1.
                {
                    RealDeck hand1 =  GameObject.Find("Hand1").GetComponent<RealDeck>(); //Esto es la lista de Hand1
                    RealDeck melee1 = GameObject.Find("MeleeSection1").GetComponent<RealDeck>(); //Esto es la lista de MeleeSection1
                    AddToList.AddToMelee(cardGameObject, melee1, hand1); //Llama al metodo para posicionar cartas en melee.
                }    
                else if (cardGameObject.transform.IsChildOf(GameObject.Find("Player2").transform))  //Entra si el prefab es del jugador 2.
                {
                    RealDeck hand2 =  GameObject.Find("Hand2").GetComponent<RealDeck>(); //Esto es la lista de Hand2
                    RealDeck melee2 = GameObject.Find("MeleeSection2").GetComponent<RealDeck>(); //Esto es la lista de MeleeSection2
                    AddToList.AddToMelee(cardGameObject, melee2, hand2); //Llama al metodo para posicionar cartas en melee.
                }
            }
            if (cardGameObject.GetComponent<PreF_UnitCard>().unit_Card.AType == Attack_type.Range) //Entra si es de range.
            {
                if (cardGameObject.transform.IsChildOf(GameObject.Find("Player1").transform)) //Entra si el prefab es del jugador 1.
                {
                    RealDeck hand1 =  GameObject.Find("Hand1").GetComponent<RealDeck>(); //Esto es la lista de Hand1
                    RealDeck range1 = GameObject.Find("RangeSection1").GetComponent<RealDeck>(); //Esto es la lista de RangeSection1
                    AddToList.AddToRange(cardGameObject, range1, hand1); //Llama al metodo para posicionar cartas en range.
                }
                else if (cardGameObject.transform.IsChildOf(GameObject.Find("Player2").transform))  //Entra si el prefab es del jugador 2.
                {
                    RealDeck hand2 =  GameObject.Find("Hand2").GetComponent<RealDeck>(); //Esto es la lista de Hand2
                    RealDeck range2 = GameObject.Find("RangeSection2").GetComponent<RealDeck>(); //Esto es la lista de RangeSection2
                    AddToList.AddToRange(cardGameObject, range2, hand2); //Llama al metodo para posicionar cartas en range.
                }
            }
            if (cardGameObject.GetComponent<PreF_UnitCard>().unit_Card.AType == Attack_type.Siege) //Entra si es de siege.
            {
                if (cardGameObject.transform.IsChildOf(GameObject.Find("Player1").transform)) //Entra si el prefab es del jugador 1.
                {
                    RealDeck hand1 =  GameObject.Find("Hand1").GetComponent<RealDeck>(); //Esto es la lista de Hand1
                    RealDeck siege1 = GameObject.Find("SiegeSection1").GetComponent<RealDeck>(); //Esto es la lista de SiegeSection1
                    AddToList.AddToSiege(cardGameObject, siege1, hand1); //Llama al metodo para posicionar cartas en siege.
                }
                else if (cardGameObject.transform.IsChildOf(GameObject.Find("Player2").transform))  //Entra si el prefab es del jugador 2.
                {
                    RealDeck hand2 =  GameObject.Find("Hand2").GetComponent<RealDeck>(); //Esto es la lista de Hand2
                    RealDeck siege2 = GameObject.Find("SiegeSection2").GetComponent<RealDeck>(); //Esto es la lista de RangeSection2
                    AddToList.AddToSiege(cardGameObject, siege2, hand2); //Llama al metodo para posicionar cartas en siege.
                }
            }
        }
        else if (cardGameObject.GetComponent<LeaderSection>() != null) //Entra si el prefab es una carta líder
        {
            if (cardGameObject.transform.IsChildOf(GameObject.Find("Player1").transform))
            {
                if (cardGameObject.GetComponent<LeaderSection>().leader.Tittle == "Rey Emeric" && GameObject.Find("Player1").GetComponent<Player>().leaderEffect == false)
                {
                    if (GameObject.Find("WeatherSection").GetComponent<RealDeck>().Real_Cards.Count == 0)
                    {
                        //No aplica el efecto el lider si no hay cartas en la seccion de clima.
                    }
                    else
                    {
                        AddToList.SunnyEffect();
                        GameObject.Find("Player1").GetComponent<Player>().leaderEffect = true;
                        GameObject.Find("Player1").GetComponent<Player>().leaderEffect = true;
                        GameManager.playerTurn = !GameManager.playerTurn;
                        Debug.Log(GameManager.playerTurn);
                    }

                }
            }
            if (cardGameObject.transform.IsChildOf(GameObject.Find("Player2").transform))
            {
                if (cardGameObject.GetComponent<LeaderSection>().leader.Tittle == "Rey Emeric" && GameObject.Find("Player2").GetComponent<Player>().leaderEffect == false)
                {
                    
                    if (GameObject.Find("WeatherSection").GetComponent<RealDeck>().Real_Cards.Count == 0)
                    {
                        //No aplica el efecto el lider si no hay cartas en la seccion de clima.
                    }
                    else
                    {
                        AddToList.SunnyEffect();
                        GameObject.Find("Player2").GetComponent<Player>().leaderEffect = true;
                        GameObject.Find("Player2").GetComponent<Player>().leaderEffect = true;
                        GameManager.playerTurn = !GameManager.playerTurn;
                        Debug.Log(GameManager.playerTurn);
                        
                    }
                }
            }
        }
        else if (cardGameObject.GetComponent<Pref_HornOrFireCard>() != null) //Entra si el prefab es una carta de Cuerno o Fuego
        {
            if (cardGameObject.GetComponent<Pref_HornOrFireCard>().card.Efect == eEfect.Buff) //Entra si es Cuerno
            {
                HornSection hornSectionM1 = GameObject.Find("MeleeBuffSection1").GetComponent<HornSection>();
                HornSection hornSectionR1 = GameObject.Find("RangeBuffSection1").GetComponent<HornSection>();
                HornSection hornSectionS1 = GameObject.Find("SiegeBuffSection1").GetComponent<HornSection>();
                HornSection hornSectionM2 = GameObject.Find("MeleeBuffSection2").GetComponent<HornSection>();
                HornSection hornSectionR2 = GameObject.Find("RangeBuffSection2").GetComponent<HornSection>();
                HornSection hornSectionS2 = GameObject.Find("SiegeBuffSection2").GetComponent<HornSection>();
                //Aquí se verifica que la carta pulsada no sea las que se encuentran en el campo. Evitando que aparezca la pantalla de selección
                if (hornSectionM1.hornCard == cardGameObject||hornSectionR1.hornCard == cardGameObject||hornSectionS1.hornCard == cardGameObject||hornSectionM2.hornCard == cardGameObject||hornSectionR2.hornCard == cardGameObject||hornSectionS2.hornCard == cardGameObject)
                {
                    return;
                }
                else //Activa una pantalla con la opción para elegir la sección para colocar la carta.
                {
                    GameObject pref_HornOrFireReference = GameObject.Find("Pref_HornOrFireCard");
                    GameObject selectionHornSection = pref_HornOrFireReference.GetComponent<BuffSection>().buffSection;
                    selectionHornSection.SetActive(true);
                    ColliderEditor colliderEditor = GameObject.Find("Canvas").GetComponent<ColliderEditor>();
                    boolForHorn = true;
                    colliderEditor.DisableAllColliders();
                }
            }
            else //Entra si es Fuego
            {
                if (cardGameObject.transform.IsChildOf(GameObject.Find("Player1").transform)) //Entra si el prefab es del jugador 1
                {
                    RealDeck hand1 =  GameObject.Find("Hand1").GetComponent<RealDeck>();
                    if (GameObject.Find("Graveyard1").GetComponent<RealDeck>().Real_Cards.Contains(cardGameObject))
                    {
                        //Evita que se vuelva a activar el efecto de la carta estando en el cementerio
                    }
                    else
                    {
                        //Se envía al cementerio aplicando su efecto (no tiene sentido colocarse en el campo para después al instante quitarla)
                        AddToList.AddToGraveyardOneCards(cardGameObject, hand1);
                        //Aplica el efecto
                        AddToList.Burn();
                        Debug.Log("Se activó el efecto de Fuego");
                        GameObject card = hand1.Real_Cards.Find(x => x == cardGameObject);
                        hand1.Real_Cards.Remove(card);
                        GameManager.playerTurn = !GameManager.playerTurn;
                    }
                }    
                if (cardGameObject.transform.IsChildOf(GameObject.Find("Player2").transform)) //Entra si el prefab es del jugador 2
                {
                    RealDeck hand2 =  GameObject.Find("Hand2").GetComponent<RealDeck>();
                    if (GameObject.Find("Graveyard2").GetComponent<RealDeck>().Real_Cards.Contains(cardGameObject))
                    {
                        //Evita que se vuelva a activar el efecto de la carta estando en el cementerio
                    }
                    else
                    {
                        //Se envía al cementerio aplicando su efecto (no tiene sentido colocarse en el campo para después al instante quitarla)
                        AddToList.AddToGraveyardOneCards(cardGameObject, hand2);
                        //Aplica el efecto
                        AddToList.Burn();
                        Debug.Log("Se activó el efecto de Fuego");
                        GameObject card = hand2.Real_Cards.Find(x => x == cardGameObject);
                        hand2.Real_Cards.Remove(card);
                        GameManager.playerTurn = !GameManager.playerTurn;
                    }
                }

            }
        }
        else if (cardGameObject.GetComponent<Pref_WeatherCard>() != null) //Entra si es una carta de clima
        {

            AddToList.AddToWeather(cardGameObject);
        }
    }
    
    public void AddToHornSectionMelee() //Añade la carta Cuerno a la sección melee correspondiente
    {
        if (cardGameObject.transform.IsChildOf(GameObject.Find("Player1").transform)) //Entra si el prefab es del jugador 1
        {
            HornSection hornSection = GameObject.Find("MeleeBuffSection1").GetComponent<HornSection>();
            RealDeck hand1 =  GameObject.Find("Hand1").GetComponent<RealDeck>();
            hornSection.hornCard = cardGameObject; //Añade la carta a la sección
            hand1.Real_Cards.Remove(cardGameObject); //Elimina la carta de la mano
            cardGameObject.transform.SetParent(GameObject.Find("MeleeBuffSection1").transform);
            cardGameObject.GetComponent<Transform>().position = new Vector3(-435f,75.5f,0);  
        }
        if (cardGameObject.transform.IsChildOf(GameObject.Find("Player2").transform)) //Entra si el prefab es del jugador 2
        {
            HornSection hornSection = GameObject.Find("MeleeBuffSection2").GetComponent<HornSection>();
            RealDeck hand2 =  GameObject.Find("Hand2").GetComponent<RealDeck>();
            hornSection.hornCard = cardGameObject; //Añade la carta a la sección
            hand2.Real_Cards.Remove(cardGameObject); //Elimina la carta de la mano
            cardGameObject.transform.SetParent(GameObject.Find("MeleeBuffSection2").transform);
            cardGameObject.GetComponent<Transform>().position = new Vector3(-435f,102.8f,0);
        }
    }
    public void AddToHornSectionRange()
    {
        if (cardGameObject.transform.IsChildOf(GameObject.Find("Player1").transform)) //Entra si el prefab es del jugador 1
        {
            HornSection hornSection = GameObject.Find("RangeBuffSection1").GetComponent<HornSection>();
            RealDeck hand1 =  GameObject.Find("Hand1").GetComponent<RealDeck>();
            hornSection.hornCard = cardGameObject; //Añade la carta a la sección
            hand1.Real_Cards.Remove(cardGameObject); //Elimina la carta de la mano
            cardGameObject.transform.SetParent(GameObject.Find("RangeBuffSection1").transform);
            cardGameObject.GetComponent<Transform>().position = new Vector3(-435f,48.5f,0);
        }
        if (cardGameObject.transform.IsChildOf(GameObject.Find("Player2").transform)) //Entra si el prefab es del jugador 2
        {
            HornSection hornSection = GameObject.Find("RangeBuffSection2").GetComponent<HornSection>();
            RealDeck hand2 =  GameObject.Find("Hand2").GetComponent<RealDeck>();
            hornSection.hornCard = cardGameObject; //Añade la carta a la sección
            hand2.Real_Cards.Remove(cardGameObject); //Elimina la carta de la mano
            cardGameObject.transform.SetParent(GameObject.Find("RangeBuffSection2").transform);
            cardGameObject.GetComponent<Transform>().position = new Vector3(-435f,128.8f,0);
        }
    }
    public void AddToHornSectionSiege()
    {
        if (cardGameObject.transform.IsChildOf(GameObject.Find("Player1").transform)) //Entra si el prefab es del jugador 1
        {
            HornSection hornSection = GameObject.Find("SiegeBuffSection1").GetComponent<HornSection>();
            RealDeck hand1 =  GameObject.Find("Hand1").GetComponent<RealDeck>();
            hornSection.hornCard = cardGameObject; //Añade la carta a la sección
            hand1.Real_Cards.Remove(cardGameObject); //Elimina la carta de la mano
            cardGameObject.transform.SetParent(GameObject.Find("SiegeBuffSection1").transform);
            cardGameObject.GetComponent<Transform>().position = new Vector3(-435f,22.5f,0);
        }
        if (cardGameObject.transform.IsChildOf(GameObject.Find("Player2").transform)) //Entra si el prefab es del jugador 2
        {
            HornSection hornSection = GameObject.Find("SiegeBuffSection2").GetComponent<HornSection>();
            RealDeck hand2 =  GameObject.Find("Hand2").GetComponent<RealDeck>();
            hornSection.hornCard = cardGameObject; //Añade la carta a la sección
            hand2.Real_Cards.Remove(cardGameObject); //Elimina la carta de la mano
            cardGameObject.transform.SetParent(GameObject.Find("SiegeBuffSection2").transform);
            cardGameObject.GetComponent<Transform>().position = new Vector3(-435f,155.8f,0);
        }
    }
}
