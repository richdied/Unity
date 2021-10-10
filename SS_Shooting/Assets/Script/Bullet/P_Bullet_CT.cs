using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bullet_CT : MonoBehaviour
{
    //[1] �÷��̾� �Ѿ��� �⺻���� �������� ����.
    //[2] ������ �������� ��, �ڱ� �ڽ��� �ı��� �ڵ�.
    //
    //[2-2] �Ѿ��� �ı��Ǵ� ����
    //      �� 1. �� ��ü�� �浹���� ���.
    //      �� 2. ���� y��ǥ�� �ʰ����� ���.

    [Header("�Ѿ� �Ӽ�")]
    public float Speed;     //�Ѿ� �ӵ�.
    public float Limit_Y;   //�Ѿ��� ���ư� �� �ִ� �ִ� y��ǥ

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);

        if(transform.position.y >= Limit_Y)
        {  //�� �ڽ��� y��ǥ�� ������ �� �̻��� ���.

            Destroy(gameObject);
            // �� �ڱ� �ڽ��� �ı��ϰڴ�.
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //ù��° ���.
            collision.gameObject.GetComponent<Enemy_CT>().Hit_Function(1);

            //�ι�° ���.
            //Enemy_CT EC = collision.gameObject.GetComponent<Enemy_CT>();
            //EC.Hit_Function(1);

            print("�� ��ü ����!");
            Destroy(gameObject);
        }
        //�� ��ü �ǰ��Լ� ȣ��.
        //�ڱ� �ڽ��� �ı�.
    }
}
