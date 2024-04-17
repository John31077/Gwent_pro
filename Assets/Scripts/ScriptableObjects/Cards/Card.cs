using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Card : ScriptableObject 
{
    [SerializeField]private Sprite Image;
    [SerializeField]private string Effect_description;
    [SerializeField]public eFaction Faction;

    public virtual void Efect()
    {}
}

public enum eFaction
{
    Empire, 
    Oblivion, 
    Neutral
}