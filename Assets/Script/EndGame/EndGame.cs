using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void Update()
    {
        ByeGame();
    }

    //ゲーム終了
    private void ByeGame()
    {
        //Escが押された時
        if (Input.GetKey(KeyCode.Escape))
        {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
            Application.Quit();
#else
    Application.Quit();//ゲームプレイ終了
#endif
        }

    }
}
