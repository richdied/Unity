using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CT : MonoBehaviour
{
    // �� ��ü�� ������ ���ǿ� ���� �з��ص� ��ũ��Ʈ.
    [Header("�� ��ü ����")]
    public float Speed; //�� ��ü�� �ӵ�
    public int HP; //�� ��ü�� ü��
    public float Distance; // ���� �÷��̾ �ν��� �� �ִ� �ִ�Ÿ�.

    [Header("��ü �ڷ�")]
    public GameObject Player; //�� ��ü�� Ÿ�� ������Ʈ ����
    public SpriteRenderer My_Render; //�ڱ� �ڽ��� ������Ʈ
    public Animator My_Anim; //�ڱ� �ڽ��� ������Ʈ
    public Rigidbody2D My_Rigid; //�ڱ� �ڽ��� ������Ʈ


    void Start()
    {
        Player = GameObject.Find("Player");
        My_Render = GetComponent<SpriteRenderer>();
        My_Anim = GetComponent<Animator>();
        My_Rigid = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Check_Distance();
    }

    public void Enemy_Hit(int Damage)
    {
        HP -= Damage;
        //�� �ǰ� �ִϸ��̼� ����.

        if(HP <= 0)
        {
            Enemy_Dead();
        }
    }

    void Enemy_Dead()
    {
        Destroy(gameObject);
    }

    void Check_Distance()
    {
        //�÷��̾�� �ڽ��� ���� �Ÿ��� ����ؼ� 
        //�ִ� �����Ÿ� ���� ����ٸ�, ������ �����ϴ� �ڵ�.

        float dis = Vector2.Distance(Player.transform.position, transform.position);
        //Vector.Distance(Vector A, Vector B)
        // �� �Ķ���Ϳ� �Էµ� �� ��ǥ�� �Ÿ��� ���ؼ� 
        //    float������ return���ִ� �Լ�.

        if (dis < Distance)
        { //�÷��̾�� �ڽ��� �Ÿ��� �̸� ������ �ִ� �����Ÿ� �̸��� ���.

            //�÷��̾� �߰� �ڵ�
            if (Player.transform.position.x > transform.position.x)
            { //��> �÷��̾ �ڽź��� �����ʿ� ��ġ�� ���.
                transform.Translate(Vector2.right * Speed * Time.deltaTime);
                //My_rigid.velocity = new Vector2(Speed, My_rigid.velocity.y);
                My_Render.flipX = false;
            }
        }
        else if (Player.transform.position.x < transform.position.x)
        { //��> �÷��̾ �ڽź��� ���ʿ� ��ġ�� ���.
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
            My_Render.flipX = true;
        }
        else
        {
            print("���� ���� ����");
        }

    }
} 
   