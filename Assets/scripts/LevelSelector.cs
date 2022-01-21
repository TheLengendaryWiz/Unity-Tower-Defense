using UnityEngine;using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader sf; public Button[] buttons;
    public void Select(string scene)
    {
        sf.FadeTo(scene);
    }
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached",1);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 1>levelReached)
            {
                buttons[i].interactable = false;
            }
            
        }
    }
}
