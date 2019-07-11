using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvetorySystem : MonoBehaviour
{
    static public InvetorySystem instance;

    private InventorySlot[] slots; //슬롯들

    public List<Item> itemList;

    public Transform tf; //부모 객체

    public GameObject Inventory;
    public GameObject InventoryButton;
    public Text itemDescription; //아이템 설명

    public GameObject[] selectedItemImages;
    public int selectedItem;
    
    private GameObject Mary;
    private bool invenActive;  //활성화 비활성화



    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    private void Start()
    {
        //theAudio = FindObjectOfType<AudioManager>();
        itemList = new List<Item>();
        slots = tf.GetComponentsInChildren<InventorySlot>();
        InventoryButton = GameObject.Find("InvenButton");
        InventoryButton.SetActive(true);
        invenActive = false;
        Inventory = GameObject.Find("Inventory");
        Inventory.SetActive(false);
       // itemDescription = GameObject.Find("Descritpion_text").GetComponent<Text>();
        Mary = GameObject.FindGameObjectWithTag("Mary");
    }

    private void RemoveSlots()
    {
        for(int i = 0; i<slots.Length; i++)
        { 
            slots[i].removeItem();
            slots[i].gameObject.SetActive(false);
        }
    }

    public void ShowItems()
    {
        RemoveSlots();
        selectedItem = 0;

        for(int i = 0; i < itemList.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].addItem(itemList[i]);
            slots[i].check.gameObject.SetActive(false);
        }
    }


    public void SelectItem()
    {
        
        Color color = slots[0].selected.GetComponent<Image>().color;
        color.a = 0f;

        for(int i = 0; i < itemList.Count; i++)
        {
            slots[i].selected.GetComponent<Image>().color = color;
        }
        itemDescription = slots[0].itemDiscription;
    }

    public void InvenON()
    {

        ShowItems();
        invenActive = true;
        Inventory.SetActive(true);
        InventoryButton.SetActive(false);
        itemDescription.text = "";
        Mary.GetComponent<Controll>().menuON = false;
    }

    public void InvenOFF()
    {
        invenActive = false;
        Inventory.SetActive(false);
        InventoryButton.SetActive(true);
        Mary.GetComponent<Controll>().menuON = true;
    }

    //소리 관련 변수들

    //private AudioManager theAudio;
    //public string keySound;
    //public string enterSound;
    //public string cancelSound;
    //public string openSound;
    //public string beepSound;


}
