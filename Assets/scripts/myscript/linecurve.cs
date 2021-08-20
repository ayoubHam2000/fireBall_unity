using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linecurve : MonoBehaviour
{
    public int lineSegment;
    [Range(1,50)]public float smooth;
    [SerializeField] AnimationCurve ac = null;

    private LineRenderer lineVisual;
    private void Start()
    {
        //lineVisual = gameObject.AddComponent<LineRenderer>();
        lineVisual = gameObject.GetComponent<LineRenderer>();
        lineVisual.positionCount = lineSegment;
        lineVisual.widthCurve = ac;
        lineVisual.numCapVertices = 10;

    }

    public void Switch(bool niv)
    {
        if (niv == true)
        {
            lineVisual.enabled = niv;
        }
        else 
        {
            lineVisual.enabled = niv;
        }
    }

    public void VisialLine(Vector3 vvolocity)
    {
        for (int i = 0; i < lineSegment; i++)
        {
            Vector2 pos = LineByTime(vvolocity, i / smooth);
            lineVisual.SetPosition(i, pos);
        }
    }


    private Vector2 LineByTime(Vector3 vvolocity, float time)
    {
        Vector2 newVlocity;
        newVlocity.x = vvolocity.x * time + transform.position.x;
        newVlocity.y = (Physics2D.gravity.y * 2) * 0.5f * time * time + vvolocity.y * time + transform.position.y;
        return (newVlocity);
    }

}
