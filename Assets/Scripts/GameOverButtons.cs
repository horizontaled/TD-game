using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class GameOverButtons : MonoBehaviour
{
    
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        Button RestartButton= root.Q<Button>("RestartButton");
        RestartButton.clicked += OnRestartClicked;
        Button MainMenuButton = root.Q<Button>("MainMenuButton");
        MainMenuButton.clicked += OnMainClicked;
        Button quitButton = root.Q<Button>("QuitButton");
        quitButton.clicked += OnQuitClicked;
    }

    void OnRestartClicked()
    {
        Debug.Log("Play pressed!");
        SceneManager.LoadScene("Mainscene");
    }
    void OnMainClicked()
    {
        Debug.Log("Credit pressed!");
        SceneManager.LoadScene("MainMenu");
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
