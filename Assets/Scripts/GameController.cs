using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform player;
    public SaveManager saveManager;
    public int tanksDestroyed = 0;
    public int playedBattles = 0;

    public void TankDestroyed()
    {
        tanksDestroyed++;
        Debug.Log("Tank destroyed! Total: " + tanksDestroyed);
    }

    public void PlayBattle()
    {
        playedBattles++;
        Debug.Log("Battle played! Total: " + playedBattles);
    }

    private void Start()
    {
        GameData data = saveManager.LoadGame();
        if (data != null)
        {
            tanksDestroyed = data.tanksDestroyed;
            playedBattles = data.playedBattles;
        }
    }
}