using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeleportButton : MonoBehaviour
{
    public string moveScene;    //이동할 씬
    public Vector3 movePos;     //이동한 씬에서 캐릭터 위치
    private GameObject Mary;
    int i = 0;


    void Start()
    {
        Mary = GameObject.FindGameObjectWithTag("Mary");
        //movePos = new Vector3();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("MainHall");
        Mary.GetComponent<Transform>().position = movePos;
    }


    private void OnMouseDown()
    {
        ChangeScene();
    }
}
