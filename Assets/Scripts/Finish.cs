using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Finish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float playerSize = other.gameObject.transform.localScale.x;
            if (playerSize > 1.2f && playerSize < 1.8f)
            {
                SceneManager.LoadScene("LevelSelect");
            }
        }
    }
}
