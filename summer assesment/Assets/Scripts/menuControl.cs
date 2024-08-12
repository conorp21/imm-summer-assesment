using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("game1"); // Replace "StartScene" with the name of your start scene
    }

    public void OpenLevels()
    {
        SceneManager.LoadScene("levels"); // Replace "LevelsScene" with the name of your levels scene
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
