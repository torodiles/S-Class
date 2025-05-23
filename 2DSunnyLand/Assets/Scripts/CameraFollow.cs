using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    
    public Vector2 min;
    public Vector2 max;

    private float halfHeight;
    private float halfWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera cam = GetComponent<Camera>();
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * cam.aspect;
    }

    void LateUpdate()
    {
        Vector3 newPos = player.position;
        float clampedX = Mathf.Clamp(newPos.x, min.x + halfWidth, max.x - halfWidth);
        float clampedY = Mathf.Clamp(newPos.y, min.y + halfHeight, max.y - halfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
