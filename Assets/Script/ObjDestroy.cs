using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjDestroy : MonoBehaviour
{
   

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
        
       
    //}

    /// <summary>
    /// GameOverAreaにこのスクリプトがついているオブジェクトが触れたら
    /// 触れたオブジェクトをすぐに消す
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GameOverArea") //他のオブジェクトがGameOverAreaに触れたら
        {
            //Destroy
            Destroy(this.gameObject);
        }

        
       
    }


    //void OnCollisionEnter(Collision collision)
    //{
    //    //Debug.Log("No Hit");

    //    if (collision.gameObject.CompareTag("Sword") && gameObject.CompareTag("Enemy"))
    //    {

    //        // 0.2秒後にEnemy消える
    //        Destroy(gameObject, 0.2f);

    //        //if (SceneManager.GetActiveScene().name == "stage1")
    //        //{
    //        //    EnemyCount.instance.SubEnemyCount();
    //        //}

    //        //if (SceneManager.GetActiveScene().name == "stage2")
    //        //{
    //        //    EnemyCount2.instance.SubEnemyCount();
    //        //}

    //    }

    //}
}
