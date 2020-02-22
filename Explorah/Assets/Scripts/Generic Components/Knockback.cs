using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Knockback : MonoBehaviour
{

    [SerializeField] public string otherTag;
    [SerializeField] public float knockTime;
    [SerializeField] public float knockStrength;
    [SerializeField] private bool isComp;
    private Knockback daddyKnock;

    void Awake()
    {
        if (isComp)
        {
            daddyKnock = this.transform.parent.GetComponent<Knockback>();
            otherTag = daddyKnock.otherTag;
            knockTime = daddyKnock.knockTime;
            knockStrength = daddyKnock.knockStrength;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {
            Rigidbody2D temp = other.GetComponentInParent<Rigidbody2D>();
            if (temp)
            {
                Vector2 direction = other.transform.position - transform.position;
                temp.DOMove((Vector2)other.transform.position + (direction.normalized * knockStrength), knockTime);
            }
        }
    }
}