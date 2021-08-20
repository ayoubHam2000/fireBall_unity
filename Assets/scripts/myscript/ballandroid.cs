using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballandroid : MonoBehaviour
{

    [SerializeField] GameObject built;
    [SerializeField] float force = 10f;
    [SerializeField] float timeBetweenShots = 1;

    private Camera cam;
    private Vector2 pos1;
    private Vector2 pos2;
    private bool pressed;
    private TimeManager timeManager;

    private void Start()
    {
        cam = Camera.main;
        timeManager = FindObjectOfType<TimeManager>();
        StartCoroutine(shot());
    }

    private void Update()
    {
        fixetheball();
    }

    private void fixetheball()
    {
        if (Input.touchCount == 2)
        {
            if (pressed == false)
            {
                timeManager.DoRealTime();
                //pos1 = transform.position;
                pressed = true;
            }
            pos2 = cam.ScreenToWorldPoint(Input.GetTouch(1).position);
            
        }
        else 
        { 
            
            pressed = false;
        }

    }

    private IEnumerator shot()
    {
        while(true)
        { 
            if (pressed == true)
                fire();
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
    private void fire()
    {
        pos1 = transform.position;
        GameObject thebult =  Instantiate(built, pos1, Quaternion.identity);
        Vector2 Direction = pos2 - pos1;
        Direction.Normalize();
        thebult.GetComponent<Rigidbody2D>().velocity = Direction * force;

    }

    
}


