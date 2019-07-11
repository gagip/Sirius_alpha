using UnityEngine;
using System.Collections;
/// <summary>
/// 카메라 흔들기
/// </summary>
public class ShakeCamera : MonoBehaviour
{
    
    public Transform camTransform;
    
    public float shakeDuration = 0f; // 진동 시간
    
    public float shakeAmount = 0.7f; // 진동 크기
    private float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0) // Shake Duration을 증가시켜서 제어
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
    }
}
