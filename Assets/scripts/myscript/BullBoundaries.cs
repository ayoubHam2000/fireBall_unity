using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullBoundaries : MonoBehaviour
{
    private float minX;
    private float maxX;
    private float maxY;
    private float minY;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        
    }

    private void SetBoundariesLimiter()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }
}
