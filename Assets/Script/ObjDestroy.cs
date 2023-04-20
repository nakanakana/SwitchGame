using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    /// GameOverArea�ɂ��̃X�N���v�g�����Ă���I�u�W�F�N�g���G�ꂽ��
    /// �G�ꂽ�I�u�W�F�N�g�������ɏ���
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GameOverArea") //���̃I�u�W�F�N�g��GameOverArea�ɐG�ꂽ��
        {
            //Destroy
            Destroy(this.gameObject);
        }

        
       
    }


    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("No Hit");
        
        if (collision.gameObject.CompareTag("Bullet") && gameObject.CompareTag("Enemy"))
        {

            // 0.2�b���Enemy������
            Destroy(gameObject, 0.2f);

            //�e������
            Destroy(collision.gameObject);

            EnemyCount.instance.SubEnemyCount();



        }

    }


}
