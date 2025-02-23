using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Resistance = 0.99f;
    public Rigidbody2D rb;
    public float Velocity;
    public float DeltaTime;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DeltaTime = Time.deltaTime;
        Velocity = rb.linearVelocityX * Resistance;
        rb.linearVelocityX = rb.linearVelocityX * Resistance;
    }
}