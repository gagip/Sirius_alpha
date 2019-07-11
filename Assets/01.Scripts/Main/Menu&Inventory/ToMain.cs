using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToMain : MonoBehaviour
{
    public void MoveToMain()
    {
        Destroy(GameObject.Find("Mary"));
        Destroy(GameObject.Find("Main Camera"));
        SceneManager.LoadScene("MainMenu");
    }
}
