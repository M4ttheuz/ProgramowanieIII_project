using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject[] tankModels; // Tablica modeli czo³gów
    private int currentTankIndex = 0;

    public void StartGame()
    {
        // Zapisz wybór czo³gu, np. przez PlayerPrefs (mo¿na u¿yæ do póŸniejszego wyboru)
        PlayerPrefs.SetInt("SelectedTank", currentTankIndex);
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Gra wy³¹czona");
        Application.Quit();
    }

    public void NextTank()
    {
        currentTankIndex = (currentTankIndex + 1) % tankModels.Length;
        UpdateTankSelection();
    }

    public void PreviousTank()
    {
        currentTankIndex = (currentTankIndex - 1 + tankModels.Length) % tankModels.Length;
        UpdateTankSelection();
    }

    void UpdateTankSelection()
    {
        // Wy³¹cz wszystkie modele czo³gów
        foreach (GameObject tank in tankModels)
        {
            tank.SetActive(false);
        }

        // Aktywuj wybrany model czo³gu
        if (currentTankIndex >= 0 && currentTankIndex < tankModels.Length)
        {
            tankModels[currentTankIndex].SetActive(true);
        }
    }
}
