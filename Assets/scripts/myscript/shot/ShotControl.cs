using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        testball isBall = collision.gameObject.GetComponent<testball>();
        if (isBall != null)
        {
            isBall.Die();
        }
        Destroy(gameObject);
    }
}
