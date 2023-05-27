using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int cost = 75; 
    
    public bool CreateTower(Tower tower, Vector3 position)
    {
        var bank = FindObjectOfType<Bank>();

        if (bank == null || bank.CurrentBalance < cost)
            return false;
        
        bank.Withdraw(cost);
        Instantiate(tower.gameObject, position, Quaternion.identity);
        return true;
    }

}