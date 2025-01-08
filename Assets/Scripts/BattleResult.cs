using UnityEngine;
using UnityEngine.UI;

public class BattleResult : MonoBehaviour
{
    public Text resultText;
    public GameObject resultPanel;

    public void ShowResult(bool playerWon)
    {
        resultPanel.SetActive(true);

        if (playerWon)
            resultText.text = "Victory!";
        else
            resultText.text = "Defeat!";
    }

    public void HideResult()
    {
        resultPanel.SetActive(false);
    }
}
