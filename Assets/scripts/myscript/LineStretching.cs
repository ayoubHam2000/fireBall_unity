using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineStretching : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    Camera gcamera = null;
    LineRenderer lr;

    Vector3 camOffset = new Vector3(0, 0, 10);
    [SerializeField] AnimationCurve ac = null;
    // Start is called before the first frame update
    void Start()
    {
        gcamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        LineStretche();
    }

    void LineStretche()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (lr == null)
            {
                lr = gameObject.AddComponent<LineRenderer>();
            }
            lr.enabled = true;
            lr.positionCount = 2;
            startPos = gcamera.ScreenToWorldPoint(Input.mousePosition) + camOffset;
            lr.SetPosition(0, startPos);
            lr.useWorldSpace = true;
            lr.widthCurve = ac;
            lr.numCapVertices = 10;
            
        }

        if (Input.GetMouseButton(0))
        {
            endPos = gcamera.ScreenToWorldPoint(Input.mousePosition) + camOffset;
            lr.SetPosition(1, endPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lr.enabled = false;
        }

    }

}
