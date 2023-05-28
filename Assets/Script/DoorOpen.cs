using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
       // animator.SetBool("Open", true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            //animator.SetTrigger("DoorOpen");
            animator.SetBool("Open", true);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        //animator.ResetTrigger("DoorOpen");
    //        animator.SetBool("Open", false);
    //    }
    //}
}
