using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Begin : MonoBehaviour
{
    [SerializeField]private List<Card> Deck_Empire;
    [SerializeField]private List<Card> Deck_Oblivion;
    public DeckList destinationP1;
    public DeckList destinationP2;
    public GameObject warning;
    public GameObject deckSelection;
    public GameObject LeaderSelection;
    public Button P1_Leader1;
    public Button P1_Leader2;
    public Button P1_Leader3;
    public Button P2_Leader1;
    public Button P2_Leader2;
    public Button P2_Leader3;
    public Sprite Dagon;
    public Sprite Sheo;
    public Sprite Bal;
    public Sprite Emeric;
    public Sprite Talos;
    public Sprite Mede;
    public LeaderSection P1_LeaderCard;
    public LeaderSection P2_LeaderCard;
    public LeaderCard emeric_LC;
    public LeaderCard talos_LC;
    public LeaderCard mede_LC;
    public LeaderCard dagon_LC;
    public LeaderCard sheo_LC;
    public LeaderCard bal_LC;










    public void AplyDeckOblivionP1()
    {
        destinationP1.DeckSO.Clear();
        destinationP1.DeckSO.AddRange(Deck_Oblivion);
    }
    public void AplyDeckEmpireP1()
    {
        destinationP1.DeckSO.Clear();
        destinationP1.DeckSO.AddRange(Deck_Empire);
    }
    public void AplyDeckOblivionP2()
    {
        destinationP2.DeckSO.Clear();
        destinationP2.DeckSO.AddRange(Deck_Oblivion);
    }
    public void AplyDeckEmpireP2()
    {
        destinationP2.DeckSO.Clear();
        destinationP2.DeckSO.AddRange(Deck_Empire);
    }
    public void Continue()
    {
        
        if (destinationP1.DeckSO.Count == 0 || destinationP2.DeckSO.Count == 0)
        {
            warning.SetActive(true);
        }
        else
        {
            deckSelection.SetActive(false);
            LeaderSelection.SetActive(true);
        }
    }

    public void RefreshLeaders()
    {
        foreach (Card card in destinationP1.DeckSO)
        {
            if (card.Faction == eFaction.Oblivion)
            {
                P1_Leader1.image.sprite = Bal;
                P1_Leader2.image.sprite = Sheo;
                P1_Leader3.image.sprite = Dagon; 
                break;
            }
            if (card.Faction == eFaction.Empire)
            {
                P1_Leader1.image.sprite = Emeric;
                P1_Leader2.image.sprite = Talos;
                P1_Leader3.image.sprite = Mede;
                break;
            }
        }
        foreach (Card card in destinationP2.DeckSO)
        {
            if (card.Faction == eFaction.Oblivion)
            {
                P2_Leader1.image.sprite = Bal;
                P2_Leader2.image.sprite = Sheo;
                P2_Leader3.image.sprite = Dagon; 
                break;
            }
            if (card.Faction == eFaction.Empire)
            {
                P2_Leader1.image.sprite = Emeric;
                P2_Leader2.image.sprite = Talos;
                P2_Leader3.image.sprite = Mede;
                break;
            }
        }
        
    }

    public void ChooseLeader1()
    {
        if (P1_Leader1.image.sprite == Emeric)
        {
            P1_LeaderCard.leader = emeric_LC;
        }
        else
        {
            P1_LeaderCard.leader = bal_LC;
        }
        if (P2_Leader1.image.sprite == Emeric)
        {
            P2_LeaderCard.leader = emeric_LC;
        }
        else
        {
            P2_LeaderCard.leader = bal_LC;
        }
    }
    public void ChooseLeader2()
    {
        if (P1_Leader2.image.sprite == Talos)
        {
            P1_LeaderCard.leader = talos_LC;
        }
        else
        {
            P1_LeaderCard.leader = sheo_LC;
        }
        if (P2_Leader2.image.sprite == Talos)
        {
            P2_LeaderCard.leader = talos_LC;
        }
        else
        {
            P2_LeaderCard.leader = sheo_LC;
        }
    }
     public void ChooseLeader3()
    {
        if (P1_Leader3.image.sprite == Mede)
        {
            P1_LeaderCard.leader = mede_LC;
        }
        else
        {
            P1_LeaderCard.leader = dagon_LC;
        }
        if (P2_Leader3.image.sprite == Mede)
        {
            P2_LeaderCard.leader = mede_LC;
        }
        else
        {
            P2_LeaderCard.leader = dagon_LC;
        }
    }
}