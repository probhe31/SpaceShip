using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UpgradeSO
{
    public eUpgrade upgrade;
    //public Money price;
    public List<Money> upgradesPrices;
    public string key_name;
    public string key_description;
    public GameObject prefabUpgradeGO;
    public int upgradesToUnlock;

}


[CreateAssetMenu(fileName = "GameUpgrades", menuName = "Claus/GameUpgrades", order = 3)]
public class GameUpgrades : ScriptableObject
{
    public List<UpgradeSO> upgrades;

}
