using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("GameManager is already present.");
            return;
        }
        instance = this;
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0;
    }
}
