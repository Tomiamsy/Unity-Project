using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; //laufgeschwindigkeit des Spielers
    public Rigidbody2D rb; 
    public float JumpKraft = 10f; // wie hoch man springt
    public bool Bodenständig = false; // gibt an ob man Boden unter den Füßen hat, verhindert double Jumps
    private Quaternion KeineRotation; 
    public float WandSlideSpeed = 0.5f; // bestimmt wie schnell man die Wand runter rutscht
    public float WallSlideSide; //gibt an an welcher Seite von der Wand man sich befindet

    public bool WallL; //sagt dem Input ob man gegen eine linke Wand rennt
    public bool WallR;//sagt dem Input ob man gegen eine rechte Wand rennt

    public float SpeedMonitor;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        KeineRotation = Quaternion.identity;
        rb.linearVelocityX = 0f;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Bodenständig = false;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            WallL = false;
            WallR = false;

        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("gelandet");
            Bodenständig = true;
            rb.linearVelocityX = 0f;
        }
        if (collision.gameObject.CompareTag("Wall")) //amit der Spieler nicht nach oben sliden kann wird die Slide richtung auf nach unten gesetzt
        {
            rb.linearVelocityY = -0.1f;
            rb.linearVelocityX = 0;

            WallSlideSide = SpeedMonitor;
            
            if (WallSlideSide < 0)
            {
                WallL = true;
            }
            else if (WallSlideSide > 0)
            {
                WallR = true;
            }
            else
            {
                Debug.Log("Error, WallSlideSide = 0?");
            }
        }
        
    
    }
    private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {

                }
                else
                {
                    rb.linearVelocityX = 0f;
                }
            }
            if (collision.gameObject.CompareTag("Wall")) //Damit der Spieler an einer Wand runtersliden kann
            {
                rb.linearVelocityY = rb.linearVelocityY * WandSlideSpeed;
            }
            
        }


    // Update is called once per frame
    void Update()
    {
        SpeedMonitor = rb.linearVelocityX;

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
        if (Input.GetKey(KeyCode.A) && !WallL)
        {
            rb.linearVelocityX = -1f * speed;
        }
        if (Input.GetKey(KeyCode.D) && !WallR)
        {
            rb.linearVelocityX = 1f * speed;
        }
    }
}
