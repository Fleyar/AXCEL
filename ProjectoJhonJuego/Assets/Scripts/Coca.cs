using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coca : MonoBehaviour
{
    public float cocaToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DrugsScript.instance.Drug(cocaToGive);
            Destroy(gameObject);
        }
    }
}
