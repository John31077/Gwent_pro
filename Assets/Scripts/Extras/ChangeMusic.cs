using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioSource menu;
    public AudioSource lore;
    public AudioSource pressButton;
    public AudioSource oblivionCombat;
    public AudioSource empireCombat;
    public AudioSource tabernCombat;
    public Sprite oblivion;
    public Sprite empire;
    public Sprite tabern;

    public void CambiarMusicaMenuToLore()
    {
        StartCoroutine(CambiarMusicaMenuLore());
    }
    public void CambiarMusicaLoreToMenu()
    {
        StartCoroutine(CambiarMusicaLoreMenu());
    }

    IEnumerator CambiarMusicaMenuLore()
    {
        while (menu.volume > 0)
        {
            menu.volume -= Time.deltaTime;
            yield return null;
        }

        menu.Stop();

        lore.Play();

        while (lore.volume < 1)
        {
            lore.volume += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator CambiarMusicaLoreMenu()
    {
        while (lore.volume > 0)
        {
            lore.volume -= Time.deltaTime;
            yield return null;
        }

        lore.Stop();

        menu.Play();

        while (menu.volume < 1)
        {
            menu.volume += Time.deltaTime;
            yield return null;
        }
    }

    public void PressButtonSound()
    {
        pressButton.Play();
    }

    public void ActivateCombatMusic()
    {
        if (GameObject.Find("Table").GetComponent<SpriteRenderer>().sprite == oblivion)
        {
            oblivionCombat.Play();
        }
        if (GameObject.Find("Table").GetComponent<SpriteRenderer>().sprite == empire)
        {
            empireCombat.Play();
        }
        if (GameObject.Find("Table").GetComponent<SpriteRenderer>().sprite == tabern)
        {
            tabernCombat.Play();
        }
    }
}
