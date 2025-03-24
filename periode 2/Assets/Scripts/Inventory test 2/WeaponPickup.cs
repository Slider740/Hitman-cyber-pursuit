using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Inventory inventory; // Reference to the inventory script
    public KeyCode pickupKey = KeyCode.E;

    public void Start()
    {
        if (inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
        }

        if (inventory == null)
        {
            Debug.LogError("inventory script not found in scene");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Log when the player enters the trigger
        Debug.Log("Player is near the weapon.");

        if (other.CompareTag("Player") && Input.GetKeyUp(pickupKey))
        {
            Weapon weapon = GetComponent<Weapon>();
            if (inventory != null)
            {
                inventory.Additem(weapon);
                gameObject.SetActive(false);
            }

        }
    }
}
