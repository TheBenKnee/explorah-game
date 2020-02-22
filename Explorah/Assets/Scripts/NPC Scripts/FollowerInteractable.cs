using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerInteractable : NPCInteractable
{
    protected NPCHealth myHealth;
    protected StateMachine myStateMachine;

    // Start is called before the first frame update
    void Start()
    {
        myHealth = GetComponent<NPCHealth>();
        myStateMachine = GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void FixedUpdate()
    {
        //As long as the NPC is not defeated
        if (myStateMachine.myState != GenericState.dead && myStateMachine.myState != GenericState.attack && myStateMachine.myState != GenericState.stun)
        {
            //If player is interacting with NPC
            if (Input.GetButtonDown("interact") && playerInRange)
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
            else
            {

            }
        }
        //If the NPC is defeated...
        else
        {
            if (Input.GetButtonDown("interact") && playerInRange && myStateMachine.myState != GenericState.dead)
            {
                //Revive
                myHealth.FullHeal();
                myStateMachine.ChangeState(GenericState.idle);
            }
        }
    }
}
