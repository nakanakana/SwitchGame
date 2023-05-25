using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAlpha : MonoBehaviour
{


    // フェードさせる時間を設定
    [SerializeField]
    private float fadeTime = 0.0f;
    // 経過時間を取得
    private float timer;

    //フェードインに切り替わったかどうか
    public bool flagFadeIn = false;

    //フェードインとフェードアウトを無効化するかどうか
    public bool programOn = true;

   
    //[SerializeField] GameObject loading;

   


    // Start is called before the first frame update
    void Start()
    {
        // このゲームオブジェクトのCanvasGroupコンポーネントを取得して、
        // alpha値を0(透明）にする。
        //this.gameObject.GetComponent<CanvasGroup>().alpha = 1;

        //フェードイン無効化
        flagFadeIn = true;

        //フェードイン、フェードアウト有効化
        programOn = true;

    }

    // Update is called once per frame
    void Update()
    {
        ////フェードアウト
        //if (flagFadeIn == false && programOn == true)
        //{
        //    // 経過時間を加算
        //    timer += Time.deltaTime;
        //    //// 経過時間をfadeTimeで割った値をalphaに入れる
        //    //// ※alpha値は1(不透明)が最大。
        //    this.gameObject.GetComponent<CanvasGroup>().alpha += timer / fadeTime;
        //    ////alpha値が１timerが8秒を超えたら
        //    if (this.gameObject.GetComponent<CanvasGroup>().alpha == 1)
        //    {
             
        //        if (timer >= 1.0f)
        //        {
        //            if (!loading.activeSelf)
        //            {
        //                loading.SetActive(true);
        //            }
        //        }
        //    }
        //}

        ////フェードイン
        if (flagFadeIn == true && programOn == true)
        {
            timer += Time.deltaTime;

            //alpha値減少
            //this.gameObject.GetComponent<CanvasGroup>().alpha -= 0.02f;
            this.gameObject.GetComponent<CanvasGroup>().alpha -= 0.009f;
            if (this.gameObject.GetComponent<CanvasGroup>().alpha <= 0.0f)
            {
                //フェードイン無効化
                flagFadeIn = false;

                //フェードイン、フェードアウト無効化
                programOn = false;

               // this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
            }
        }

        
    }
}
