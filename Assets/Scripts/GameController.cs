using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Transform player;
    public SaveManager saveManager;
    public int tanksDestroyed = 0;
    public int playedBattles = 0;
    public BattleResult battleResult;

    public List<EnemyHealth> enemyTanks;
    public PlayerHealth playerTank;

    private void Start()
    {
        GameData data = saveManager.LoadGame();
        if (data != null)
        {
            tanksDestroyed = data.tanksDestroyed;
            playedBattles = data.playedBattles;
        }
    }

    public void TankDestroyed()
    {
        if(playerTank.currentHealth > 0)
            tanksDestroyed++;
        CheckBattleEnd();
    }

    private void CheckBattleEnd()
    {
        if (playerTank.currentHealth <= 0)
        {
            EndBattle(false);
            return;
        }

        bool allEnemiesDefeated = true;
        foreach (EnemyHealth enemy in enemyTanks)
        {
            if (enemy.currentHealth > 0)
            {
                allEnemiesDefeated = false;
                break;
            }
        }

        if (allEnemiesDefeated)
        {
            EndBattle(true);
        }
    }

    private void EndBattle(bool playerWon)
    {
        battleResult.ShowResult(playerWon);
        Time.timeScale = 0f;

        StartCoroutine(EndBattleDelay(playerWon));
    }

    private IEnumerator EndBattleDelay(bool playerWon)
    {
        float elapsedTime = 0f;
        while (elapsedTime < 5f)
        {
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

       
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
