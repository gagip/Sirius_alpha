using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 게임 데이터 저장
public class GameData : MonoBehaviour
{
    public List<string> accessibleScene;

    // Start is called before the first frame update
    void Start()
    {
        accessibleScene.Add("Hall1");
        accessibleScene.Add("FrontGarden");
        accessibleScene.Add("WholeHall");
        accessibleScene.Add("MaryRoom");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
