using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private float minSizeToFinish = 1.2f;

    [SerializeField]
    private float maxSizeToFinish = 1.8f;

    [SerializeField]
    private string nextLevelName = "LevelSelect";

    [SerializeField]
    private Button finishButton;

    private bool hasFinished = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float playerSize = other.gameObject.transform.localScale.x;
            if (playerSize > minSizeToFinish && playerSize < maxSizeToFinish && !hasFinished)
            {
                hasFinished = true;
                SceneManager.LoadScene(nextLevelName);
                if (finishButton != null)
                {
                    finishButton.GetComponent<Image>().color = Color.green;
                }
            }
        }
    }
}
