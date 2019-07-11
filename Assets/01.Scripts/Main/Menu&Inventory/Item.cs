using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string itemName = "";
    public string itemDiscription = "";
    public Sprite itemIcon;
    public int itemNum;

    public void removeItem()
    {
        itemName = "";
        itemDiscription = "";
        itemIcon = null;
        itemNum = 0;
    }     
}

