using UnityEngine;
using UnityEngine.UIElements;
public class Energysystem : MonoBehaviour
{
    public static Energysystem instance;
    public int defaultCurrency;
    public int currency;
    private Label txt_Currency;
    
    void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        txt_Currency = root.Q<Label>("energy-label");

        if (txt_Currency == null)
            Debug.LogError("CurrencySystem: Label 'energy-label' not found in the UXML.");

        Init();
    }
    public void Init()
    {
        currency = defaultCurrency;
        UpdateUI();
    }

    public void Gain(int val)
    {
        currency += val;
        UpdateUI();
    }

    public bool Use(int val)
    {
        if (!EnoughCurrency(val))
            return false;

        currency -= val;
        UpdateUI();
        return true;
    }

    public bool EnoughCurrency(int val)
    {
        return val <= currency;
    }

    void UpdateUI()
    {
        if (txt_Currency != null)
            txt_Currency.text = "Energy: " + currency.ToString();
    }
}
