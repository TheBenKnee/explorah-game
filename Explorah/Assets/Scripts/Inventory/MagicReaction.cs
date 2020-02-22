using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicReaction : MonoBehaviour
{
    public FloatValue playerMagic;
    public Notification myNotification;

    public void Use(int amountToIncrease)
    {
        playerMagic.value += amountToIncrease;
        myNotification.Raise();
    }
}
