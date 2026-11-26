using UnityEngine;
using UnityEngine.UIElements;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    public int score;
    private Label txt_Score;

    void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        txt_Score = root.Q<Label>("score-label");

        if (txt_Score == null)
            Debug.LogError("ScoreSystem: Label 'score-label' not found in the UXML.");

        Init();
    }

    public void Init()
    {
        score = 0;
        UpdateUI();
    }

    public void Add(int val)
    {
        score += val;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (txt_Score != null)
            txt_Score.text = "Score: " + score.ToString();
    }
}