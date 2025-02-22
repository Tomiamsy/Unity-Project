using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public float JumpForce = 10f;
    public bool Bodenständig = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))))
        {
            
            Debug.Log("W &oder Space wurden gedrückt");
            
            rb.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
            
                
            
            



        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A wurde gedrückt");

            rb.AddForce(Vector3.left * speed, ForceMode2D.Force);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D wurde gedrückt");

            rb.AddForce(Vector3.right * speed, ForceMode2D.Force);
        }
    }
}
