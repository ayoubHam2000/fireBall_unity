using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemies : MonoBehaviour
{
    [SerializeField] float zone = 20;
    [SerializeField] Transform theEnemy;

    private Vector2 setPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TargetScript>())
        {
            setPos = Random.insideUnitCircle * (zone + 2);
            theEnemy.position = setPos;
        }
    }

}
