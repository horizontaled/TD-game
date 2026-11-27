using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class MainMenuController : MonoBehaviour
{
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        Button playButton = root.Q<Button>("PlayButton");
        playButton.clicked += OnPlayClicked;
        Button creditButton = root.Q<Button>("CreditButton");
        creditButton.clicked += OnCreditClicked;
        Button quitButton = root.Q<Button>("QuitButton");
        quitButton.clicked += OnQuitClicked;
    }

    void OnPlayClicked()
    {
        Debug.Log("Play pressed!");
          SceneManager.LoadScene("Mainscene");
    }
    void OnCreditClicked()
    {
        Debug.Log("Credit pressed!");
        SceneManager.LoadScene("Creditscene");
    }
    
    void OnQuitClicked()
    {
        Debug.Log("Quit pressed!");
        SceneManager.LoadScene("Mainscene");
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}