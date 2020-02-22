using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContactO : MonoBehaviour
{

    [SerializeField] private string otherString;
    [SerializeField] private int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(otherString))
        {
            //Check to see if there is health
            Health tmp = other.gameObject.GetComponent<Health>();
            if(tmp)
            {
                tmp.Damage(damage);
            }
            Destroy(this.gameObject);
        }
    }
}
