using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public class PrefabClick : MonoBehaviour
{
//quiero hacer que al pulsar la carta me la mande a la division correspondiente. (falta los aumentos y los climas)
    private void OnMouseDown()
    {
        GameObject cardGameObject = this.gameObject; //Se define la instancia especifica del prefab que contiene el botón.
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
    }
}
