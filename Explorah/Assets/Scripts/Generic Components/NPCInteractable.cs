using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteractable : Interactable
{
    [Header("Dialog Variables")]
    [SerializeField] protected GameObject dialogBox;
    public Text dialogText;
    [SerializeField] protected string dialog;

    protected StateMachine myStateMachine;

    public void Start()
    {
        myStateMachine = GetComponent<StateMachine>();
    }

    protected virtual void FixedUpdate()
    {
        //If player is interacting with NPC
        if (Input.GetButtonDown("interact") && playerInRange && myStateMachine.myState != GenericState.attack && myStateMachine.myState != GenericState.stun)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                //Unpause
            }
            else
            {
                //Pause
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        //If the collider has a Player tag, it is a player. Also make sure it is not the trigger collider
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Raise the context to make the interactable inidication pop up
            contextClueNotification.Raise();
            //Communicate that the player is in range
            playerInRange = true;
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        //If the collider has a Player tag (and is not the trigger) it means the Player/NPC is walking out of range
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Raise the context to make the interactable inidication disable
            contextClueNotification.Raise();
            //Communicate that the player is out of range
            playerInRange = false;
            //Disable the dialog box in case the player hasn't
            dialogBox.SetActive(false);
        }
    }
}
