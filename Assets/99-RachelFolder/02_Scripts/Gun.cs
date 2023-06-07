using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;
    public Transform barrel;
    public float bulletSpeed;
    public AudioClip audio;
    public AudioSource audioSource;

    public void Fire()
    {
        GameObject b = Instantiate(Bullet, barrel.position, Quaternion.identity);
        b.GetComponent<Rigidbody>().velocity = bulletSpeed * barrel.forward;
        audioSource.PlayOneShot(audio);
    }
}
