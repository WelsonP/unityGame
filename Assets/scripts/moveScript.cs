using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    Animator anim; 

    // Use this for initialization
    void Start()
    {
        anim =  GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            anim.SetInteger("Orientation", 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("Orientation", 1);
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("Orientation", 2);
        } 
    }

    
}
