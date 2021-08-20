using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

   
    public GameObject preffect;


    private CameraShaking camShaking;
    private ControlTarget targetList;
    private Camera cam;
    private ManageUi score;
    private SoundManagement soundManagement;
    private GameManagement gameManagement;

    // Start is called before the first frame update
    void Start()
    {
        gameManagement = FindObjectOfType<GameManagement>();
        soundManagement = FindObjectOfType<SoundManagement>();
        cam = Camera.main;
        camShaking = FindObjectOfType<CameraShaking>();
        targetList = FindObjectOfType<ControlTarget>();
        score = FindObjectOfType<ManageUi>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    public void Die()
    {
        int wallInstantiate = Random.Range(0, 10);
        if (wallInstantiate == 1)
        {
            targetList.CreatInfinitTarget();
            targetList.CreatInfinitTarget();
        }
        else if (wallInstantiate != 0 || gameManagement.wallNumber == 0)
            targetList.CreatInfinitTarget();
        //targetList.creatTarget(targetList.i);

        Instantiate(preffect, transform.position, Quaternion.identity);
        camShaking.shakeDuration = 0.25f;
        AudioClip[] breakSound = soundManagement.wallBreak;
        AudioSource.PlayClipAtPoint(breakSound[(int)Random.Range(0, breakSound.Length)], cam.transform.position, soundManagement.wallBreakVolume);
        score.updateScore(targetList.i);
        gameManagement.wallNumber--;
        Destroy(gameObject);

    }
}
