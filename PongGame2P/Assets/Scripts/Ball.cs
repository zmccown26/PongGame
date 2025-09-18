using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public float speed = 8f;
    public float maxAngle = 45f; // max random deflection angle in degrees
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
        LaunchBall();
    }

    void LaunchBall()
    {
        float directionX = Random.value < 0.5f ? -1f : 1f;
        float angleDeg = Random.Range(-maxAngle, maxAngle);
        Vector2 dir = new Vector2(Mathf.Cos(angleDeg * Mathf.Deg2Rad) * directionX, Mathf.Sin(angleDeg * Mathf.Deg2Rad));
        rb.linearVelocity = dir.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // keep speed constant after collision
        rb.linearVelocity = rb.linearVelocity.normalized * speed;

        // small nudge if velocity is nearly horizontal
        if (Mathf.Abs(rb.linearVelocity.y) < 0.2f)
        {
            rb.linearVelocity += new Vector2(0, Random.Range(-0.3f, 0.3f));
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }

        // ✅ Increase speed if hit paddle
        if (collision.gameObject.CompareTag("LeftPaddle") || collision.gameObject.CompareTag("RightPaddle"))
        {
            speed += 0.25f;
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }
    }
}


