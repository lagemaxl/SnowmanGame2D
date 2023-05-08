using UnityEngine;
using UnityEngine.UI;

public class FinishSettings : MonoBehaviour
{
    [SerializeField]
    private float minSizeToFinish = 1.2f;
    public float MinSizeToFinish => minSizeToFinish;

    [SerializeField]
    private float maxSizeToFinish = 1.8f;
    public float MaxSizeToFinish => maxSizeToFinish;

    [SerializeField]
    private string nextLevelName = "LevelSelect";
    public string NextLevelName => nextLevelName;

    [SerializeField]
    private Button finishButton;
    public Button FinishButton => finishButton;
}
