using UnityEngine;

public class Musuh_Animator : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Move(bool value)
    {
        animator.SetBool("Move", value);
    }

    public void Attack() 
    {
        animator.ResetTrigger("Attack");
        animator.SetTrigger("Attack");
    }
}
