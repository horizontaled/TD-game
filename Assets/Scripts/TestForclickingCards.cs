using UnityEngine;
using UnityEngine.UIElements;

public class CardTest : MonoBehaviour
{
    public GameObject card0Prefab;
    public GameObject card1Prefab;
    public GameObject card2Prefab;

    GameObject selectedPrefab;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        root.Q("card-0").RegisterCallback<ClickEvent>(e => SelectCard(card0Prefab));
        root.Q("card-1").RegisterCallback<ClickEvent>(e => SelectCard(card1Prefab));
        root.Q("card-2").RegisterCallback<ClickEvent>(e => SelectCard(card2Prefab));
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectCard(card0Prefab);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SelectCard(card1Prefab);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectCard(card2Prefab);

    
        if (selectedPrefab == null || !Input.GetMouseButtonDown(0))
            return;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            Instantiate(selectedPrefab, hit.point, Quaternion.identity);
            selectedPrefab = null;
        }
    }

    void SelectCard(GameObject card)
    {
        selectedPrefab = card;
        Debug.Log($"Selected {card.name}");
    }
}