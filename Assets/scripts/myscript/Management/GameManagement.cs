using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public int maxWall;
    [Range(0,3599)] public int time;
    public int enemynumber;
    [HideInInspector]
    public int wallNumber;
    public int enemymaxnumber = 2;

    private void Start()
    {
        enemynumber = 0;
        wallNumber = 0;
    }

}
