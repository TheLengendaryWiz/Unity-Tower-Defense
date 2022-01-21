using UnityEngine;

public class buildManager : MonoBehaviour
{
    public NodeUI nodeUI;
    public GameObject oanel;
    public GameObject Selleffect;
    private TurretBluePrint turretToBuild;
    node SelectedNode;
    public static buildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Bulid Manager repeated");
            return;
        }
        instance = this;
    }
    public GameObject buildeffect;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return playerStats.Money>=turretToBuild.cost; } }
    public void SelectNode(node NODE)
    {
        if (NODE == SelectedNode)
        {
            DeselectNode();
            return;
            
        }
        SelectedNode = NODE;
        turretToBuild = null;
        nodeUI.SetTarget(SelectedNode);
    }
    public void selectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public void DeselectNode()
    {
        SelectedNode = null;
        nodeUI.Hide();
    }
    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void FreezeTime()
    {
        Time.timeScale = 0f;
        oanel.SetActive(true);
    }
}