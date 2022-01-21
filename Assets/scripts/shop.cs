using UnityEngine;

public class shop : MonoBehaviour
{
    buildManager build;
    public TurretBluePrint standardTurret;
    public TurretBluePrint MissileLauncher;
    public TurretBluePrint LaserBeamer;
    private void Start()
    {
        
        build = buildManager.instance;
    }
    public void SelectStandardTurret()
    {
        build.selectTurretToBuild(standardTurret);
    }public void SelectMissileTurret()
    {
        build.selectTurretToBuild(MissileLauncher);
    }
    public void SelectLaserBeamer()
    {
        build.selectTurretToBuild(LaserBeamer);
    }
}