using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 줌인과 줌아웃을 관리하는 스크립트
/// </summary>
public class ZoomInOut : MonoBehaviour
{
    private Camera cameraZoom; // 카메라 오브젝트
    public float cameraSizePlus; // 카메라 사이즈 조절
    public float cameraSizeMinus;
    public float cameraSpeed = 0.5f; // 카메라 줌인/아웃 속도
    public bool isZoomIn;
    public bool isZoomOut; // 기본적으로 두개의 bool 값으로 조정 -> 기본 화면에서 더 큰 화면으로 줌아웃 가능 혹은 줌인 장면에서 더 크게 줌인 가능

    // Start is called before the first frame update
    void Start()
    {
        cameraZoom = GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {

        if (isZoomIn && cameraZoom.orthographicSize > cameraSizePlus) 
        {
            cameraZoom.orthographicSize = Mathf.Lerp(cameraZoom.orthographicSize, cameraSizePlus, Time.deltaTime / cameraSpeed); // 줌인

        }
        else if (isZoomOut && cameraZoom.orthographicSize < cameraSizeMinus)
        {
            cameraZoom.orthographicSize = Mathf.Lerp(cameraZoom.orthographicSize, cameraSizeMinus, Time.deltaTime / cameraSpeed); // 줌아웃
        }
    }
}