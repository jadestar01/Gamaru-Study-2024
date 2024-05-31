using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsGameEnd;
    public Canvas Canvas;

    public static GameManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void OnPlayerDead()
    {
        Debug.Log("Game lose");
        IsGameEnd = true;
        Canvas.gameObject.SetActive(true);
    }

    public void ReturnToLobby()
    {
        SceneManager.LoadSceneAsync("LobbyScene");
        Debug.Log("return to lobby");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
