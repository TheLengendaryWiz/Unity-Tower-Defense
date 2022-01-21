using UnityEngine;
using UnityEngine.UI;

public class MoneyUi : MonoBehaviour
{
    public TextMesh money;

    // Update is called once per frame
    void Update()
    {
        money.text =  "$"+playerStats.Money.ToString();
    }
}
