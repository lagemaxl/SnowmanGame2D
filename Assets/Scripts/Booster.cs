using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] private float boostForce = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(transform.right * boostForce, ForceMode2D.Impulse);
            GameManager.Instance.ReducePlayerScale(2f);
        }
    }
}
