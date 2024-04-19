using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pref_WeatherCard : MonoBehaviour
{
    public WeatherCard weatherCard;

    public static implicit operator Pref_WeatherCard(Card v)
    {
        throw new NotImplementedException();
    }
}
