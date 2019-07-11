using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 대화 이외의 대사를 출력할 때 사용하는 스크립트
/// 인트로 씬 위주로 사용
/// </summary>

[System.Serializable]
public class EventDialogueTextPosion
{
    public Vector3 txtPlayer = new Vector3(-150.0f, 200.0f, 0.0f); // 플레이어 쪽 텍스트 위치
    public Vector3 txtNPC = new Vector3(150.0f, 200.0f, 0.0f);// NPC 쪽 텍스트 위치
}


public class EventDialogueSystem : MonoBehaviour
{

    // 텍스트 UI를 연동하기 위한 변수
    public Scene1DataBase scene1DB; // scene1에 필요한 데이터 추출
    private Image dialogueBox; // 텍스트 상자
    private Text txt; // 텍스트 오브젝트
    [SerializeField] private Image panel; // 대화 중 다른 기능 금지
    [SerializeField] private GameObject dialogueUI;   // 대화 UI

    // 인게임 대화에 필요한 변수
    public int count = 0; // 텍스트 문서 단위
    public bool talking = false; // 텍스트 UI 활성화 트리거
    public bool allText = false; // 전체 문장이 출력되면 true
    private string text; // 
    Coroutine coroutine; // 한 글자 출력 코루틴

    // 텍스트 위치에 필요한 변수 
    public bool setTextPosition; // 사용자 정의 위치로 설정
    public EventDialogueTextPosion eventDialogueTextPosion;
    Vector3 txtPlayer; // 플레이어 쪽 텍스트 위치
    Vector3 txtNPC; // NPC 쪽 텍스트 위치
    
    public List<Dictionary<string, object>> dialogueData;

    public Scene1Manager scene1Manager;

    void Start()
    {
        scene1Manager = FindObjectOfType<Scene1Manager>();
        scene1DB = scene1Manager.scene1DB[scene1Manager.process];
        dialogueData = CSVReader.Read(scene1DB.textFile);
        

        dialogueUI = GameObject.Find("Dialogue UI");
        dialogueBox = dialogueUI.transform.Find("Dialogue Box").GetComponent<Image>();
        txt = dialogueBox.transform.Find("Dialogue Text").GetComponent<Text>();
        panel = dialogueUI.transform.Find("Dialogue Panel").GetComponent<Image>();
    }

    // Dialogue UI 활성화 스위치
    private void OnOff(bool _flag)
    {
        //panel.gameObject.SetActive(_flag);
        dialogueBox.gameObject.SetActive(_flag);
        txt.gameObject.SetActive(_flag);
    }

    // 대화를 시작하고 Dialogue UI를 활성화한다.
    public void ShowDialogue()
    {
        SetDialoguePosition();
        OnOff(true);
        count = 0;
        talking = true;
        PrintText();
    }

    // 대화를 종료하고 Dialogue UI를 종료한다.
    public void HideDialogue()
    {
        OnOff(false);
        talking = false;
    }

    // 이전 대화로 되돌아가는 함수
    public void PreviousDialogue()
    {
        count -= 2;
        PrintText();
    }


    // 다음 대화로 넘어간다.
    private void NextDialogue()
    {
        count++;
        PrintText();
    }

    private void SetDialoguePosition()
    {
        txtPlayer = eventDialogueTextPosion.txtPlayer;
        txtNPC = eventDialogueTextPosion.txtNPC;
    }

    // 한 글자씩 출력한다
    IEnumerator ShowText(string fulltext)
    {
        for (int i = 0; i <= fulltext.Length; i++)    // 글자 하나하나씩 출력
        {
            string currentText = fulltext.Substring(0, i);
            txt.text = currentText;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        allText = true;
    }

    // 텍스트 출력
    private void PrintText()
    {
        ChangeText();
        text = (string)dialogueData[count]["dialog"];
        if (!allText) // 한글자씩 출력
        {
            coroutine = StartCoroutine(ShowText(text));
        }
        else // 한글자 출력이 완료되었으면
        {
            txt.text = text;
        }
    }

    // 캐릭터별 폰트 스타일과 텍스트 위치를 설정한다.
    public void ChangeText()
    {
        if ((int)dialogueData[count]["name"] == 1) // 메리
        {
            txt.color = Color.white;
            dialogueBox.GetComponent<RectTransform>().localPosition = txtPlayer;
        }
        if ((int)dialogueData[count]["name"] == 2) // 메들록
        {
            txt.color = Color.red;
            dialogueBox.GetComponent<RectTransform>().localPosition = txtNPC;
        }
        if ((int)dialogueData[count]["name"] == 3) // 마샤
        {
            txt.color = Color.blue;
            dialogueBox.GetComponent<RectTransform>().localPosition = txtNPC;
        }
    }

    public void Talk()
    {
        if (Input.GetMouseButtonUp(0))  // 출력완료한 상태에서 버튼 클릭
        {
            if (count < dialogueData.Count - 1)
            {
                if (allText == true) // 한글자씩 출력을 완료
                {
                    allText = false;
                    NextDialogue();
                }
                else
                {
                    StopCoroutine(coroutine);
                    allText = true;
                    PrintText();
                }
            }
            else // 대화 끝날 시
                if (allText == true) HideDialogue();
        }
    }


    void Update()
    {
        if (talking) // 대화중
        {
            Talk();
        }
    }
}
