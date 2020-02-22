using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementO : MonoBehaviour
{
    /*
    [Header("State Machine")]
    public PlayerState currentState;

    [Header("Rigidbody and Animators")]
    private Rigidbody2D myRigidbody;
    private Animator animator;

    [Header("Player Stats/Inv")]
    public float speed;

    //TODO Break off the health system into it's own component
    //public FloatValue currentHealth;
    //public FancySignal playerHealthSignal;

    //TODO Break off the player inventory system into it's own component
    public Inventory playerInventory;

    [Header("Initial Conditions")]
    public VectorValue startingPosition;

    [Header("Actions towards Player")]
    public SpriteRenderer receivedItemSprite;
    //TODO Playerhit should be part of health system?
    public Notification myNotificationHealth;

    //TODO Playermagic should be part of magic system
    public Notification myNotificationMagic;
    private Vector3 change;

    //TODO Break this off with the player ability system
    [Header("Projectile Stuff")]
    public GameObject projectile;
    public InventoryItem bow;

    //TODO Break off the IFrame Stuff into its own script
    [Header("IFrame Stuff")]
    public Color flashColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D triggerCollider;
    public SpriteRenderer mySprite;

    // Start is called before the first frame update
    void Start()
    {
        //Initializes player in walk state
        currentState = PlayerState.walk;
        //Sets up animator and rigidbodys
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        //Sets up character looking downward
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is interacting with something
        if(currentState == PlayerState.interact)
        {
            //Do nothing
            return;
        }
        //Normalize and get input
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        //If the player is attacking, they are not already executing an attack, and they are not staggered
        if (Input.GetButtonDown("Weapon Attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            //Begin attack
            StartCoroutine(AttackCo());
        }
        else if(Input.GetButtonDown("Ability") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            if(playerInventory.CheckForItem(bow))
            {
                //Begin shooting arrow
                StartCoroutine(SecondAttackCo());
            }
        }
        else
        {
            //If the player is walking or standing still
            if (currentState == PlayerState.walk || currentState == PlayerState.idle)
            {
                //Animate appropriately
                UpdateAnimationAndMove();
            }
        }
    }

    //Ranged Attack Coroutine
    private IEnumerator SecondAttackCo()
    {
        //Set state to attack
        currentState = PlayerState.attack;
        //Finish attack
        yield return null;
        //Create the projectile
        MakeArrow();
        //Give delay before being able to attack again
        yield return new WaitForSeconds(0.3f);
        //If the player does not immediately start interacting with something
        if (currentState != PlayerState.interact)
        {
            //Set state to walking
            currentState = PlayerState.walk;
        }
    }

    //TODO This should apart of the ability itself
    private void MakeArrow()
    {
        if(playerInventory.currentMagic > 0)
        {
            Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
            Arrow arrow = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Arrow>();
            arrow.Setup(temp, ChooseArrowDirection());
            playerInventory.ReduceMagic(arrow.magicCost);
            myNotificationMagic.Raise();
        }
    }

    //TODO This should also apart of the ability itself
    Vector3 ChooseArrowDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    //Method for when player receives an item
    public void RaiseItem()
    {
        //If the item exists
        if (playerInventory.currentItem != null)
        {
            //If the player is interacting
            if (currentState != PlayerState.interact)
            {
                //Set animator variable to true
                animator.SetBool("receive item", true);
                //Set the player state to interact
                currentState = PlayerState.interact;
                //Assign the sprite
                receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                //Set animator variable to false
                animator.SetBool("receive item", false);
                //Return player state to idle
                currentState = PlayerState.idle;
                //Do not assign sprite and set item to null
                receivedItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }

    }

    

    //Function to actually move the player
    void MoveCharacter()
    {
        //Normalize the position change
        change.Normalize();
        //The movement is the original position + the normalized change * the speed * Time
        myRigidbody.MovePosition
        (
            transform.position + change * speed * Time.deltaTime
        );
    }

    */
}
