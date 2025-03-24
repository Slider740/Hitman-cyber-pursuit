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
    }

    private void OnTriggerStay(Collider other)
    {
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
