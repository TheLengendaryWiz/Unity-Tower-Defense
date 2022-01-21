using UnityEngine;

public class levelcomplete : MonoBehaviour
{
    public SceneFader sf;
    public GameManager gm;
    public GameObject oanel;
    public void countinue()
    {
        sf.FadeTo(gm.nextLevel);
    }
    public void Menu()
    {
        sf.FadeTo("Main Menu");

    }
    public void M()
    {
        Time.timeScale = 1f;
        oanel.SetActive(false);
    }
}
