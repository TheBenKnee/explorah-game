using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTimeN : MonoBehaviour
{
    [SerializeField] private float destroyDelay;

    private void Update()
    {
        destroyDelay -= Time.deltaTime;
        if (destroyDelay <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}