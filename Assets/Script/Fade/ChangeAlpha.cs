using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ChangeAlpha : MonoBehaviour
{
    public static ChangeAlpha instance;

    // フェードさせる時間を設定
    [SerializeField]
    private float fadeTime = 1f;
    // 経過時間を取得
    private float timer;

    //フェードインに切り替わったかどうか
    public bool flagFadeIn = false;

    //フェードインとフェードアウトを無効化するかどうか
    public bool ProgramOn = false;

    // Start is called before the first frame update
    void Start()
    {
        // このゲームオブジェクトのCanvasGroupコンポーネントを取得して、
        // alpha値を0(透明）にする。
        this.gameObject.GetComponent<CanvasGroup>().alpha = 0;

        //フェードイン無効化
        flagFadeIn = false;

        //フェードイン、フェードアウト有効化
        ProgramOn = true;

        //moveControl = GetComponent<MoveControl>();
        MoveControl.instance.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //フェードアウト
        if(flagFadeIn == false && ProgramOn == true)
        {
            // 経過時間を加算
            timer += Time.deltaTime;
            // 経過時間をfadeTimeで割った値をalphaに入れる
            // ※alpha値は1(不透明)が最大。
            this.gameObject.GetComponent<CanvasGroup>().alpha = timer / fadeTime;

            //alpha値が１timerが8秒を超えたら
            if(this.gameObject.GetComponent<CanvasGroup>().alpha == 1 && timer > 8)
            {
                //フェードイン有効化
                flagFadeIn = true;
            }
        }

        //フェードイン
        if (flagFadeIn == true && ProgramOn == true)
        {
            //timer -= Time.deltaTime;
            
            //alpha値減少
            this.gameObject.GetComponent<CanvasGroup>().alpha -= 0.002f;

            if (this.gameObject.GetComponent<CanvasGroup>().alpha == 0)
            {
                //フェードイン無効化
                flagFadeIn = false;

                //フェードイン、フェードアウト無効化
                ProgramOn = false;

                MoveControl.instance.enabled = true;
            }
        }

        //Debug.Log(timer);
    }
}
