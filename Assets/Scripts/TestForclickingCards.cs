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

        root.Q("card-0").RegisterCallback<ClickEvent>(e => selectedPrefab = card0Prefab);
        root.Q("card-1").RegisterCallback<ClickEvent>(e => selectedPrefab = card1Prefab);
        root.Q("card-2").RegisterCallback<ClickEvent>(e => selectedPrefab = card2Prefab);
    }

    void Update()
    {
        if (selectedPrefab == null || !Input.GetMouseButtonDown(0))
            return;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            Instantiate(selectedPrefab, hit.point, Quaternion.identity);
            selectedPrefab = null;
        }
    }
}