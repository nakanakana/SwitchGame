using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void Update()
    {
        ByeGame();
    }

    //Q[IΉ
    private void ByeGame()
    {
        //Escͺ³κ½
        if (Input.GetKey(KeyCode.Escape))
        {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//Q[vCIΉ
            Application.Quit();
#else
    Application.Quit();//Q[vCIΉ
#endif
        }

    }
}
