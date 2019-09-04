using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Text hitPoints;
    [SerializeField] int playerHitpoints = 10;
    [SerializeField] int hitpointDecrease = 1;

    private void Start()
    {
        UpdateHitpointText();
    }
    private void OnTriggerEnter(Collider other)
    {
        playerHitpoints = playerHitpoints - hitpointDecrease;
        UpdateHitpointText();
    }
    private void UpdateHitpointText()
    {
        hitPoints.text = playerHitpoints.ToString();
    }
}
