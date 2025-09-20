using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject obj;
    public float time;
    public Transform[] point;
    public int Max;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Create", time, time); // InvokeRepeating은 반복해서 함수를 부름, Create 함수를 time 초마다 실행
    }

    void Create()
    {
        if (count >= Max)
            return;
        count++; // count를 1 증가
        int i = Random.Range(0, point.Length); // 값1~값2 사이의 값을 랜덤하게 구함
        Instantiate(obj, point[i]); // 프리팹을 원본삼아 특정 위치에 게임 오브젝트 생성
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
