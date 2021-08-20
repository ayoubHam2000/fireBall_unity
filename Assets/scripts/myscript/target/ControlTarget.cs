using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTarget : MonoBehaviour
{
    [SerializeField] GameObject maintargetPos = null;
    [SerializeField] GameObject theTarget = null;
    [SerializeField] GameObject enemy = null;
    [SerializeField] int maxHard;
    [SerializeField] float zone;
    [SerializeField] Vector2 BoundariesX;
    [SerializeField] Vector2 BoundariesY;
    public int i;


    private GameManagement gameManagement;
    private int targetNumber;
    private List<Transform> targetPos;
    private Vector2 setPos;
    private Quaternion rotation;



    void Start()
    {
        gameManagement = FindObjectOfType<GameManagement>();
        rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, 90);
        i = 0;
        
        targetPos = new List<Transform>();
       // MakeListOfTarget();
        targetNumber = targetPos.Count;
    }


    private void MakeListOfTarget()
    {
        foreach (Transform child in maintargetPos.transform)
        {
            targetPos.Add(child);
        }
    }

    public void creatTarget(int i)
    {
        if (i < targetNumber) 
        { 
            setPos.x = Random.Range(targetPos[i].position.x - BoundariesX.x, targetPos[i].position.x + BoundariesX.y);
            setPos.y = Random.Range(targetPos[i].position.y - BoundariesY.x, targetPos[i].position.y + BoundariesY.y);
            var rotation = new Quaternion();
            rotation.eulerAngles = new Vector3(0, 0, 90);
            Instantiate(theTarget, setPos, rotation);
            this.i++;
        }
    }

    public void CreatInfinitTarget()
    {
        
        if (gameManagement.wallNumber < gameManagement.maxWall)
        {
            setPos = Random.insideUnitCircle * zone;
            Instantiate(theTarget, setPos, rotation);
            gameManagement.wallNumber++;
            i++;
            MakeLevelHarder();
        }
    }

    private void MakeLevelHarder()
    {
        if (i % 10 == 0 && i < 10 * maxHard)
        {
            setPos = Random.insideUnitCircle * (zone + 2);
            int j = i / 10;
            while (j != 0)
            {
                
                Invoke("creatEnemy", j * 2);
                j--;
            }
            enemyshot[] shotGenerator = FindObjectsOfType<enemyshot>();
            int count = shotGenerator.Length;
            for (j = 0; j < count; j++)
            {
                shotGenerator[j].shotSpeed += 1f;
            }
            gameManagement.enemymaxnumber++;
        }
    }

    public void creatEnemy()
    {
        if (gameManagement.enemynumber < gameManagement.enemymaxnumber) { 
        setPos = Random.insideUnitCircle * (zone + 2);
        Instantiate(enemy, setPos, Quaternion.identity);
        gameManagement.enemynumber++;
        }
    }
}
