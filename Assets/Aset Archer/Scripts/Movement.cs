using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        animator.SetFloat("Strafe", x);
        animator.SetFloat("Forward", y);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("run", true);
        }

        else
        {
            animator.SetBool("run", false);
        }

        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("aim", true);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("aim", false);
            animator.SetBool("shoot", true);
        }

        else
        {
            animator.SetBool("shoot", false);
        }

        if (Input.GetButton("Fire2"))
        {
            animator.SetBool("punch", true);
        }

        if (Input.GetButtonUp("Fire2"))
        {
            animator.SetBool("punch", false);
        }
    }
}