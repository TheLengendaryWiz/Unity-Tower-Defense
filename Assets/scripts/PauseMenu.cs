using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public SceneFader sf;
    private void Update()
    {
        if (GameManager.GameOver)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0f;
            ui.SetActive(true);
        }
    }
    public void Countinue()
    {
        Time.timeScale = 1f;
        ui.SetActive(false);
    }
    public void retry()
    {
        Time.timeScale = 1f;
        sf.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        sf.FadeTo("Main Menu");
        Time.timeScale = 1f;
        //ui.SetActive(false);
    }
}
