using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class RoundsSurvived : MonoBehaviour
{
    public Text roundsSurvived;
    private void OnEnable()
    {
        StartCoroutine(TextChanger());
    }
    IEnumerator TextChanger()
    {
        yield return new WaitForSeconds(0.2f);
        roundsSurvived.text = "0";
        int index = 0;
        while (index <= playerStats.rounds)
        {
            roundsSurvived.text = index.ToString();
            yield return new WaitForSeconds(.05f);
            index++;
        }
    }
}