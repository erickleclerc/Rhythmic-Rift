using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyBox());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            //If rhythm timing bool isOnBeat == true .... Destroy and add points
            Destroy(gameObject);
        }
    }


    IEnumerator DestroyBox()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
