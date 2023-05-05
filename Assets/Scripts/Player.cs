using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 10f;
    public float maxForce = 20f;
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
            float distance = Vector2.Distance(startMousePosition, endMousePosition);
            float force = Mathf.Clamp(forceMultiplier * distance, 0f, maxForce);
            direction.Normalize();
            rb.AddForce(direction * force, ForceMode2D.Impulse);
        }

        // Postupnì zpomalovat kouli, jak se pohybuje
        if (rb.velocity.magnitude > 0f)
        {
            rb.velocity *= 0.99f;
        }
    }
}
