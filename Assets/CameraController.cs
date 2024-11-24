using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // 追跡の対象
    public Vector3 offset; // カメラの位置

    void Update()
    {
        transform.position = target.position + offset;
    }
}
