using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReaction : MonoBehaviour
{
    public FloatValue playerHealth;
    public Notification myNotification;

    public void Use(int amountToIncrease)
    {
        playerHealth.value += amountToIncrease;
        myNotification.Raise();
    }
}
