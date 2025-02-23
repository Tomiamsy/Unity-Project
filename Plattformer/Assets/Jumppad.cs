using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f; // St�rke des Sprungs

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �berpr�fe, ob das Objekt, das das Pad ber�hrt, ein Spieler ist
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Setze die vertikale Geschwindigkeit direkt (springt nach oben)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}