using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public float JumpKraft = 10f;
    public bool Bodenständig = false;
    private Quaternion KeineRotation;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        KeineRotation = Quaternion.identity;
        rb.linearVelocityX = 0f;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Bodenständig = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {

        }
        else
        {
            rb.linearVelocityX = 0f;
        }
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("gelandet");
        Bodenständig = true;
        rb.linearVelocityX = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = KeineRotation;
        if ((Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))))
        {
            Debug.Log("W &oder Space wurden gedrückt");
            if (Bodenständig)
            {
                rb.AddForce(Vector3.up * JumpKraft, ForceMode2D.Impulse);
                Bodenständig = false;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocityX = -1f * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocityX = 1f * speed;
        }
    }
}
