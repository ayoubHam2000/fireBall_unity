using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1;

    private Transform theBall;
    // Start is called before the first frame update
    void Start()
    {
        theBall = FindObjectOfType<testball>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (theBall != null)
            RotationToTheMouse(theBall.position);
    }

    void RotationToTheMouse(Vector3 Target)
    {
        var distance = Target - transform.position;
        var angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
