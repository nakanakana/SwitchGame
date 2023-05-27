using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LerpAlpha : MonoBehaviour
{
    Image img;
    float duration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        img.color = Color.Lerp(new Color(1.0f, 1.0f, 1.0f, 0.5f), Color.clear,
        Mathf.PingPong(Time.time / duration, 1.0f));

    }
}
