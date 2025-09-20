using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSpawn : MonoBehaviour
{
    public GameObject ObsStage;
    public int cnt = 3;

    public float timeBetSpawnMin = 0.5f;
    public float timeBetSpawnMax = 1.5f;
    private float timeBetSpawn;

    public float yMin = -3.5f;
    public float yMax = 1.5f;
    private float xPos = 20f;

    private GameObject[] pre_Stage;
    private int currentIndex = 0;


    private Vector2 poolPosition = new Vector2(0, -20);
    private float lastSpawnTime;

    private void Start()
    {
        pre_Stage = new GameObject[cnt];


        for(int i = 0; i < cnt; i++)
        {


            pre_Stage[i] = Instantiate(ObsStage, poolPosition, Quaternion.identity);
        }


        lastSpawnTime = 0f;

        timeBetSpawn = 0f;
    }

    private void Update()
    {
        
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        if(Time.time >= lastSpawnTime + timeBetSpawn)
        {

            lastSpawnTime = Time.time;


            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);


            float yPos = Random.Range(yMin, yMax);



            pre_Stage[currentIndex].SetActive(false);
            pre_Stage[currentIndex].SetActive(true);


            pre_Stage[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;


            if(currentIndex >= cnt)
            {
                currentIndex = 0;
            }
        }
    }
}
