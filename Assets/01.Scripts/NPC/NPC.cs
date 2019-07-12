using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
object와 mary가 상호작용 가능한 거리에 있을 때 상호작용 박스 생성
*/
public class NPC : MonoBehaviour
{
    private Transform button;   //상호작용을 위한 버튼
    public bool isWathcing; // 메리를 쳐다보게 하는 변수
    public bool isMoving;   // 움직이는 NPC
    public bool isEvent;    // 이벤트 씬에서 사용

    public float speed = 3.0f; // NPC 이동 속도
    private Vector3 initpos; // NPC의 초기 위치
    private Vector3 targetpos; // NPC를 이동시킬 위치
    public float dist = 5.0f;
    private bool direct = true; // NPC의 이동 방향

    private AudioManager theAudio;  //사운드 재생
    private Animator animator;   // 애니메이션 동작을 위한 선언  

    private void OnTriggerStay2D(Collider2D col)    // mary가 상호작용 가능 범위 일 때
    {
        if (col.tag == "Mary")
        {
            if (isWathcing) // NPC가 메리를 쳐다보게 함
            {
                if (col.GetComponent<Transform>().position.x - 1 > gameObject.transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (col.GetComponent<Transform>().position.x + 1 < gameObject.transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
            }
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        // Moving NPC를 위한 변수 정의
        initpos.x = transform.position.x;
        targetpos.x = initpos.x + dist;
        animator = gameObject.GetComponent<Animator>(); // animator component를 받아옴

        theAudio = FindObjectOfType<AudioManager>();    // 사운드 매니저

        if (isMoving)   // 움직이는 NPC의 경우 움직이도록 초기화
        {
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isIdle", true);
        }
    }

    private void Walk()
    {
        if (animator.GetBool("isIdle"))     // 멈춘 애니메이션이면 움직이도록 설정
        {
            animator.SetBool("isIdle", false);
        }

        float targetDis = targetpos.x - transform.position.x; // 타겟까지의 남은 거리
        float initDis = transform.position.x - initpos.x; // 시작 위치부터의 현위치까지의 거리
        if (targetDis < 0 || initDis < 0)  // 원위치-타켓위치 범위를 벗어나면 방향을 바꿈
        {
            if (direct)
            {
                direct = false;
            }
            else
            {
                direct = true;
            }
        }
        if (direct)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    
    public void EventWalk()
    {
        animator.SetBool("isEventIdle", false); // Event 애니메이션 실행
        theAudio.Play("walkingHouse");  // sound on
    }

    public void EventStop()
    {
        animator.SetBool("isEventIdle", true); // idle 애니메이션 실행
        theAudio.Stop("walkingHouse");  // sound off
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (EventSystem.current.IsPointerOverGameObject() == true)
            {
                if (!animator.GetBool("isIdle"))     // 멈춘 애니메이션이면 움직이도록 설정
                {
                    animator.SetBool("isIdle", true);
                }
                return;
            }// UI창 나오면 안움직임

            Walk();
        }

    }


}
