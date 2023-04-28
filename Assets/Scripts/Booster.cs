using UnityEngine;

public class Booster : Bounce
{
    [SerializeField]
    private float shrinkFactor = 0.5f;
    [SerializeField]
    private float speedMultiplier = 2.0f;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 bounceDirection = collision.contacts[0].normal;
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(-bounceDirection * bounceForce, ForceMode2D.Impulse);

            playerRigidbody.transform.localScale *= shrinkFactor;
            playerRigidbody.velocity *= speedMultiplier;
        }
    }
}
