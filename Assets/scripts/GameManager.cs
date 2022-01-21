using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameOver;
    public GameObject LevelCompleteUI;
    public GameObject GAMEOVERUI;
    public WaveSpawner w;
    public string nextLevel = "Level02";
    public int LevelToUnlock = 2;
    public SceneFader sf;
    private void Start()
    {
        GameOver = false;
    }
    void Update()
    {
        if (GameOver == true)
        {
            return;
        }
        if (playerStats.lives <= 0)
        {
            EndGame();
        }    
    }

    private void EndGame()
    {
        GAMEOVERUI.SetActive(true);
        GameOver = true;
    }

    public void WinLevel()
    {
        GameOver = true;
        LevelCompleteUI.SetActive(true);
        if (PlayerPrefs.GetInt("levelReached") < LevelToUnlock)
        {
            PlayerPrefs.SetInt("levelReached", LevelToUnlock);
        }
        
    }
}