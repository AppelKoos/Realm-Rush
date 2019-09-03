using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTowers : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    public bool isPlacable = true;

    private void PlaceTower()
    {
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
        isPlacable = false;
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlacable)
            {
                PlaceTower();
            }
            else
            {
                print("Cannot place at" + gameObject.name);
            }
        }
    }
}
