using System.Collections;
using UnityEngine;
/// <summary>
/// 달리 줌 스크립트(과연 사용할까영)
/// </summary>
public class DollyZoom : MonoBehaviour
{
    public Transform target;
    public Camera cameraOption;

    private float initHeightAtDist;
    public bool dollyZoomIn;

    float FrustumHeightAtDistance(float distance)
    {
        return 2.0f * distance * Mathf.Tan(cameraOption.fieldOfView * 0.5f * Mathf.Deg2Rad);
    }

    public float FOVForHeightAndDistance(float height, float distance)
    {
        return 2.0f * Mathf.Atan(height * 0.5f / distance) * Mathf.Rad2Deg;
    }

    // Dolly 줌 시작
    public void StartDZ()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        initHeightAtDist = FrustumHeightAtDistance(distance);
        dollyZoomIn = true;
    }

    void Start()
    {
        StartDZ();
    }

    void Update()
    {

        var currDistance = Vector3.Distance(this.transform.position, target.position);


        if (dollyZoomIn && cameraOption.transform.position.z <= -5)
        {
            cameraOption.fieldOfView = FOVForHeightAndDistance(initHeightAtDist, currDistance);
            transform.Translate(Vector3.forward * Time.deltaTime * 10f);
        }
        else if (!dollyZoomIn && cameraOption.transform.position.z >= -15)
        {
            cameraOption.fieldOfView = FOVForHeightAndDistance(initHeightAtDist, currDistance);
            transform.Translate(Vector3.forward * Time.deltaTime * -10f);
        }
    }
}