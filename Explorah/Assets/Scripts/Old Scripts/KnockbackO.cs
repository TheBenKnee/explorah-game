using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KnockbackO : MonoBehaviour
{
    /*
    [SerializeField] private float thrust;
    [SerializeField] private float knockTime;
    [SerializeField] private string otherTag;
    //public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Pot>().Smash();
        }
        if (other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {
            Rigidbody2D hit = other.GetComponentInParent<Rigidbody2D>();
            if (hit != null)
            {
                Vector3 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.DOMove(hit.transform.position + difference, knockTime);
                //hit.AddForce(difference, ForceMode2D.Impulse);
                if(other.GetComponentInParent<PlayerMovement>().currentState != PlayerState.stagger)
                {
                    hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    other.GetComponentInParent<PlayerMovement>().Knock(knockTime);
                }
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
        }
    }
    */

}
