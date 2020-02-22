using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : Interactable
{
    [SerializeField] private Notification signNotification;
    [SerializeField] private StringValue signText;
    [SerializeField] private string newSignText;
    [SerializeField] private bool dialogActive = false;

    // Update is called once per frame
    public virtual void Update()
    {
        if (playerInRange)
        {
            if (Input.GetButtonDown("Interact"))
            {
                dialogActive = !dialogActive;
                signText.value = newSignText;
                signNotification.Raise();
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            if (dialogActive)
            {
                dialogActive = !dialogActive;
                signNotification.Raise();
            }
        }
    }

}