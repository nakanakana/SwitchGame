using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject LDoor;
    [SerializeField] GameObject RDoor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            LDoor.SetActive(false);
            RDoor.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        LDoor.SetActive(true);
        RDoor.SetActive(true);
    }
}
