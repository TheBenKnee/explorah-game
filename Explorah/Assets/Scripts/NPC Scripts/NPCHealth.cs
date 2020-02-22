using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHealth : Health
{
    private StateMachine thisStateMachine;

    public override void Damage(int damage)
    {
        base.Damage(damage);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        thisStateMachine = GetComponent<StateMachine>();
    }

    void Die()
    {
        thisStateMachine.ChangeState(GenericState.dead);
    }
}
