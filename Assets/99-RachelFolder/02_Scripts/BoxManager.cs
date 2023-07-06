using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;
public class BoxManager : MonoBehaviour
{
    public Transform Player;
    public GameObject redPrefab;
    public GameObject bluePrefab;
    public GameObject verticalWall;
    public GameObject horizontalWall;
    public Transform pos1A, pos1B, pos1C;
    public Transform pos2A, pos2B, pos2C;
    public Transform pos3A, pos3B, pos3C;
    private Transform[][] spawnPositions;
    public float timeToMakeBox;
    public float speed;
    private float timer;
    private void Start()
    {
        spawnPositions = new Transform[][]
        {
        new Transform[] { pos1A, pos1B, pos1C },
        new Transform[] { pos2A, pos2B, pos2C },
        new Transform[] { pos3A, pos3B, pos3C }
        };
        Debug.Log("spawnPositions[0][2]: " + spawnPositions[0][2].name);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeToMakeBox)
        {
            int randWall = Random.Range(0, 10);
            int randColor = Random.Range(0, 3);
            int randRow1 = Random.Range(0, 3);
            int randCol1 = Random.Range(0, 3);
            Transform pos1 = spawnPositions[randRow1][randCol1];
            int randRow2;
            int randCol2;
            do
            {
                randRow2 = Random.Range(0, 3);
                randCol2 = Random.Range(0, 3);
            }
            while
             (randRow2 == randRow1 && randCol2 == randCol1 || randRow2 != randRow1 && randCol2 != randCol1);
            Transform pos2 = spawnPositions[randRow2][randCol2];

            if (randWall < 7)
            {
                if (randColor == 0)
                {
                    CreateBox(redPrefab, pos1);
                }
                else if (randColor == 1)
                {
                    CreateBox(bluePrefab, pos1);
                }
                else
                {
                    CreateBox(redPrefab, pos1);
                    CreateBox(bluePrefab, pos2);
                }
            }
            
            else if (randWall == 7)
            {
                CreateBox(verticalWall, pos1B);

                if (randColor == 0)
                {
                    CreateBox(redPrefab, spawnPositions[1][0]);
                }
                else if (randColor == 1)
                {
                    CreateBox(bluePrefab, spawnPositions[1][2]);
                }
                else
                {

                }
            }

            else if (randWall == 8)
            {
                CreateBox(horizontalWall, pos1B);

                if (randColor == 0)
                {
                    CreateBox(redPrefab, spawnPositions[2][1]);
                }
                else if (randColor == 1)
                {
                    CreateBox(bluePrefab, spawnPositions[2][1]);
                }
                else
                {

                }
            }

            else if (randWall == 9)
            {
                CreateBox(verticalWall, pos1A);
                CreateBox(verticalWall, pos1C);

                if (randColor == 0)
                {
                    CreateBox(redPrefab, spawnPositions[1][1]);
                }
                else if (randColor == 1)
                {
                    CreateBox(bluePrefab, spawnPositions[1][1]);
                }
                else
                {
                    CreateBox(bluePrefab, spawnPositions[0][1]);
                    CreateBox(redPrefab, spawnPositions[1][1]);
                }
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