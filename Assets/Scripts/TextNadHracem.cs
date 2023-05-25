using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextNadHracem : MonoBehaviour
{
    [SerializeField]
    private Transform player; // Player's transform
    [SerializeField]
    private TextMeshProUGUI textMeshPro; // Your TextMeshPro component
    [SerializeField]
    private Vector3 offset; // Offset to adjust text position

    // Update is called once per frame
    void LateUpdate()
    {
        // Transform player's position to screen point and add offset
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(player.position + offset);

        // Set text's position
        textMeshPro.transform.position = screenPosition;
    }
}
