using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private float minSizeToFinish = 1.2f;

    [SerializeField]
    private float maxSizeToFinish = 1.8f;

    [SerializeField]
    private string nextLevelName = "LevelSelect";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float playerSize = other.gameObject.transform.localScale.x;
            if (playerSize > minSizeToFinish && playerSize < maxSizeToFinish)
            {
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }
}