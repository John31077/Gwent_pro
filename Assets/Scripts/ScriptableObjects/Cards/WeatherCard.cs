using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weather Card", menuName = "Weather Card")]
public class WeatherCard : Card
{
    public eTypeOfWheather wheatherType;

    public enum eTypeOfWheather
    {
        Sunny,
        Rain,
        Fog,
        Frost
    }
}
