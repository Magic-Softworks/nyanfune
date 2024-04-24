using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private Button _startButton;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _startButton = root.Q<Button>("StartGameButton");
        _startButton.clicked += StartNewGame;

        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (mode == LoadSceneMode.Single)
        {
            SceneManager.SetActiveScene(scene);
        }
    }

    private void StartNewGame()
    {
        SceneManager.LoadScene("GamePlayTesting");
    }
}
