using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactable
{
    /*
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;

    private void Update()
    {
        if(Input.GetButtonDown("attack"))
        {
            if(playerInRange && thisDoorType == DoorType.key)
            {
                //Test if player has a key
                if(playerInventory.numberOfKeys > 0)
                {
                    //Remove a key
                    playerInventory.numberOfKeys--;
                    //If so call open method
                    Open();
                }
            }
        }
    }

    public void Open()
    {
        //Turn off the door's sprite renderer
        doorSprite.enabled = false;
        //Set open = true
        open = true;
        //Turn off the door's box collider
        physicsCollider.enabled = false;
    }

    public void Close()
    {
        //Turn on the door's sprite renderer
        doorSprite.enabled = true;
        //Set open = false
        open = false;
        //Turn on the door's box collider
        physicsCollider.enabled = true;
    }
    */
}
