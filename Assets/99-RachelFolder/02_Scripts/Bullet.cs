using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject spark;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box") 
        {
            GameObject.Destroy(collision.gameObject);
            GameObject.Destroy(gameObject);

            GameObject S = Instantiate(spark, collision.gameObject.transform.position, Quaternion.identity);
        }
    }

}
