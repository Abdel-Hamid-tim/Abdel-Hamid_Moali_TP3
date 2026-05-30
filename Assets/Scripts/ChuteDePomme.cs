using UnityEngine;

public class ChuteDePomme : MonoBehaviour
{
    public float delaiAvantChute = 2f;
    private Vector3 positionInitiale;
    private Rigidbody2D rb;

    void Start()
    {
        positionInitiale = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        Invoke(nameof(Lacher), delaiAvantChute);
    }

    void Lacher() => rb.gravityScale = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On réinitialise si on touche le sol
        if (collision.CompareTag("Sol"))
        {
            rb.linearVelocity = Vector2.zero; // Ou rb.velocity si version Unity < 2023
            rb.gravityScale = 0;
            transform.position = positionInitiale;
            Invoke(nameof(Lacher), delaiAvantChute);
        }
    }
}