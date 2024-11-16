using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject[] tankModels; // Tablica modeli czo�g�w
    private int currentTankIndex = 0;

    public void StartGame()
    {
        // Zapisz wyb�r czo�gu, np. przez PlayerPrefs (mo�na u�y� do p�niejszego wyboru)
        PlayerPrefs.SetInt("SelectedTank", currentTankIndex);
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Gra wy��czona");
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
        // Wy��cz wszystkie modele czo�g�w
        foreach (GameObject tank in tankModels)
        {
            tank.SetActive(false);
        }

        // Aktywuj wybrany model czo�gu
        if (currentTankIndex >= 0 && currentTankIndex < tankModels.Length)
        {
            tankModels[currentTankIndex].SetActive(true);
        }
    }
}
