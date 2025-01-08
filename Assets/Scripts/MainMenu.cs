using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour

{
    public GameController gameController;
    public void StartGame()
    {
       SceneManager.LoadScene("Game");
       Cursor.visible = false;
       Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
