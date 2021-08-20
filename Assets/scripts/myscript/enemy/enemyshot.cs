using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshot : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Transform parentRotation;
    [Range(0, 1)] [SerializeField] float shotVolume;
    public float shotSpeed;
    public GameObject shotPrefab;
    public float timeBetweenShots;
    public float aimAccuracy;

    private Transform theBall;
    private SoundManagement soundManagement;

    private void Start()
    {
        soundManagement = FindObjectOfType<SoundManagement>();
        theBall = FindObjectOfType<testball>().gameObject.transform;
        Invoke("startshot", 1f);
       
    }

    private void startshot()
    {
        StartCoroutine(Eshot());
    }

    IEnumerator Eshot()
    {
        while (true)
        {
            
            if (theBall == null)
            {
                StopCoroutine(Eshot());
                break;
            }
            else 
            {
                anim.SetBool("shot", true);
                GameObject theShot = Instantiate(shotPrefab, transform.position, Quaternion.identity);
                //Vector3 Direction = theBall.position - transform.position + Random.insideUnitSphere * aimAccuracy;
                //Direction.z = 0;
                //Direction = Direction.normalized * shotSpeed;
                float angle = parentRotation.rotation.eulerAngles.z * Mathf.Deg2Rad;
                Vector2 Direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * shotSpeed;
                theShot.GetComponent<Rigidbody2D>().velocity = Direction;
                AudioSource.PlayClipAtPoint(soundManagement.enemyShot, Camera.main.transform.position, soundManagement.enemyShotVolume);
            }
            yield return new WaitForSeconds(0.1f);
            anim.SetBool("shot", false);

            yield return new WaitForSeconds(timeBetweenShots);
        }
    }

   
}
