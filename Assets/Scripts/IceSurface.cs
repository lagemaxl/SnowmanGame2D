using UnityEngine;

public class IceSurface : MonoBehaviour
{
    [SerializeField]
    private float frictionReduction = 0.1f;
    [SerializeField]
    private float speedMultiplier = 1.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();

            playerRigidbody.velocity *= speedMultiplier;
            playerRigidbody.drag *= frictionReduction;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.drag /= frictionReduction;
        }
    }
}
