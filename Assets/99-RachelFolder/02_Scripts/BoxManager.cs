using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public Transform Player;
    public GameObject redPrefab;
    public GameObject bluePrefab;
    public Transform pos1;
    public Transform pos2;

    public float timeToMakeBox;
    public float speed;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > timeToMakeBox) 
        {
            int rand = Random.Range(0, 2);

            if (rand == 0 ) 
            {
                CreateBox(redPrefab, pos1);
            }
            else 
            {
                CreateBox(bluePrefab, pos2);
            }

            timer = 0;
        }
    }

    void CreateBox(GameObject box, Transform pos)
    {
        GameObject b = Instantiate(box, pos.position, Quaternion.identity);
        //b.GetComponent<Rigidbody>().velocity = speed * (Player.transform.position - pos.position);
    }
}
