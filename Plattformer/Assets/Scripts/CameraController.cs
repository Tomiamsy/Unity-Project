using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    private Vector3 pos;
    public float offsetX = 0f;
    public float offsetY = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3((Player.transform.position.x + offsetX), Player.transform.position.y + offsetY, -10f);
        transform.position = pos;
    }
}

