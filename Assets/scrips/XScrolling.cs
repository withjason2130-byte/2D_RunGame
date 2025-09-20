using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XScrolling : MonoBehaviour
{

    public float speed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
