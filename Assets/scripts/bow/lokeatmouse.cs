using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lokeatmouse : MonoBehaviour
{
    public LineRenderer bowStringLineRenderer1;
    public LineRenderer bowStringLineRenderer2;
    public GameObject test; 
    public float speed;


    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotationToTheMouse();
        BowstringControl();

    }

    void RotationToTheMouse()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var distance = mousePos - transform.position;
        var angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    void BowstringControl()
    {
        var pos2 = -mousePos + bowStringLineRenderer1.transform.position;
        var pos3 = -mousePos + bowStringLineRenderer2.transform.position;
        bowStringLineRenderer1.SetPosition(0, new Vector2(pos2.x, pos2.y));
        bowStringLineRenderer2.SetPosition(1, new Vector2(pos3.x, pos3.y));
        test.transform.position = new Vector2(mousePos.x, mousePos.y);
    }

}
