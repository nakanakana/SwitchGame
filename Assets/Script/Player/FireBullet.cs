using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("弾の発射場所")]
    private GameObject firingpoint;

    [SerializeField]
    [Tooltip("弾")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("弾の速さ")]
    private float speed = 30.0f;

    //int count;

    //float DelayTimer = 5.0f;

    private void Start()
    {
        //count = 0;
        //DelayTimer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {

        //DelayTimer -= Time.deltaTime;
        //if (DelayTimer <= 3.0f)
        //{
        //    //左クリックしたか
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        //if (count < 5)
        //        {
        //            //弾を発射する
        //            //Shot();

        //            DelayTimer = 5.0f;
        //            //count++;
        //            //Debug.Log(count);
        //        }

        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    count = 0;
        //    Debug.Log("Reload now");
        //}


    }

    ///<summary>
    ///弾の発射
    ///</summary>
    //private void Shot()
    //{
    //    //弾の発射位置を取得
    //    Vector3 bulletPosition = firingpoint.transform.position;

    //    //bulletPositionで取得した場所に、"Bullet"のPrefabを出現させる
    //    GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);

    //    // 出現させたボールのforward(z軸方向)
    //    //Vector3 direction = newBall.transform.forward;
    //    // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
    //    //newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
    //    // 出現させたボールの名前を"bullet"に変更
    //    newBall.name = bullet.name;
    //    // 出現させたボールを0.1秒後に消す
    //    Destroy(newBall, 0.1f);

    //}

 

}
