using UnityEngine;
public class LivesUI : MonoBehaviour
{
    public TextMesh LivesText;
    void Update()
    {
        LivesText.text = playerStats.lives.ToString() + " LIVES";
    }
}
