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
}
