using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerMovement : SimpleFollow
{
    protected StateMachine myStateMachine;
    protected AnimatorController myAnim;

    [Header("Targetting Variables")]
    private Transform target;
    private Transform latestAttacker;
    private Transform following;
    [SerializeField] private float followRadius;
    [SerializeField] private float closeRadius;
    private bool hasTarget = false;
    private GameObject[] respwanList;
    private Room myRoom;

    public override void Awake()
    {
        base.Awake();
        //Initializing the NPC to following the player (can be editted to follow something else)
        following = GameObject.FindWithTag("Player").transform;
        //Setting up the state machine
        myStateMachine = GetComponent<StateMachine>();
    }

    public virtual void FixedUpdate()
    {
        //If the NPC is not too far from the player and there is an enemy in range and that enemy is not outside of the radius the NPC can be from the player
        if (notTooFar() && enemyInRange())
        {
            chooseTarget();
            //If the enemy is within the NPC's attack range
            if (enemyInAttackRange())
            {
                //Attack
                myStateMachine.ChangeState(GenericState.attack);
            }
            else
            {
                //Move towards enemy
                myStateMachine.ChangeState(GenericState.walk);
                advanceTowardsOther(target);
            }
        }
        else
        {
            //If the NPC is close enough to the player to stand still
            if (closeToPlayer())
            {
                //Idle
                myStateMachine.ChangeState(GenericState.idle);
            }
            else
            {
                //Follow player
                myStateMachine.ChangeState(GenericState.walk);
                advanceTowardsOther(following);
            }
        }
    }


    //Moves the NPC towards a transform (gameobject) passed by the parameter
    private void advanceTowardsOther(Transform location)
    {
        //Create a temp 
        Vector3 temp = Vector3.MoveTowards(transform.position, location.position, Time.deltaTime); //, moveSpeed * Time.deltaTime
        //Animate the NPC moving in that direction
        myAnim.changeAnim(temp - transform.position);
        //Move the actual rigidbody towards that position
        myRigidbody.MovePosition(temp);
        //Change the state to walk
        myStateMachine.ChangeState(GenericState.walk);
    }

    //Returns (true/false) if the target is within the attack radius of the NPC
    private bool enemyInAttackRange()
    {
        return (Vector3.Distance(target.position, transform.position) < attackRadius);
    }

    //Returns (true/false) if there is an enemy within the chase radius of the NPC and if the enemy is within the allowed following distance from the following
    private bool enemyInRange()
    {
        //Bool tmp for the return
        bool tmp = false;
        //Loops through all enemies in enemyList (the room's list of enemies)
        for (int i = 0; i < respwanList.Length; i++)
        {
            //If the enemy is within the chase raidus and follow radius of the NPC and Following respectively, change tmp to true and break
            if (Vector3.Distance(respwanList[i].transform.position, transform.position) < chaseRadius &&
                Vector3.Distance(respwanList[i].transform.position, following.position) < followRadius)
            {
                tmp = true;
                break;
            }
        }
        return (tmp);
    }

    //Returns (true/false) if the distance between the NPC and the individual they're following is less than the closeRadius
    private bool closeToPlayer()
    {
        return (Vector3.Distance(following.position, transform.position) < closeRadius);
    }

    //Returns (true/false) if the distance between the NPC and the individual they're following is less than the followRadius
    private bool notTooFar()
    {
        return (Vector3.Distance(following.position, transform.position) < followRadius);
    }

    //Selects a target. If there is a target, make sure the NPC was not damaged by another, if it was switch targets. If there is no target, selected the closest enemy.
    private void chooseTarget()
    {
        //If the NPC has no target
        if (!hasTarget)
        {
            //Set target to the closest enemy
            target = returnClosest();
            //Communicate that there is a target
            hasTarget = true;
        }
        else
        {
            //If there is a target and it is not the latest enemy to attack the NPC
            if (latestAttacker != target)
            {
                //Switch the target to the latest attacker
                target = latestAttacker;
            }
        }
    }

    //Returns the closest enemy as a Transform
    private Transform returnClosest()
    {
        //Create a temp Transform to return
        Transform temp;
        temp = respwanList[0].transform;
        //Loops through all enemies in enemyList (the room's list of enemies)
        for (int i = 1; i < respwanList.Length; i++)
        {
            //If the distance between the NPC and the enemy is less than the distance between the NPC and the temporary enemy, replace the temporary enemy with the current enemy 
            if (Vector3.Distance(respwanList[i].transform.position, transform.position) < Vector3.Distance(temp.transform.position, transform.position))
            {
                temp = respwanList[i].transform;
            }
        }
        //Return the closest enemy
        return temp;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        //If the collider has a Player tag, it is a player. Also make sure it is not the trigger collider
        //base.OnTriggerEnter2D(other);
        //If the collider has a room tag, it means the NPC is transitioning rooms
        if (other.CompareTag("room") && !other.isTrigger)
        {
            //Get the new enemy list from the new room
            myRoom = other.GetComponent<Room>();
            respwanList = myRoom.respawnObjects;
        }
    }
}
