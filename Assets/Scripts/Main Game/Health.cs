using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public static Health instance;

    public int maxHealth = 10;
    public string gameOverScene = "GameOver";

    private int health;
    private Label label;
    private VisualElement fill;

    void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        label = root.Q<Label>("health-label");
        fill = root.Q("health-bar-fill");

        health = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        UpdateUI();

        if (health <= 0)
            SceneManager.LoadScene(gameOverScene);
    }

    void UpdateUI()
    {
        label.text = health + " / " + maxHealth;
        fill.style.width = Length.Percent(Mathf.Max(health, 0) / (float)maxHealth * 100f);
    }
}