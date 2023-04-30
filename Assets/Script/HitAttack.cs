using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class HitAttack : MonoBehaviour
{
    [SerializeField] private EventTrigger onTriggerEnter = new EventTrigger();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }

    [Serializable]
    public class EventTrigger : UnityEvent<Collider>
    {

    }
}