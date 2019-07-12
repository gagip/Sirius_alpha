using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 항상 작동하면서 플레이 캐릭터를 따라가는 카메라 + CameraTargetChange.cs 로 인해 타겟이 바뀌면 타겟을 줌인하며 따라감
/// </summary>
public class DefaultCameraManager : MonoBehaviour
{
    static public DefaultCameraManager instance;

    public GameObject target; // 카메라가 따라갈 대상.

    private Vector3 targetPosition; // 대상의 현재 위치 
    private Vector3 minBound;  
    private Vector3 maxBound;

    public float adjustX;
    public float adjustY; // 카메라 높이 조절
    public float moveSpeed = 10.0f; // 카메라 속도
    private float halfWidth;
    private float halfHeight;

    public BoxCollider2D bound; // 카메라 활동 영역
    
    public Camera getCamera;

    private ZoomInOut zoomCtrl; // 줌인 줌아웃 컨트롤

    public void SetBound(BoxCollider2D newBound)
    {
        bound = newBound;
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
    }


    // Use this for initialization
    void Start()
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

        // 씬에 맞게 자동으로 할당
        if (target == null && GameObject.FindGameObjectWithTag("Mary") != null)
            target = GameObject.FindGameObjectWithTag("Mary");
        if (bound == null && GameObject.FindGameObjectWithTag("Background") != null)
            bound = GameObject.FindGameObjectWithTag("Background").GetComponent<BoxCollider2D>();

        // 각 변수 초기화
        zoomCtrl = GetComponent<ZoomInOut>();
        getCamera = GetComponent<Camera>();
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
        halfHeight = getCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;



    }


        // Update is called once per frame
        void Update()
    {

        if (target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y+adjustY, this.transform.position.z);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (zoomCtrl.isZoomOut) // 줌인 상황이 아닐때 카메라 활동 범위 제한
            {
                float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + (halfWidth + adjustX), maxBound.x - (halfWidth + adjustX));
                float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

                this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);       // clap() 함수로 영역 제한
            }
        }
    }

   
}



