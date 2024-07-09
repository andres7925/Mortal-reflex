using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;

    public int Vitality = 100; 

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {anim.SetBool("Move", true);
        }

        if (Input.GetAxis("Vertical") == 0)
        {anim.SetBool("Move", false);}

        // if ((Input.GetAxis("Vertical") != 0)  && (Input.GetAxis("Fire3") !=0))
        // {
        //     anim.SetBool("Corriendo", true);
        // }

        // if ((Input.GetAxis("Vertical") == 0)  || (Input.GetAxis("Fire3") == 0))
        // {
        //     anim.SetBool("Corriendo", false);
        // }

        if (Input.GetKey("space"))
        {anim.SetBool("Attack",true);}

        if (!Input.GetKey("space"))
        {anim.SetBool("Attack" ,false);}
    }


    private void OnCollisionEnter(Collision collision) {
        
        //Debug.Log("hola");
    }

    
}
