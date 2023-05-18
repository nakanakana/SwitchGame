using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemySercharea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Handles.color = new Color(1f, 0, 0, 0.2f);
        //Handles.DrawSolidArc(transform.position, Vector3.up, Quaternion.Euler(0f, -searchAngle, 0f) * transform.forward, searchAngle * 2f, trackingRange);
    }
}
