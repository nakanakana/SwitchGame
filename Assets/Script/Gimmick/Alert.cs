using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    public static Alert instance;
    [Header("アラート音をセット。個別に指定しないならこれが鳴る")]
    public AudioClip sound;  

    private AudioSource audioSource;
    private bool isAlert = false; //鳴っているかどうか
    private bool isCall = false;　//敵を呼んでいるかどうか
    private GameObject[] enemy;

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
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //警報が鳴っていれば画面を点滅させる
        if (isAlert)
        {
            //FlushController.instance.flush();
        }


    }

    public void OnAleart()
    {
        //まだ鳴っていなければ鳴らす
        if (!isAlert)
        {
            audioSource.clip = sound;
            audioSource.Play();
            isAlert = true;
        }

    }

    //外部から音声を指定した場合
    public void OnAleart(AudioClip so)
    {
        //まだ鳴っていなければ鳴らす
        if (!isAlert)
        {
            audioSource.clip = so;
            audioSource.Play();
            isAlert = true;
        }

    }


    //画面の点滅を終わらせる
    //警報を止める
    public void ReleaseAleart()
    {    
       // FlushController.instance.flushClear();
        audioSource.Stop();
        ReleaseEnemy();
        isAlert = false;
    }

    public bool GetisAlert()
    {
        return isAlert;
    }

    public void CallEnemy(GameObject[] enemies,Transform tr)
    {
        enemy = enemies;
        for (int i = 0; i < enemies.Length; ++i)
        {
            if (enemies[i] != null)
            {
                enemies[i].GetComponentInChildren<Patrol>().AlertCome(tr);
            }
        }
    }


    public void ReleaseEnemy()
    {
        for (int i = 0; i < enemy.Length; ++i)
        {
            if (enemy[i] != null)
            {
                enemy[i].GetComponentInChildren<Patrol>().Return();
            }
        }

    }


}


