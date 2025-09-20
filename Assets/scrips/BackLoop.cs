using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLoop : MonoBehaviour
{
    private float width;
    private void Awake()
    {
        BoxCollider2D backcoll = GetComponent<BoxCollider2D>();
        width = backcoll.size.x;
    }
    void Update()
    {
        if(transform.position.x <= -width)
        {
            ReGround();
        }
    }
    private void ReGround()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
