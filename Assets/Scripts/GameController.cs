using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform player;
    public SaveManager saveManager;
    public int tanksDestroyed = 0;
    public int playedTime = 0;

    public void TankDestroyed()
    {
        tanksDestroyed++;
        Debug.Log("Tank destroyed! Total: " + tanksDestroyed);
    }

    private void Start()
    {
        GameData data = saveManager.LoadGame();
        if (data != null)
        {
            tanksDestroyed = data.tanksDestroyed;
            playedTime = data.playedTime;
        }
    }
}