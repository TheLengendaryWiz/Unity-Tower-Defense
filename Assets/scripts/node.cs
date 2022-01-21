using UnityEngine;
using UnityEngine.EventSystems;

public class node : MonoBehaviour
{
    public Vector3 BuildPosition()
    {
        return transform.position + offset;
    }
    public Vector3 zero;
    public GameObject turret;
    public GameObject poor;
    public TurretBluePrint TurretBlueprint;
    public bool IsUpgraded = false;
    public Color PoorColor;
    public Color OnHover;
    private Color AfterHover;
    public Renderer rendeer;
    public Vector3 offset;
    buildManager BuildManager;
    private void Start()
    {
        BuildManager = buildManager.instance;
        rendeer = GetComponent<Renderer>();
        AfterHover = rendeer.material.color;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (turret != null)
        {
            BuildManager.SelectNode(this);
            return;
        }
        if (!BuildManager.CanBuild)
        {
            return;
        }
        BuildTurret(BuildManager.GetTurretToBuild());
    }
    public void BuildTurret(TurretBluePrint bluePrint)
    {
        if (playerStats.Money < bluePrint.cost)
        {
            BuildManager.FreezeTime();
            return;
        }
        playerStats.Money -= bluePrint.cost;
        GameObject _turret = Instantiate(bluePrint.prefab, BuildPosition(), Quaternion.identity);
        turret = _turret;
        TurretBlueprint = bluePrint;
        GameObject effect = Instantiate(BuildManager.buildeffect, BuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }
    public void UpgradeTurret()
    {
        if (playerStats.Money < TurretBlueprint.Upgradecost)
        {
            BuildManager.FreezeTime();
            return;
        }
        playerStats.Money -= TurretBlueprint.Upgradecost;
        Destroy(turret);
        GameObject _turret = Instantiate(TurretBlueprint.Upgradedprefab, BuildPosition(), Quaternion.identity);
        turret = _turret;
        GameObject effect = Instantiate(BuildManager.buildeffect, BuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        IsUpgraded = true;
    }
    public void SellTurret()
    {
        playerStats.Money += TurretBlueprint.GetTurretCost();
        Destroy(turret);
        TurretBlueprint = null;
        GameObject effect = Instantiate(BuildManager.Selleffect, BuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        IsUpgraded = false;
    }
    private void OnMouseEnter()
    {
        if (!BuildManager.CanBuild)
        {
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (BuildManager.HasMoney)
        {
            rendeer.material.color = OnHover;
        }
        else
        {
            rendeer.material.color = PoorColor;
        }
        
    }
    private void OnMouseExit()
    {
        rendeer.material.color = AfterHover;
    }
    public void Close()
    {
        poor.SetActive(false);
    }
}