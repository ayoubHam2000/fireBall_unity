using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] GameObject deathEffect;
    // Start is called before the first frame update


    private Animator anim;
    private SoundManagement soundManagement;
    private Camera cam;
    private GameManagement gameManagement;

    private void Start()
    {
        cam = Camera.main;
        soundManagement = FindObjectOfType<SoundManagement>();
        gameManagement = FindObjectOfType<GameManagement>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    public void Die()
    {
        health -= 10;
        anim.SetBool("hited", true);
        Invoke("Resets", 0.2f);
        if (health < 0)
        {
            AudioSource.PlayClipAtPoint(soundManagement.enemyDie_1, cam.transform.position, soundManagement.enemyDie_1Volume);
            Destroy(gameObject);
            FindObjectOfType<ControlTarget>().creatEnemy();
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            gameManagement.enemynumber--;
        }
    }

    private void Resets()
    {
        anim.SetBool("hited", false);
    }
}
