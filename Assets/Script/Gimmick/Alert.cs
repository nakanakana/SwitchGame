using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    public static Alert instance;
    public AudioClip sound;  
    private AudioSource audioSource;
    private bool isAlert = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Œx•ñ‚ª–Â‚Á‚Ä‚¢‚ê‚Î‰æ–Ê‚ğ“_–Å‚³‚¹‚é
        if (isAlert)
        {
            FlushController.instance.flush();
        }

    }

    public void OnAleart()
    {
        //‚Ü‚¾–Â‚Á‚Ä‚¢‚È‚¯‚ê‚Î–Â‚ç‚·
        if (!isAlert)
        {
            audioSource.clip = sound;
            audioSource.Play();
            isAlert = true;
        }

    }

    //‰æ–Ê‚Ì“_–Å‚ğI‚í‚ç‚¹‚é
    //Œx•ñ‚ğ~‚ß‚é
    public void ReleaseAleart()
    {    
        FlushController.instance.flushClear();
        audioSource.Stop();
        isAlert = false;
    }

    public bool GetisAlert()
    {
        return isAlert;
    }
}


