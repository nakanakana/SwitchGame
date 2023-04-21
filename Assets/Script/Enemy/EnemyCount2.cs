using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyCount2 : MonoBehaviour
{
    public static EnemyCount2 instance;

    [SerializeField]
    public int Count2;

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
        if (Count2 <= 0)
        {
            Dtimer -= Time.deltaTime;

            if (Dtimer <= 0)
                SceneManager.LoadScene("TitleScene");
        }
    }

    public void SubEnemyCount()
    {


        Count2--;


    }
}
