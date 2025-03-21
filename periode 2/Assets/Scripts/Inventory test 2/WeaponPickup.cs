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
            Debug.Log("E key pressed."); // Log when the E key is detected

            Weapon weapon = GetComponent<Weapon>();
            if (weapon != null)
            {
                Debug.Log("Weapon found: " + weapon.weaponName); // Log the weapon's name
            }
            else
            {
                Debug.LogError("Weapon script is missing on this GameObject!"); // Log if the Weapon script is missing
            }

            if (inventory != null)
            {
                inventory.Additem(weapon);
                gameObject.SetActive(false);
                Debug.Log("Weapon added to inventory."); // Log when the weapon is added to the inventory
            }
            else
            {
                Debug.LogError("Inventory reference is missing!"); // Log if the Inventory reference is not set
            }
        }
    }
}
