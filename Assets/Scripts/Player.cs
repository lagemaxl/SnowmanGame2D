using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D col;

    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip strom;

    [SerializeField]
    private float treeCollisionSizeReduce = 0.5f;

    [SerializeField]
    private float bounceForce = 1.0f;

    [SerializeField]
    private float boostForce = 10f;

    public Vector3 Pos { get { return transform.position; } }
    public Vector2 PlayerVelocity { get { return rb.velocity; } }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void ActivateRb()
    {
        rb.isKinematic = false;
    }

    public void DeactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }

    public void KillPlayer()
    {
        Debug.Log("Umrer");

        Application.Quit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            source.PlayOneShot(strom);
            GameManager.Instance.ReducePlayerScale(treeCollisionSizeReduce);
            Animator treeAnimator = collision.gameObject.GetComponent<Animator>();
            if (treeAnimator != null)
            {
                treeAnimator.SetTrigger("Shake");
            }
        }
        else if (collision.gameObject.CompareTag("Fence"))
        {
            Vector2 bounceDirection = collision.contacts[0].normal;
            rb.AddForce(-bounceDirection * bounceForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wind"))
        {
            Wind wind = collision.gameObject.GetComponent<Wind>();
            if (wind != null)
            {
                rb.AddForce(wind.WindDirection.normalized * wind.WindForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Booster"))
        {
            rb.AddForce(other.gameObject.transform.right * boostForce, ForceMode2D.Impulse);
            GameManager.Instance.ReducePlayerScale(2f);
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            float playerSize = transform.localScale.x;
            if (playerSize > GameManager.Instance.MinimumWinSize && playerSize < GameManager.Instance.MaximumWinSize)
            {
                Debug.Log("Level complete!");
            }
        }
    }
}
