using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int TowerCost=50;
    public bool CreateTower(Tower tower,Vector3 towerposition)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null) { return false; }
        if (bank.GetCurrentBalance >= TowerCost)
        { Instantiate(tower, towerposition, Quaternion.identity);bank.Withdrawal(TowerCost);return true; }
        return false;
    }
}
