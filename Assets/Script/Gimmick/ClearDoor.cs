using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDoor : MonoBehaviour
{
    Animator animator;
    public BoxCollider collider = null;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
        collider.enabled = false;
        animator.SetBool("Open", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneChange.instance.Count <= 0)
        {
            if (!collider.enabled)
            {
                animator.SetBool("Open", true);
                collider.enabled = true;
            }
        }
    }
}
