using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 10f;
    private Vector2 startMousePosition;
    private Vector2 endMousePosition;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = startMousePosition - endMousePosition;
            direction.Normalize();
            rb.AddForce(direction * forceMultiplier, ForceMode2D.Impulse);
        }
    }
}
