using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public float speed = 5;
    void Update()
    {
        // float h = Input.GetAxisRaw("Horizontal");
        // float v = Input.GetAxisRaw("Vertical");
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        if (h != 0.0f || v != 0.0f)
        {
            Vector3 dir = h * Vector3.right + v * Vector3.forward;
            transform.rotation = Quaternion.LookRotation(dir);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            GetComponent<Animator>().SetBool("bMove", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("bMove", false);
        }
    }
}
