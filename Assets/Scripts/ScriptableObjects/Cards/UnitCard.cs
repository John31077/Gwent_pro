using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Card", menuName = "Unit Card")]
public class Unit_card : Card
{
    [SerializeField]private int Power;
    [SerializeField]private Attack_type AType;
    [SerializeField]private Level_type LType;
}
public enum Attack_type
{
    Melee,
    Range,
    Siege
}


public enum Level_type
{
    Silver,
    Golden
}
