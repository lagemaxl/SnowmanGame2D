using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private bool hasFinished = false;
    
    private float minSizeToFinish = 0f;
    private float maxSizeToFinish = 0f;
    private string nextLevelName = "";
    private Button finishButton = null;
    [SerializeField]
    private TextMeshProUGUI textMeshPro; 


    private void Start()
    {
        if (transform.parent != null)
        {
            FinishSettings parentSettings = transform.parent.GetComponent<FinishSettings>();

            if (parentSettings != null)
            {
                minSizeToFinish = parentSettings.MinSizeToFinish;
                maxSizeToFinish = parentSettings.MaxSizeToFinish;
                nextLevelName = parentSettings.NextLevelName;
                finishButton = parentSettings.FinishButton;
            }
            else
            {
                Debug.LogWarning("Parent GameObject does not have a FinishSettings component.");
            }
        }
        else
        {
            Debug.LogWarning("This GameObject does not have a parent.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float playerSize = other.gameObject.transform.localScale.x;
            if(playerSize > maxSizeToFinish)
            {
                textMeshPro.text = "Too big";
            } else if (playerSize < minSizeToFinish)
            {
                textMeshPro.text = "Too small";


            }else
            {
                textMeshPro.text = "";
            }
            

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
