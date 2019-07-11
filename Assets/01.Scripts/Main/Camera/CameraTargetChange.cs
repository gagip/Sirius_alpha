using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 응용 카메라 - isTargetChange가 True가 되면 카메라가 타겟을 바꾸면서 줌인. False가 되면 카메라는 다시 주인공을 타겟으로 하며 줌아웃.
/// 카메라를 이동시켜 비추고 싶은 오브젝트에 컴포넌트 삽입.
/// 이 컴포넌트에 필요한 컴포넌트(ZoomInOut, DefaultCameraManager)를 모두 Main Camera에 삽입후 본 스크립트의 Arguments 로 넣어줄것.
/// </summary>
public class CameraTargetChange : MonoBehaviour
{
    public ZoomInOut cameraZoom;
    public DefaultCameraManager cameraManager;
    private GameObject temp;
    private float tempSpeed;
    
    public bool isTargetChange; // 타겟 변경 여부

    // Start is called before the first frame update
    void Start()
    {
        isTargetChange = false;
        temp = cameraManager.target.gameObject;
        tempSpeed = cameraManager.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (isTargetChange)  // 타겟을 바꿀때
        {
            cameraManager.moveSpeed = 1; // 카메라 이동속도 감소
            cameraZoom.isZoomIn = true;
            cameraZoom.isZoomOut = false;
            cameraManager.target = this.gameObject; // 변경하는 타겟은 이 컴포넌트가 위치하는 오브젝트
        }
        else
        {
            cameraZoom.isZoomIn = false;
            cameraZoom.isZoomOut = true;
            cameraManager.target = temp;

            if (cameraManager.getCamera.orthographicSize > cameraZoom.cameraSizeMinus- 0.01) // 줌아웃이 거의 완료되었을때 카메라 이동속도를 정상화한다
            {
                cameraManager.moveSpeed = tempSpeed;
            }
                
        }
        
    }
}