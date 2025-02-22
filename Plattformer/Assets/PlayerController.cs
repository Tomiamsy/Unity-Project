using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public float JumpForce = 10f;
    public bool Bodenständig = false;
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
            Bodenständig = false;
            rb.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);



        }
        if (Input.GetKeyDown(KeyCode.A))
        {


        }
        if (Input.GetKeyDown(KeyCode.D))
        {

        }
    }
}
