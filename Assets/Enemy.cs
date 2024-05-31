using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public int hp;
    public GameObject bulletPrefab;

    public float elapsedTime; // Time.deltaTime 활용

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1f)
        {
            elapsedTime = 0f;
            GameObject bullet = Instantiate(bulletPrefab);
            //           총알의 위치 <-- 적의 위치
            bullet.transform.position = transform.position;
        }


        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);

        // 적이 화면을 벗어났을 때
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }

    public void OnHit()
    {
        hp -= 1;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bullet = collision.GetComponent<Bullet>();
        // 플레이어 팀 : 0, 플레이어팀의 총알만 처리
        if (bullet != null && bullet.team == 0)
        {
            OnHit();
        }

        //Debug.Log("enemy tr : " + collision.gameObject);
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("enemy : " + collision.gameObject);
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Destroy(gameObject);
        }
    }
}
