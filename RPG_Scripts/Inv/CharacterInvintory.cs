using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterInvintory : SingleTon<CharacterInvintory>
{

    public CharacterStats charStats;

    public Image[] hotbarDisplay = new Image[4];
    public GameObject inventoryDisplay;
    public Image[] inventoryDisplaySlots = new Image[30];

    int inventoryItemCap = 20;
    int idCount = 1;
    bool addedItem = true;

    public Dictionary<int, InventoryEntry> itemsInventory = new Dictionary<int, InventoryEntry>();
    public InventoryEntry itemEntry;


    private void Start()
    {
        itemEntry = new InventoryEntry(0, null, null);
        itemsInventory.Clear();

        inventoryDisplaySlots = inventoryDisplay.GetComponentsInChildren<Image>();

        charStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
    }

    public void StoreItem(ItemPickUp ItemToStore)
    {
        addedItem = false;

        if((charStats.characterDefinition.currentEncumbrance + ItemToStore.itemDefinition.itemWeight) <= charStats.characterDefinition.maxEncumbrance)
        {
            itemEntry.invEntry = ItemToStore;
            itemEntry.stackSize = 1;
            itemEntry.hbSprite = ItemToStore.itemDefinition.itemIcon;

            ItemToStore.gameObject.SetActive(false);
        }
    }

}
