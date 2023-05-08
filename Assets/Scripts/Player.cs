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
}
