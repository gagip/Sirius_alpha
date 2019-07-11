using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text itemName;
    public Text itemDiscription;
    public GameObject selected;
    public GameObject check;
    public GameObject discriptionBlock;

    public void addItem(Item item)
    {
        icon.sprite = item.itemIcon;
        itemName.text = item.itemName;
    //    itemDiscription.text = item.itemDiscription;
    }

    public void removeItem()
    {
        itemName.text = "";
        icon.sprite = null;
    }

    public void selectedItem()
    {
        check.gameObject.SetActive(true);
        discriptionBlock = GameObject.Find("Descritpion_text");
        discriptionBlock.GetComponent<Text>().text = itemDiscription.ToString();
    }
}
