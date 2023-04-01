using UnityEngine;

public class Block : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotateSpeed = 10f;

    public Vector2 direction = Vector2.down;

    public static System.Action<Block> PushToPool;

    public Vector2 screenBounds = Vector2.zero;
    public Camera cam;

    private void Awake()
    {

    }

    private void Start()
    {
        screenBounds = new Vector2(cam.aspect * cam.orthographicSize, cam.orthographicSize);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        if (transform.localPosition.y < -screenBounds.y * 1.2)
        {
            Destroy(gameObject);
            // Could throw it back to pool as well
        }
    }
}
