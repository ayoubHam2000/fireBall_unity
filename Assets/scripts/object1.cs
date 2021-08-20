using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object1 : MonoBehaviour
{
    [Range(0,0.1f)][SerializeField] float speed;
    [SerializeField] float size = 1;

    private float i;

    private void Start()
    {
        i = 0;
    }

    private void Update()
    {
        i = (i + speed) % (2*Mathf.PI) ;
        transform.position = new Vector2(Mathf.Cos(i) * size, transform.position.y);
    }
}
