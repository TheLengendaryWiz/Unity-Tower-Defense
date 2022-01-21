using UnityEngine;
[System.Serializable]
public class TurretBluePrint{
    public GameObject prefab;
    public int cost;
    public int Upgradecost;
    public GameObject Upgradedprefab; 
    public int GetTurretCost()
    {
        return cost/2;
    }
}