using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Card", menuName = "Unit Card")]
public class Unit_card : Card
{
    [SerializeField]public int Power;
    [SerializeField]public Attack_type AType;
    [SerializeField]public Level_type LType;
}
public enum Attack_type
{
    Melee,
    Range,
    Siege,
    Señuelo
}


public enum Level_type
{
    Silver,
    Golden
}
