using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitSword : MonoBehaviour
{
    public GameObject particleObject;
    public AudioSource audioSource;
   
    void OnTriggerEnter(Collider other)
    {

        //�U���������肪Enemy�̏ꍇ
        if (other.CompareTag("Enemy"))
        {
            Instantiate(particleObject, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject, 0.4f);
            audioSource.Play();
            //SceneChange.instance.SubEnemyCount();
        }
    }

}
