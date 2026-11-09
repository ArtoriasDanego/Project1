using UnityEngine;

public class platform : MonoBehaviour
{
    public float jumpForce = 10f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.linearVelocity;
                velocity.y = jumpForce;
                rb.linearVelocity = velocity;
                
                AudioSource jumpSound = collision.collider.GetComponent<AudioSource>();

                if (jumpSound != null)
                {
                    jumpSound.pitch = Random.Range(0.9f, 1.1f);
                    jumpSound.Play();
                }
            }
        }
    }
    void Update()
{
    if (transform.position.y < Camera.main.transform.position.y - 10f)
    {
        Destroy(gameObject);
    }
}

}
