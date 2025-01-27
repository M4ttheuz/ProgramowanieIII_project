using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour

{
    public void StartGame()
    {
       Time.timeScale = 1f;
       SceneManager.LoadScene("Game");
       Cursor.visible = false;
       Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
