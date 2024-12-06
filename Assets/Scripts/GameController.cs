using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform player;
    public SaveManager saveManager;
    public int tanksDestroyed = 0;
<<<<<<< HEAD
    public int playedBattles = 0;
=======
    public int playedTime = 0;
>>>>>>> 6ef7eedccadd52639a0f336e41b852cd084f379a

    public void TankDestroyed()
    {
        tanksDestroyed++;
        Debug.Log("Tank destroyed! Total: " + tanksDestroyed);
    }

<<<<<<< HEAD
    public void PlayBattle()
    {
        playedBattles++;
        Debug.Log("Battle played! Total: " + playedBattles);
    }

=======
>>>>>>> 6ef7eedccadd52639a0f336e41b852cd084f379a
    private void Start()
    {
        GameData data = saveManager.LoadGame();
        if (data != null)
        {
            tanksDestroyed = data.tanksDestroyed;
<<<<<<< HEAD
            playedBattles = data.playedBattles;
=======
            playedTime = data.playedTime;
>>>>>>> 6ef7eedccadd52639a0f336e41b852cd084f379a
        }
    }
}