using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTest : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        bool isOpen = animator.GetBool("DoorIsOpen");

        if (!isOpen)
        {
            animator.SetBool("DoorIsOpen", true);
        }
        else
        {
            animator.SetBool("DoorIsOpen", false);
        }
        
    }
}
