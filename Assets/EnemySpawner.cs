using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float elapsedTime;
    public float minX;
    public float maxX;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameEnd)
            return;

        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1f)
        {
            elapsedTime = 0f;
            GameObject enemy = Instantiate(enemyPrefab);
            //           적의 위치 <-- 스포너의 위치
            Vector3 spawnPos = transform.position;
            spawnPos.x = Random.Range(minX, maxX);
            enemy.transform.position = spawnPos;
        }
    }
}
