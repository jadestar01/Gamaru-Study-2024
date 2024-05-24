using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsGameEnd;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
