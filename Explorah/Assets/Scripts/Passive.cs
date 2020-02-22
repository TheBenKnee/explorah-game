using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PassiveState
{
    idle,
    walk,
    stagger
}

public class Passive : MonoBehaviour
{
    public PassiveState currentState;
    public FloatValue maxHealth;
    public float health;
    public string passiveName;
    public float moveSpeed;

    private void Awake()
    {
        health = maxHealth.value;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PassiveState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
