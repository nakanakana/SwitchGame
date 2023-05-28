using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickSceneChange : MonoBehaviour
{
    [SerializeField] private SceneReference sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))    // Enter‚ðƒNƒŠƒbƒN‚µ‚½‚ç
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
