using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParent;

    Queue<Tower> placedTowers = new Queue<Tower>();

    int towerCount = 0;

    public void AddTower(PlaceTowers baseTowerPlacement)
    {
        towerCount = placedTowers.Count;
        if (towerCount > towerLimit -1)
        {
            MoveExistingTower(baseTowerPlacement);
        }
        else
        {
            InstantiateTower(baseTowerPlacement);
        }
    }

    private void MoveExistingTower(PlaceTowers newTowerBasePlacement)
    {
        var oldTower = placedTowers.Dequeue();
        oldTower.towerBase.isPlacable = true;
        newTowerBasePlacement.isPlacable = false;
        oldTower.towerBase = newTowerBasePlacement;
        oldTower.transform.position = newTowerBasePlacement.transform.position;
        placedTowers.Enqueue(oldTower);
    }

    private void InstantiateTower(PlaceTowers baseTowerPlacement)
    {
        var newTower = Instantiate(towerPrefab, baseTowerPlacement.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParent;
        newTower.towerBase = baseTowerPlacement;
        baseTowerPlacement.isPlacable = false;
        placedTowers.Enqueue(newTower);
    }
}
