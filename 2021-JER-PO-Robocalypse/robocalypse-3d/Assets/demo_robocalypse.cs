using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class demo_robocalypse : MonoBehaviour
{
    private VideoPlayer videoplayer;
    private SpriteRenderer mainMenuBackground;
    private Canvas mainMenu;

    private bool isVideoActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        videoplayer = GetComponent<VideoPlayer> ();
        mainMenuBackground = GameObject.Find("MainMenuBackground").GetComponent<SpriteRenderer>();
        mainMenu = GameObject.Find("MainMenu").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.CapsLock) && !isVideoActive)
        {
            mainMenuBackground.enabled = false;
            mainMenu.enabled = false;
            videoplayer.Play();
            isVideoActive = true;
            /*if (videoplayer.isPlaying)
            {
                isVideoActive = true;
            }*/
        } else if (Input.GetKeyUp(KeyCode.CapsLock) && isVideoActive)
        {
            mainMenuBackground.enabled = true;
            mainMenu.enabled = true;
            videoplayer.Stop();
            if (!videoplayer.isPlaying)
            {
                isVideoActive = false;
            }
            //isVideoActive = false;
            
        }
        
        /*if (Input.GetKey(KeyCode.V) && isVideoActive)
        {
            mainMenuBackground.enabled = true;
            mainMenu.enabled = true;
            videoplayer.Stop();
            isVideoActive = false;
        }*/
        
    }
}
