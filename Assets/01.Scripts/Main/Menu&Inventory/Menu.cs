using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MenuButton;
    public GameObject MenuBoard;
    private GameObject Mary;

    private Image MenuPan;
 

    private bool activiated;

    private Vector3 roomVector = new Vector3(-7, -6.2f, 0);

    public void Start()
    {
        MenuButton = GameObject.Find("MenuButton");
        MenuButton.SetActive(true);

        MenuBoard = GameObject.Find("Menu");
        MenuBoard.SetActive(false);

        Mary = GameObject.FindGameObjectWithTag("Mary");

        MenuPan = MenuBoard.GetComponent<Image>();
        MenuPan.gameObject.SetActive(false);
        activiated = false;
       
    }

    public void MenuON()
    {
        activiated = true;
        MenuButton.SetActive(false);
        MenuBoard.SetActive(true);
        MenuPan.gameObject.SetActive(activiated);
       // Mary.GetComponent<Controll>().gameObject.SetActive(false);
       
        Mary.GetComponent<Controll>().menuON = false;
    }

    public void MenuOFF()
    {
        activiated = false;
        MenuButton.SetActive(true);
      
          Debug.Log(MenuButton.activeSelf);
          MenuPan.gameObject.SetActive(activiated);
     
    //     Mary.GetComponent<Controll>().gameObject.SetActive(true);

        Mary.GetComponent<Controll>().menuON = true;
        MenuBoard.SetActive(false);
    }

    public void MoveToMain()
    {
        Destroy(GameObject.Find("Mary"));
        SceneManager.LoadScene("MainMenu");
    }

    public void MoveToRoom()
    {
        SceneManager.LoadScene("MaryRoom");


        //Mary.GetComponent<Controll>().gameObject.SetActive(true);
        Mary.GetComponent<Controll>().menuON = true;
        Mary.GetComponent<Transform>().position = roomVector;
    }

    public void Exit()
    {
        Application.Quit();
    }




}