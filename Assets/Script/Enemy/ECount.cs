using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECount : MonoBehaviour
{
    [SerializeField] private GameObject enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneChange.instance.count >= 10)
        {
            enemyCount.SetActive(true);
        }
        else
        {
            enemyCount.SetActive(false);
        }
    }
}
