using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card (solamente usar para crear la carta Fuego o Horn)")]
public class Card : ScriptableObject 
{
    [SerializeField]public Sprite Image;
    [SerializeField]public string Tittle;
    [SerializeField]public string Effect_description;
    [SerializeField]public eFaction Faction;
    [SerializeField]public eEfect Efect;

    
}

public enum eFaction
{
    Empire, 
    Oblivion, 
    Neutral
}

public enum eEfect
{
    None, //No efecto
    Buff, //Aumento en fila
    Wheather, //Clima
    Burn,  //Quemadura
    little_Burn, //Quemadura menor
    Steal, //Robar carta
    Companion, // multiplicar por n el ataque de las cartas con el mismo nombre (siendo n la cantidad de cartas)
    Clear, //Limpia la fila con menos unidades
    Average, //Promedio
    Señuelo //Vamos, el señuelo

}