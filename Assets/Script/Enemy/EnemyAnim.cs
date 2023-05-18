using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    Animator enemyanim;
    // Start is called before the first frame update
    void Start()
    {
        this.enemyanim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!Patrol.instance.tracking) 
        {
            enemyanim.SetBool("Attack", false);
                   
        }
        if (Patrol.instance.tracking) enemyanim.SetBool("Attack", true);
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sword") enemyanim.SetTrigger("EnemyDeath");
    }
}
