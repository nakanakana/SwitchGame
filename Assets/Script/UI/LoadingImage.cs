using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingImage : MonoBehaviour
{
    [Header("LoadingDotのオブジェクト入れてください")]
    [SerializeField] GameObject loadingDot01;
    [SerializeField] GameObject loadingDot02;
    [SerializeField] GameObject loadingDot03;

    Image img01,img02,img03;

    float displayTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        displayTime += Time.deltaTime;
        

        if (!loadingDot01.activeSelf && displayTime >= 1.0f)
        {
            loadingDot01.SetActive(true);
        }
        if (!loadingDot02.activeSelf && displayTime >= 2.0f)
        {
            loadingDot02.SetActive(true);
        }
        if (!loadingDot03.activeSelf && displayTime >= 3.0f)
        {
            loadingDot03.SetActive(true);
        }


        //Dotが全て表示されていて且つ表示時間が4.5f以上なら消す
        if (loadingDot01.activeSelf && loadingDot02.activeSelf && loadingDot03&&displayTime>=4.0f)
        {
            loadingDot01.SetActive(false);
            loadingDot02.SetActive(false);
            loadingDot03.SetActive(false);
            displayTime = 0.0f;
        }

        //Debug.Log(displayTime);
    }
}
