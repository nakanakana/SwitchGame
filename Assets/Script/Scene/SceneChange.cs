using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public int Count;

    float Dtimer = 3.0f;

    [SerializeField] private SceneReference sceneToLoad;
    [SerializeField] private Light directionLight;

    private void Start()
    {
        directionLight.intensity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Count <= 0)
        {
            Dtimer -= Time.deltaTime;

            if (Dtimer <= 0)
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void SubEnemyCount()
    {

        Count--;
        Debug.Log(Count);
    }

}
