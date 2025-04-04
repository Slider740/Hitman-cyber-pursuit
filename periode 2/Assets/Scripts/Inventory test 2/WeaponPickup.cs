using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Inventory inventory; // Reference to the inventory script
    public KeyCode pickupKey = KeyCode.E; //refers to E

    public void Start()
    {
        if (inventory == null) //checks if the inventory is equal to zero
        {
            inventory = FindObjectOfType<Inventory>(); //if there is no inventory assigned in the inspector, it will search for a something eqaul to inventory
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyUp(pickupKey)) //checks for tag 'Player' and checks for input of the 'pickupkey'
        {
            Weapon weapon = GetComponent<Weapon>(); //uses the script 'Weapon'
            if (inventory != null) //checks if the inventory is equal to zero
            {
                inventory.Additem(weapon); //adds the weapon to the inventory
                gameObject.SetActive(false); //sets the weapon inactive in the world space
            }

        }
    }
}
