using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEditor : MonoBehaviour //Clase para desactivar y activar colliders
{
    public static bool colliderSupport; //Permite que la pausa desactive todos los colliders sin que el metodo Update() los ponga al insatnte.
    private static void ToggleColliders(bool isActive)
    {
        colliderSupport = true;
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
    public static void StaticDisableAllColliders()
    {
        ToggleColliders(false);
    }

    public void EnableAllColliders()
    {
        ToggleColliders(true);
    }

    public static void DisablePlayerCollider()
    {
        colliderSupport = false;
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
