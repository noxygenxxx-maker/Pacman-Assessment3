using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iton : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.Play("right_iton");
    }
}
