using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabs : MonoBehaviour
{
    public GameObject UnitCardPrefab;
    public GameObject InstUnitCardPrefab;
    public GameObject WeatherCardPrefab;
    public GameObject InstWeatherCardPrefab;
    public GameObject HornOrFirePrefab;
    public GameObject InstHornOrFirePrefab;
    public DeckList deckList;
    public RealDeck CardsGameObject;
    

    public void InstantiatePrefab()
    {
        foreach (Card card in deckList.DeckSO)
        {
            if (card is Unit_card)
            {
                InstUnitCardPrefab = Instantiate(UnitCardPrefab, new Vector3(-208f,-152f,0), Quaternion.identity);
                InstUnitCardPrefab.name = card.Tittle;
                SpriteRenderer spriteRenderer = InstUnitCardPrefab.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = card.Image;
                PreF_UnitCard preF_UnitCard = InstUnitCardPrefab.GetComponent<PreF_UnitCard>();
                preF_UnitCard.unit_Card = (Unit_card)card;
                CardsGameObject.Real_Cards.Add(InstUnitCardPrefab);
                InstUnitCardPrefab.transform.SetParent(CardsGameObject.transform);
            }
            else if (card is WeatherCard)
            {
                InstWeatherCardPrefab = Instantiate(WeatherCardPrefab, new Vector3(-208f,-152f,0), Quaternion.identity);
                InstWeatherCardPrefab.name = card.Tittle;
                SpriteRenderer spriteRenderer = InstWeatherCardPrefab.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = card.Image;
                Pref_WeatherCard pref_WeatherCard = InstWeatherCardPrefab.GetComponent<Pref_WeatherCard>();
                pref_WeatherCard.weatherCard = (WeatherCard)card;
                CardsGameObject.Real_Cards.Add(InstWeatherCardPrefab);
                InstWeatherCardPrefab.transform.SetParent(CardsGameObject.transform);
            }
            else if (card is Card)
            {
                InstHornOrFirePrefab = Instantiate(HornOrFirePrefab, new Vector3(-208f,-152f,0), Quaternion.identity);
                InstHornOrFirePrefab.name = card.Tittle;
                SpriteRenderer spriteRenderer = InstHornOrFirePrefab.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = card.Image;
                Pref_HornOrFireCard pref_HornOrFireCard= InstHornOrFirePrefab.GetComponent<Pref_HornOrFireCard>();
                pref_HornOrFireCard.card = card; //Casteo redundante
                CardsGameObject.Real_Cards.Add(InstHornOrFirePrefab);
                InstHornOrFirePrefab.transform.SetParent(CardsGameObject.transform);
            }
        }
        ShuffleScript.Shuffle<GameObject>(CardsGameObject.Real_Cards);
    }    
    
}


