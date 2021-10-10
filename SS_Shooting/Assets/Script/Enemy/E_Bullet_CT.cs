using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Bullet_Type
{
    S,
    M,
    L,
    BOSS,
    O
}


public class E_Bullet_CT : MonoBehaviour
{//�� ������ �Ѿ� �������� �Ѱ��� ��ũ��Ʈ.

    [Header("��ü ������Ʈ")]
    public SpriteRenderer My_Render;

    [Header("�Ѿ� ����")]
    public Bullet_Type type; //�Ѿ� Ÿ��.
    public float Speed; //�Ѿ� �ӵ�.
    public float Bullet_ATK; //�Ѿ� ���ݷ�.
    public float Alive_Time; //�Ѿ��� �����ð�.

    void Start()
    {
        My_Render = GetComponent<SpriteRenderer>();
        My_Render.flipY = true; //�Ųٷ� �����ڴ�.

        Invoke("Bullet_Clear", Alive_Time);
    }


    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    void Bullet_Clear()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //�÷��̾�� �������� �ְ� �ڽ��� �ı��� �ڵ�
            print("�÷��̾� �ǰ�!");
            Destroy(gameObject);
        }
    }
}

