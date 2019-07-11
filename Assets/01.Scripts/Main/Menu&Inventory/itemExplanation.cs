using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemExplanation : MonoBehaviour
{
    public string txtFile;
    private Text txt;

    private int count = 0;
    private GameObject itemText;
    List<Dictionary<string, object>> itemCSV;


    public void showItemText(int GetorSet, string itemName)
    {
        itemText = GameObject.Find("ItemTalker");
        itemCSV = CSVReader.Read(txtFile);
        txt = itemText.GetComponent<Text>();
        if (GetorSet == 1)
        {
            showItemGet(itemName);
        }
        if (GetorSet == 2)
        {
            showItemUSe(itemName);
        }
        count = 0;
    }

    public string readItemExplanantion(string itemName)
    {
        print(1);
        string temp1 = ""; 
        for (; count < itemCSV.Count; count++)
        {
            if (itemName == (string)itemCSV[count]["itemCode"])
            {
                temp1 = (string)itemCSV[count]["explanation"];
            }
        }
        count = 0;
        return temp1;
    }

    void showItemGet(string itemName)
    {
        for (; count < itemCSV.Count; count++)
        {
            if (itemName == (string)itemCSV[count]["itemCode"])
            {
                string ment = (string)itemCSV[count]["name"] + "를 얻었습니다!";
                txt.text = ment;
                StartCoroutine(delayTime());
            }
        }
    }

    void showItemUSe(string itemName)
    {
        for (; count < itemCSV.Count; count++)
        {
            if (itemName == (string)itemCSV[count]["itemCode"])
            {
                txt.text = (string)itemCSV[count]["name"] + "를 사용했습니다!";
                StartCoroutine(delayTime());
            }
        }
    }

    IEnumerator delayTime()
    {
        yield return new WaitForSeconds(3);
        txt.text = "";
    }
}
