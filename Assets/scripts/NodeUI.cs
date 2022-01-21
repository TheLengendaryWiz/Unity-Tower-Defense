using UnityEngine;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour
{
    private node target;
    public Button UpgradeButton;
    public Text upgrdetext;
    public Text sellText;
    public GameObject canvas;
    public void SetTarget(node _target)
    {
        target = _target;
        transform.position = target.BuildPosition();
        if (!target.IsUpgraded)
        {
            sellText.text = "$" + target.TurretBlueprint.GetTurretCost();
            upgrdetext.text = "$" + target.TurretBlueprint.Upgradecost;
            UpgradeButton.interactable = true;
        }
        else
        {
            upgrdetext.text = "DONE";
            UpgradeButton.interactable = false;
        }
        
        canvas.SetActive(true);
    }
    public void Hide()
    {
        canvas.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        buildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        buildManager.instance.DeselectNode();
    }
}