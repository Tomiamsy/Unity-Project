using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Resistance = 0.99f;
    public Rigidbody2D rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocityX = rb.linearVelocityX * Resistance;
    }
}
