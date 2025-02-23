using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; //laufgeschwindigkeit des Spielers
    public float Resistance = 0.9f;
    private bool MoveAllowL;
    private bool MoveAllowR;
    
    public Rigidbody2D rb; 
    
    public float JumpKraft = 10f; // wie hoch man springt
    public float WallJumpKraft = 10f; //wie weit man von einer Wand wegspringt bei einem Walljump
    public float WallJumpHeight = 5f;

    public bool Bodenständig = false; // gibt an ob man Boden unter den Füßen hat, verhindert double Jumps
    
    private Quaternion KeineRotation; 
    
    public float WandSlideSpeed = 0.5f; // bestimmt wie schnell man die Wand runter rutscht
    public float WallSlideSide; //gibt an an welcher Seite von der Wand man sich befindet

    private bool WallL; //sagt dem Input ob man gegen eine linke Wand rennt
    private bool WallR;//sagt dem Input ob man gegen eine rechte Wand rennt

    public float SpeedMonitorX;
    public float SpeedMonitorY;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        KeineRotation = Quaternion.identity;
        
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
            
                
            Bodenständig = true;
            rb.linearVelocityX = 0f;

            MoveAllowL = true;
            MoveAllowR = true;
            
            

                
        }
        if (collision.gameObject.CompareTag("Wall") && !collision.gameObject.CompareTag("Ground")) //amit der Spieler nicht nach oben sliden kann wird die Slide richtung auf nach unten gesetzt
        {
            
            Bodenständig = true;
            rb.linearVelocityY = -0.1f;
            rb.linearVelocityX = 0;

            WallSlideSide = SpeedMonitorX;
            
            if (WallSlideSide < 0)
            {
                WallL = true;
                MoveAllowL = false;
                MoveAllowR = true;
            }
            else if (WallSlideSide > 0)
            {
                WallR = true;
                MoveAllowR = false;
                MoveAllowL = true;
                Debug.Log("Rechte Wand");
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
            Bodenständig = true;
            }
            if (collision.gameObject.CompareTag("Wall")) //Damit der Spieler an einer Wand runtersliden kann
            {
                rb.linearVelocityY = rb.linearVelocityY * WandSlideSpeed;
            }
            
        }


    // Update is called once per frame
    void Update()
    {
        SpeedMonitorX = rb.linearVelocityX;
        SpeedMonitorY = rb.linearVelocityY;

        if (SpeedMonitorY < 0)
        {
            MoveAllowL = true;
            MoveAllowR = true;
        }

        transform.rotation = KeineRotation;
        if ((Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))) //springen
        {
            
            if (Bodenständig)
            {
                if (WallL) //walljump von links
                {
                    rb.AddForce(Vector3.right * WallJumpKraft);
                    rb.AddForce(Vector3.up * JumpKraft *WallJumpHeight, ForceMode2D.Impulse);
                    Bodenständig = false;
                    MoveAllowL = false;
                    
                }
                if (WallR) //walljump von rechts
                {
                    rb.AddForce(Vector3.left * WallJumpKraft);
                    rb.AddForce(Vector3.up * JumpKraft * WallJumpHeight, ForceMode2D.Impulse);
                    Bodenständig = false;
                    Debug.Log("rechts abstoßen");
                    MoveAllowR = false;
                }
                else //normale Sprung
                {
                    rb.AddForce(Vector3.up * JumpKraft, ForceMode2D.Impulse);
                    Bodenständig = false;
                }
                    
            }
        }
        if ((Input.GetKey(KeyCode.A) && !WallL) && MoveAllowL) // A gedrückt, nicht an einer linken Wand, nicht von einer linken Wand
        {
            rb.linearVelocityX = -1f * speed;
        }
        if ((Input.GetKey(KeyCode.D) && !WallR) && MoveAllowR) // A gedrückt, nicht an einer rechten Wand, nicht von einer rechten
        {
            rb.linearVelocityX = 1f * speed;
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.linearVelocityX = rb.linearVelocityX * Resistance;
        }
    }
}
