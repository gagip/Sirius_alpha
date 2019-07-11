using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MartInventory : MonoBehaviour
{
    private List<Item> list;
    string itemName = "";

    private GameObject itemMent;
    private GameObject inventory;
    private Item tempItem;

    private void Start()
    {
        inventory = GameObject.Find("Inventory_UI");
        list = inventory.GetComponent<InvetorySystem>().itemList;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        itemName = collision.name;
        itemMent = GameObject.Find("ItemTalker");
        print(collision.name);
        if (collision.tag == "item")
        {
            itemMent.GetComponent<itemExplanation>().showItemText(1, itemName);

            tempItem = new Item();
            tempItem.itemName = collision.name;
            tempItem.itemIcon = collision.GetComponent<SpriteRenderer>().sprite;
            tempItem.itemDiscription = itemMent.GetComponent<itemExplanation>().readItemExplanantion(itemName);

            list.Add(tempItem);
            Destroy(GameObject.Find(itemName));
        }
        else
        {
            Debug.Log(collision.name);
        }
    }
}
