using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void Update()
    {
        ByeGame();
    }

    //�Q�[���I��
    private void ByeGame()
    {
        //Esc�������ꂽ��
        if (Input.GetKey(KeyCode.Escape))
        {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
            Application.Quit();
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
        }

    }
}
