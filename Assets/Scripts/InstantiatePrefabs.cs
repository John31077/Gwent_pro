using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabs : MonoBehaviour
{
    public GameObject UnitCardPrefab;
    public GameObject InstUnitCardPrefab;
    public GameObject WeatherCardPrefab;
    public GameObject InstWeatherCardPrefab;
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
                CardsGameObject.Real_Cards.Add(InstUnitCardPrefab);
            }
            if (card is WeatherCard)
            {
                InstWeatherCardPrefab = Instantiate(WeatherCardPrefab, new Vector3(-208f,-152f,0), Quaternion.identity);
                InstWeatherCardPrefab.name = card.Tittle;
                SpriteRenderer spriteRenderer = InstWeatherCardPrefab.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = card.Image;
                CardsGameObject.Real_Cards.Add(InstWeatherCardPrefab);
            }
        }
    }
}
