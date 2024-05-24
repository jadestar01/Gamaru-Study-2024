using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 direction;
    public int team; // 0 : 플레이어, 1 : 적
        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * moveSpeed);

        // 총알이 화면을 벗어났을 때
        // Y값의 절대값이 20보다 큰 경우
        if (Mathf.Abs(transform.position.y) > 20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 내가 플레이어 총알이고 적과 충돌했을 때
        if (team == 0 && collision.GetComponent<Enemy>() != null)
        {
            Destroy(gameObject);
        }

        // 내가 적 총알이고 플레이어와 충돌했을 때
        if (team == 1 && collision.GetComponent<PlayerController>() != null)
        {
            Destroy(gameObject);
        }
    }
}
