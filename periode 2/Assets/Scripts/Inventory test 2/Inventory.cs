using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    public List <Weapon> items = new List <Weapon> ();
    public GameObject inventoryUI;
    public Transform playerHand; //Reference to the players hand transform
    private bool isInventoryOpen = false;
    public Inventory inventory;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Tab))
        {
            isInventoryOpen = !isInventoryOpen;
            inventoryUI.SetActive(isInventoryOpen);
        }
    }

    public void Additem(Weapon weapon)
    {
        items.Add (weapon);
        UpdateInventoryUI();
        Debug.Log(weapon.weaponName + "added to inventory");
    }

    public void EquipWeapon(Weapon weapon)
    {
        GameObject equippedWeapon = Instantiate(weapon.gameObject, playerHand.position, playerHand.rotation, playerHand);
        equippedWeapon.SetActive(true);
        Debug.Log(weapon.weaponName + "equipped!");
    }

    public void RemoveItem(Weapon weapon)
    {
        items.Remove(weapon);
        UpdateInventoryUI();
        Debug.Log(weapon.weaponName + "removed from inventory");
    }

    public void UpdateInventoryUI()
    {
        foreach (Transform child in inventoryUI.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Weapon weapon in items)
        {
            GameObject newItem = new GameObject();
            newItem.transform.SetParent(inventoryUI.transform);

            var button = newItem.AddComponent<UnityEngine.UI.Button>();
            newItem.AddComponent<UnityEngine.UI.Image>().sprite = weapon.weaponIcon;

            button.onClick.AddListener(() => EquipWeapon (weapon));
        }
    }
}
