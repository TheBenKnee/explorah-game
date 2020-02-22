using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Powerup
{
    public PlayerHealth playerHealth;
    public int amountToIncrease;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.Heal(amountToIncrease);
            myPowerupNotification.Raise();
            Destroy(this.gameObject);
        }
    }
}
