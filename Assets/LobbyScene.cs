using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
#if UNITY_EDITOR
using UnityEditor.SearchService;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LobbyScene : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonDown);
        quitButton.onClick.AddListener(OnQuitButtonDown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void OnPlayButtonDown()
    {
        SceneManager.LoadScene("MainScene"); 
    }

    

    public void OnQuitButtonDown()
    {
        Application.Quit();
    }
}
