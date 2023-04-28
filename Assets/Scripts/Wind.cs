using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField]
    private Vector2 windDirection = Vector2.right;
    [SerializeField]
    private float windForce = 1.0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(windDirection.normalized * windForce * Time.deltaTime);
        }
    }
}
