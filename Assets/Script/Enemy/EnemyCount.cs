using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyCount : MonoBehaviour
{
    public static EnemyCount instance;

    [SerializeField]
    public int Count ;

    float Dtimer = 3.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Count);

        if (Count <= 0)
        {
            Dtimer -= Time.deltaTime;

            if (Dtimer <= 0)
                Debug.Log("stage2‚Ö");
            SceneManager.LoadScene("stage2");
        }
    }

    public void SubEnemyCount()
    {
       
       Count--;

    }
}
