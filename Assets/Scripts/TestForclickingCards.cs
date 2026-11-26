using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class CardTest : MonoBehaviour
{
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Q("card-0").RegisterCallback<ClickEvent>(e => input.mouse));
        root.Q("card-1").RegisterCallback<ClickEvent>(e => Debug.Log("card 1 clicked"));
        root.Q("card-2").RegisterCallback<ClickEvent>(e => Debug.Log("card 2 clicked"));
    }
}