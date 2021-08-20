using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class testball : MonoBehaviour
{
    public float power;
    public TimeManager timeManager;
    public GameObject dieEffect;

    [Range(0, 1)] [SerializeField] float shotBallVolume; 

    private Rigidbody2D rb;
    private Vector3 startPos;
    private Vector3 endPos;
    private Camera cam;
    private Vector3 direction;
    private linecurve directionvisial;
    private CameraShaking camShaking;
    private ManageUi manageUI;
    private SoundManagement soundManagement;
    // Start is called before the first frame update
    void Start()
    {
        soundManagement = FindObjectOfType<SoundManagement>();
        camShaking = FindObjectOfType<CameraShaking>();
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        directionvisial = FindObjectOfType<linecurve>();
        manageUI = FindObjectOfType<ManageUi>();
    }

    // Update is called once per frame

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            timeManager.DoSlowmotion();
            directionvisial.Switch(true);
            startPos = cam.ScreenToWorldPoint(Input.mousePosition);
            
        }

        if (Input.GetMouseButton(0))
        {
            
            endPos = cam.ScreenToWorldPoint(Input.mousePosition);
            direction = startPos - endPos;
            if (direction.magnitude > 20)
            {
                direction = direction.normalized;
                direction = direction * 20;
            }
            directionvisial.VisialLine(direction * power);
                
        }

        if (Input.GetMouseButtonUp(0))
        {
            
            
            //rb.AddForce(direction * power);
    
            rb.velocity = direction * power;
            directionvisial.Switch(false);
            timeManager.DoRealTime();
            AudioSource.PlayClipAtPoint(soundManagement.ballShot, cam.transform.position, soundManagement.ballShotVolume);
            //Debug.Log(direction.magnitude);
        }
    }

    public void Die()
    {
        manageUI.DieUi();
        Instantiate(dieEffect, transform.position, Quaternion.identity);
        camShaking.shakeDuration = 0.25f;
        AudioSource.PlayClipAtPoint(soundManagement.ballDie, cam.transform.position, soundManagement.ballDieVolume);
        Destroy(gameObject);
    }
}
