using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{
    [Header("Ball")]
    public AudioClip ballShot;
    [Range(0,1)] public float ballShotVolume;
    public AudioClip ballDie;
    [Range(0, 1)] public float ballDieVolume;


    [Header("Enemies")]
    public AudioClip enemyShot;
    [Range(0, 1)] public float enemyShotVolume;
    public AudioClip enemyDie_1;
    [Range(0, 1)] public float enemyDie_1Volume;

    [Header("Staff")]
    public AudioClip[] wallBreak;
    [Range(0, 1)] public float wallBreakVolume;


}
