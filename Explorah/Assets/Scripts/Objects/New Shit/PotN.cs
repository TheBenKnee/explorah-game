using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotN : Health
{
    [SerializeField] private GameObject destroyEffect;

    [Header("Animation Variable")]
    private AnimatorController anim;

    void Awake()
    {
        FullHeal();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            //Setup animator
            anim = GetComponent<AnimatorController>();
            StartCoroutine(breakCo());
        }
    }

    IEnumerator breakCo()
    {
        Debug.Log("Is breaking");
        //Begin pot breaking animation
        anim.SetAnimParameter("smash", true);
        //Wait until the pot is broken (animation wise)
        yield return new WaitForSeconds(.6f);
        //Delete pot
        this.transform.parent.gameObject.SetActive(false);
    }
}