using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabClick : MonoBehaviour
{

    private void OnMouseDown()
    {
        Debug.Log("Se hizo click en la carta");
        GameObject cardGameObject = this.gameObject;
        Unit_card card = cardGameObject.GetComponent<Unit_card>();
        if (card.Faction == eFaction.Oblivion)
        {
            Debug.Log("jeje");
        }
        
    }
}
