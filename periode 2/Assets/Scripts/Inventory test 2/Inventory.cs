using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    public List <Weapon> items = new List <Weapon> (); //list of all items in the inventory
    public GameObject inventoryUI; //Reference to the inventory's UI
    public Transform playerHand; //Reference to the players hand transform
    private bool isInventoryOpen = false; //checks if the inventory is open

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Tab))
        {
            isInventoryOpen = !isInventoryOpen; //checks if the inventory is open
            inventoryUI.SetActive(isInventoryOpen); //activates the inventory UI
        }
    }

    public void Additem(Weapon weapon)
    {
        items.Add (weapon); //adds the item to the inventory list
        UpdateInventoryUI(); //updates the inventory UI
    }

    public void EquipWeapon(Weapon weapon)
    {
        GameObject equippedWeapon = Instantiate(weapon.gameObject, playerHand.position, playerHand.rotation, playerHand); //places weapon in the 'hand' object
        equippedWeapon.SetActive(true); //sets the weapon active in the world space
    }

    public void RemoveItem(Weapon weapon)
    {
        items.Remove(weapon); //removes the item from the inventory list
        UpdateInventoryUI(); //updates the inventory UI
    }

    //Updates the inventory UI
    public void UpdateInventoryUI()
    {
        //places the weapon sprite in the inventory UI
        foreach (Transform child in inventoryUI.transform)
        {
            Destroy(child.gameObject); //deletes the weapon from world space
        }
        //every weapon gets added to the Items list
        foreach (Weapon weapon in items)
        {
            GameObject newItem = new GameObject();
            newItem.transform.SetParent(inventoryUI.transform); //sets the parent of the newitem

            var button = newItem.AddComponent<UnityEngine.UI.Button>(); //creates button from weapon sprite
            newItem.AddComponent<UnityEngine.UI.Image>().sprite = weapon.weaponIcon; //uses the weapon sprite for the button

            button.onClick.AddListener(() => EquipWeapon (weapon)); //makes the button interactable
        }
    }
}
