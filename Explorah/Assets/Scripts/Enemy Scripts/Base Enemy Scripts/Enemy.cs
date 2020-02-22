using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("State Machine")]
    protected StateMachine myStateMachine;
    protected AnimatorController anim;

    [Header("Enemy Stats")]
    public string enemyName;
    [SerializeField] protected ResetToPosition homePosition;

    private void Awake()
    {
        myStateMachine = GetComponent<StateMachine>();
        anim = GetComponent<AnimatorController>();
        homePosition.SetPosition(transform.position);
        myStateMachine.ChangeState(GenericState.idle);
    }

    public virtual void OnEnable()
    {
        homePosition.ResetPosition();
        myStateMachine.ChangeState(GenericState.idle);
    }
}
