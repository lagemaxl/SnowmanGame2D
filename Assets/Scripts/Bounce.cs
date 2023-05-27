using UnityEngine;

public class Bounce : MonoBehaviour
{
    //[SerializeField]
    protected float bounceForce = 1.0f;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 bounceDirection = collision.contacts[0].normal;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-bounceDirection * bounceForce, ForceMode2D.Impulse);
        }
    }
}
