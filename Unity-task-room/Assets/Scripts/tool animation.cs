using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolanimation: MonoBehaviour {
   private Animator animator;
private bool isAnimating = false;
void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
{
    if (Input.GetKeyDown(KeyCode.Space) && !isAnimating)
    {
        animator.SetBool("isAnimating", true);
        isAnimating = true;
    }
    else if (Input.GetKeyDown(KeyCode.Space) && isAnimating)
    {
        animator.SetBool("isAnimating", false);
        isAnimating = false;
    }
}
void SayHello()
{
    Debug.Log("Hello");
}
}
