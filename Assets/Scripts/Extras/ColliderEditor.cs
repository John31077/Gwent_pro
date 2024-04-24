using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEditor : MonoBehaviour //Clase para desactivar y activar colliders
{
    public GameObject meleeSection1;
    public GameObject rangeSection1;
    public GameObject siegeSection1;
    public GameObject meleeSection2;
    public GameObject rangeSection2;
    public GameObject siegeSection2;

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
    public static void StaticEnableAllColliders()
    {
        ToggleColliders(true);
    }

    public static void DisablePlayerCollider()
    {
        colliderSupport = false;
        string fatherName = "";
        if (GameManager.playerTurn)
        { 
            fatherName = "Hand1";
        }
        else
        {
            fatherName = "Hand2";
        }

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
        if (GameManager.playerTurn)
        { 
            fatherName = "Hand2";
        }
        else
        {
            fatherName = "Hand1";
        }
            

        Transform fatherObject = GameObject.Find(fatherName).transform;
        Collider[] colliders = fatherObject.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
    }

    public static void SeñueloCollider(GameObject melee, GameObject range, GameObject siege)
    {
        Transform fatherObjectm = GameObject.Find(melee.name).transform;
        Collider[] colliders1 = fatherObjectm.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders1)
        {
            collider.enabled = true;
        }

        Transform fatherObjectr = GameObject.Find(range.name).transform;
        Collider[] colliders2 = fatherObjectr.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders2)
        {
            collider.enabled = true;
        }

        Transform fatherObjects = GameObject.Find(siege.name).transform;
        Collider[] colliders3 = fatherObjects.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders3)
        {
            collider.enabled = true;
        }

    }
}