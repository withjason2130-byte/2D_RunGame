using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyhealth : MonoBehaviour
{
    public int hp = 100;
    public void Damage(int amount)
    {
        if (hp <= 0) return;
        hp -= amount;
        if (hp <= 0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Death");
            Destroy(gameObject, 1);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
