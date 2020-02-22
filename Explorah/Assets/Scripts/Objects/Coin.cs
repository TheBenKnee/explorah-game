﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Powerup
{
    public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        //myPowerupNotification.Raise();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInventory.coins++;
            myPowerupNotification.Raise();
            Destroy(this.gameObject);
        }
    }
}
