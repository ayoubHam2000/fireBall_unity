using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buitScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.tag == "wall")
            collision.GetComponent<TargetScript>().Die();
        else if (collision.tag == "enemy1")
            collision.GetComponent<enemy1>().Die();
    }
}
