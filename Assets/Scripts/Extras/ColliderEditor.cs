using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEditor : MonoBehaviour //Clase para desactivar y activar colliders
{
    private void ToggleColliders(bool isActive)
    {
        Collider[] colliders = FindObjectsOfType<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = isActive;
        }
    }

    public void DisableAllColliders()
    {
        ToggleColliders(false);
    }

    public void EnableAllColliders()
    {
        ToggleColliders(true);
    }

    public static void DisablePlayerCollider()
    {
        string fatherName;
        if (GameManager.playerTurn) fatherName = "Player1";
        else fatherName = "Player2";

        Transform fatherObject = GameObject.Find(fatherName).transform;
        Collider[] colliders = fatherObject.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
    }
    public static void EnablePlayerCollider()
    {
        string fatherName;
        if (GameManager.playerTurn) fatherName = "Player2";
        else fatherName = "Player1";

        Transform fatherObject = GameObject.Find(fatherName).transform;
        Collider[] colliders = fatherObject.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
    }
}
