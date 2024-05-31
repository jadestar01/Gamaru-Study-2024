using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public float lastTime; // Time.time Ȱ��
    public float elapsedTime; // Time.deltaTime Ȱ��

    public int hp;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
    }

    public void OnHit()
    {
        hp -= 1;
        if (hp <= 0 && isDead == false)
        {
            isDead = true;
            Destroy(gameObject);
            GameManager.Instance.OnPlayerDead();
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1f)
        {
            elapsedTime = 0f;
            GameObject bullet = Instantiate(bulletPrefab);
            //           �Ѿ��� ��ġ <-- �÷��̾��� ��ġ
            bullet.transform.position = transform.position;
        }

        // Input.GetKeyDown / Input.GetKey / Input.GetKeyUp
        if (Input.GetKey(KeyCode.DownArrow)) // �Ʒ� ����Ű�� ������ �ִ°�?
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.UpArrow)) // �� ����Ű�� ������ �ִ°�?
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // ���� ����Ű�� ������ �ִ°�?
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow)) // ������ ����Ű�� ������ �ִ°�?
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bullet = collision.GetComponent<Bullet>();
        // �� �� : 1, ������ �Ѿ˸� ó��
        if (bullet != null && bullet.team == 1)
        {
            OnHit();
        }

        //Debug.Log("player tr : " + collision.gameObject);
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("player : " + collision.gameObject);
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHit();
        }
    }
}
