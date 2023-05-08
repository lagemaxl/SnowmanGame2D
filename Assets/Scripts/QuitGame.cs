using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();

        #if UNITY_WEBGL || UNITY_EDITOR
            button.gameObject.SetActive(false);
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Exit()
    {
        Debug.Log("Quit button clicked.");
        Application.Quit();
    }
}
