using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    [SerializeField] private InputActionReference pauseAction;
    private VisualElement pauseMenu;
    private Button resumeButton;
    private Button mainMenuButton;
    private Button quitButton;

    private bool isPaused = false;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        pauseMenu = root.Q<VisualElement>("pause-menu");

        resumeButton = root.Q<Button>("resume-button");
        mainMenuButton = root.Q<Button>("main-menu-button");
        quitButton = root.Q<Button>("quit-button");

        resumeButton.clicked += ResumeGame;
        mainMenuButton.clicked += MainMenu;
        quitButton.clicked += QuitGame;

        pauseMenu.style.display = DisplayStyle.None;
    }

    void OnEnable()
    {
        pauseAction.action.Enable();
        pauseAction.action.performed += PauseGame;
    }

    void OnDisable()
    {
        pauseAction.action.performed -= PauseGame;
        pauseAction.action.Disable();
    }

    void PauseGame(InputAction.CallbackContext context)
    {
        if (isPaused)
            ResumeGame();
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            pauseMenu.style.display = DisplayStyle.Flex;
        }
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.style.display = DisplayStyle.None;
    }

    void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    void QuitGame()
    {
        Debug.Log("Quit game pressed!");

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
