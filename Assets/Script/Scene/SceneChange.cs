using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] private SceneReference sceneToLoad;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        SceneManager.LoadScene(sceneToLoad);
    }
}
