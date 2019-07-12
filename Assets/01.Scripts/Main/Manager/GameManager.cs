using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 게임을 관리해주는 스크립트로써
/// 게임의 상태변화를 관리한다.
/// </summary>

// 게임 상태변화에 대한 리스트
[System.Serializable]
public enum GameState
{
    Evenet1,
}


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<string> accessibleScene;

    // 참조할 오브젝트를 가지고 온다
    [SerializeField] private GameObject player;

    // 참조할 스크립트를 가지고 온다

    // 참조할 데이터셋을 가지고 온다


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
        if (player == null && GameObject.FindGameObjectWithTag("Mary") != null)
            player = GameObject.FindGameObjectWithTag("Mary");
    }
}
