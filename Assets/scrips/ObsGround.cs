using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsGround : MonoBehaviour
{
    public GameObject[] obs;
    private bool is_touched = false;
    private void OnEnable()
    {
        is_touched = false;
        for(int i = 0; i < obs.Length; i++)
        {
            if(Random.Range(0, 3) == 0)
            {
                obs[i].SetActive(true);
            }
            else
            {
                obs[i].SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("터치");
        if(collision.gameObject.tag == "Player" && !is_touched)
        {
            Debug.Log("점수를 얻어라");
            is_touched = true;
            GameManager.instance.Score_Cal(1);
        }
    }
}
