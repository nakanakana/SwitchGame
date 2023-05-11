using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject Door;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            //animator.SetTrigger("DoorOpen");
            animator.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //animator.ResetTrigger("DoorOpen");
        animator.SetBool("Open", false);
    }
}
