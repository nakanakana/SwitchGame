using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitSword : MonoBehaviour
{
    public SceneChange sceneChange;
    public GameObject particleObject;
    public AudioSource audioSource;
   
    void OnTriggerEnter(Collider other)
    {

        //攻撃した相手がEnemyの場合
        if (other.CompareTag("Enemy"))
        {
            Instantiate(particleObject, other.transform.position, Quaternion.identity);
            audioSource.Play();
            Destroy(other.gameObject, 0.4f);
            sceneChange.SubEnemyCount();
        }
    }

}
