using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickSceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    // ���}�E�X�{�^�����N���b�N������
        {
            SceneManager.LoadScene("stage1");    // GameScene�Ɉړ�
        }
    }
}
