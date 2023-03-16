using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleOnMouseDown : MonoBehaviour
{
   
    private bool isMouseDown = false;
    private bool ScaleKeep = false;

    private Vector3 keep_scale;

    private void Awake()
    {
        keep_scale = transform.localScale;
    }

    public void SaveScale()
    {
        keep_scale = transform.localScale;
    }

    public void LoadScale()
    {
        transform.localScale = keep_scale;
    }

    private void Update()
    {
        
        // マウスの左ボタンがクリックされた場合
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;

            ScaleKeep = true;
            SaveScale();


            // DoTweenを使用してScaleを拡大する
            transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.3f);
        }

        // マウスの左ボタンが離された場合
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;

            // DoTweenを使用してScaleを元に戻す
            //transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f);

            LoadScale();
            Debug.Log(keep_scale.x);
            Debug.Log(keep_scale.y);
            Debug.Log(keep_scale.z);
        }

        // マウスの左ボタンがクリックされている間
        if (isMouseDown)
        {
            // DoTweenを使用してScaleを拡大縮小させる
            transform.DOScale(new Vector3(2f, 1f, 2f), 0.3f).SetLoops(-1, LoopType.Yoyo);
        }

        
    }
}