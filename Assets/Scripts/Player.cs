using UnityEngine;

public class Player : MonoBehaviour
{
    // https://github.com/herbou/Tuto_DrawTrajectory/blob/master/Assets/Scripts/
    // mozna bude potreba public
    private Rigidbody2D rb;
    private CircleCollider2D col;

    public Vector3 Pos { get { return transform.position; } }

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



    // dodelat
    public void KillPlayer()
    {
        Debug.Log("Umrer");
        // Ukonèení hry
        Application.Quit();
    }
}
