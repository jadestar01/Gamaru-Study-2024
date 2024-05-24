using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 direction;
    public int team; // 0 : �÷��̾�, 1 : ��
        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * moveSpeed);

        // �Ѿ��� ȭ���� ����� ��
        // Y���� ���밪�� 20���� ū ���
        if (Mathf.Abs(transform.position.y) > 20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� �÷��̾� �Ѿ��̰� ���� �浹���� ��
        if (team == 0 && collision.GetComponent<Enemy>() != null)
        {
            Destroy(gameObject);
        }

        // ���� �� �Ѿ��̰� �÷��̾�� �浹���� ��
        if (team == 1 && collision.GetComponent<PlayerController>() != null)
        {
            Destroy(gameObject);
        }
    }
}
