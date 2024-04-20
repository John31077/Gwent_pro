using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PrefabOnMouseEnter : MonoBehaviour
{
    void OnMouseEnter()
    {
        GameObject card = this.gameObject;
        GameObject icon = GameObject.Find("Icon");
        GameObject text = GameObject.Find("Description");
        if (card.GetComponent<PreF_UnitCard>() != null)
        {
            icon.GetComponent<SpriteRenderer>().sprite = card.GetComponent<PreF_UnitCard>().unit_Card.Image;
            text.GetComponent<TextMeshPro>().text = card.GetComponent<PreF_UnitCard>().unit_Card.Effect_description;
        }
        else if (card.GetComponent<Pref_WeatherCard>() != null)
        {
            icon.GetComponent<SpriteRenderer>().sprite = card.GetComponent<Pref_WeatherCard>().weatherCard.Image;
            text.GetComponent<TextMeshPro>().text = card.GetComponent<Pref_WeatherCard>().weatherCard.Effect_description;
        }
        else if (card.GetComponent<LeaderSection>() != null)
        {
            icon.GetComponent<SpriteRenderer>().sprite = card.GetComponent<SpriteRenderer>().sprite;
            text.GetComponent<TextMeshPro>().text = card.GetComponent<LeaderSection>().leader.Effect_description;
        }
        else if (card.GetComponent<Pref_HornOrFireCard>() != null)
        {
            icon.GetComponent<SpriteRenderer>().sprite = card.GetComponent<Pref_HornOrFireCard>().card.Image;
            text.GetComponent<TextMeshPro>().text = card.GetComponent<Pref_HornOrFireCard>().card.Effect_description;
        }
    }
}
 