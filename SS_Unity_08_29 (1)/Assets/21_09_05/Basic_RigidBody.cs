using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_RigidBody : MonoBehaviour
{
    //2021. 09. 05

    //Rigidbody [ ��ü ]
    // �� �ش� ������Ʈ�� ���� ��ü�� ���� ��� �޵��� ������ �ִ�
    //    ������Ʈ.
    //    ��ǥ���� �Ļ� Ű����δ�,
    //    [1] Rigidbody.Addforce()
    //     �� �Է��Ѹ�ŭ�� ���� ��ü���� ���ϴ� �Լ�.
    //    [2] Rigidbody.velocity
    //     �� ��ü�� �ӷ°��� �޾ƿ��ų�, �Ҵ��� �� �ִ� Ű����.


    //Collider [ �浹ü ]
    // �� �ش� ��ü�� �浹 ������ �Ҵ��ϴ� ������Ʈ.
    //    �Ŀ� �н��� [�浹ü�̺�Ʈ �Լ�]���� [Rigidbody]�� �Բ�
    //    ���ȴ�.



    //[1] �ش� ��ü�� ������ �ִ� [Transform] �̿��� ������Ʈ��
    //    �����ϴ� ���.

    Rigidbody2D My_rigid;
    //RIgidbody2D ������Ʈ�� �Ҵ���� �� �ִ� ���� My_rigid�� �����ϰڴ�.
    SpriteRenderer My_Render;

    [Header("������ ����")]
    public float P_Speed;       //�÷��̾��� �̵��ӵ�.
    public float P_JumpPos;     //�÷��̾��� ��������.
    public bool Is_Jump = false;//�÷��̾ �������ΰ�?

    [Header("�ӷ�����")]
    public float X_Velocity;    //�÷��̾��� ���� �ӵ�.
    public float Y_Velocity;    //�÷��̾��� ���� �ӵ�.

    [Header("��������")]
    public float Min_JumpPos;  //��¡���� ��������.
    public float Max_JumpPos;  //�ִ� ��������.

    public float Charging_Speed; //JumpPos�� �����ϴ� �ӵ�

    public float Direction_X;  //x������ ���� ��.
    public float Direction_Y;  //y������ ���� ��.

    void Start()
    {
        //������Ʈ �Ҵ� ó���� Start����!
        My_rigid = gameObject.GetComponent<Rigidbody2D>();
        //[1] �� ��ũ��Ʈ�� ������ �ִ� ������Ʈ�� Rigidbody2D ������Ʈ��
        //    �����ͼ�
        //[2] Rigidbody2D Ÿ�� ���� 'My_rigid'�� �Ҵ����ְڴ�.
        My_Render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!Is_Jump) {
            Velocity_Move();
        }
        // Click_Jump();
        Charging_Jump();
    }

    void Charging_Jump()
    {
        //[1] ����Ű�� ������ ���� ���� �����ϰ�
        //[2] ����Ű���� ���� ���� ������ �����ϴ� �ڵ�.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�����̽��ٸ� ������ ���� '������'���� ��ȯ.
            Is_Jump = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //�����̽��ٸ� ������ ���� ���� �����ϰڴ�.
            if (Min_JumpPos < Max_JumpPos)
            {  //�������� ���� �ִ� ��ȯ �̸��� ��쿡�� ���� �����ϰڴ�.
                Min_JumpPos += Charging_Speed;
            }
            else if(Min_JumpPos >= Max_JumpPos)
            {  //���� �������� ���� �ִ� ���� �̻����� �Ѿ�ٸ�,
                Min_JumpPos = Max_JumpPos;
                //�ִ� ����ġ�� �Ҵ����ְڴ�.
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            //�����̽��ٿ��� ���� ����, ���� ����ŭ �ٶ󺸴� ��������
            //�����ϰڴ�.
            if (!My_Render.flipX) //�������� �ٶ󺸰� ���� ���.
                My_rigid.AddForce(new Vector2(3, Min_JumpPos), ForceMode2D.Impulse);
            if (My_Render.flipX) //������ �ٶ󺸰� ���� ���.
                My_rigid.AddForce(new Vector2(-3, Min_JumpPos), ForceMode2D.Impulse);

            Min_JumpPos = 0; //����ó���� �������� ���� ���� �ʱ�ȭ�صΰڴ�.
        }
    }
    

    void Click_Jump()
    {
        //�ν����Ϳ� �Է��� x,y�������� AddForce�� ������ �Լ�

        if (Input.GetMouseButtonDown(0) && !Is_Jump)
        {
            Is_Jump = true;
            My_rigid.AddForce(new Vector2(Direction_X, Direction_Y),
                              ForceMode2D.Impulse);
        }
    }
    void Velocity_Move()
    {
        //��,�� ������ ���� ����

        float Offset_X = Input.GetAxisRaw("Horizontal");
        //���� Ű �Է��� �޾� -1 , 1�� ��ȯ�ϰڴ�.

        if(Offset_X == 1)
        {
            My_Render.flipX = false;
        }
        else if(Offset_X == -1)
        {
            My_Render.flipX = true;
        }

        My_rigid.velocity = new Vector2(Offset_X * P_Speed, My_rigid.velocity.y);

        //[1] �� ��ü�� X�� �ӷ¿� (����  * �ӵ�) ��ŭ�� ���� �����ٰǵ�,
        //[2] Y�� �ӷ��� �� ��ü�� ���� �ӷ��� �״�� �����ϰڴ�. 

        X_Velocity = My_rigid.velocity.x; //���� ���� �ӷ°��� �Ҵ��ϰڴ�.
        Y_Velocity = My_rigid.velocity.y; //���� ���� �ӷ°��� �Ҵ��ϰڴ�.
    }

    //collision[�浹ü] �̺�Ʈ �Լ� 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�� ��ü�� �浹�� �ݶ��̴��� ���� ������Ʈ�� ������ �������� �̺�Ʈ �Լ�
        //< �۵� ���� >

        //[1] �浹�� �� ��ü�� �ϳ� �̻��� ��ü�� Rigidbody�� ������ ���� ��.
        //[2] �� ��ü ��� �浹ü�� ������ ���� ��.

        if(collision.gameObject.tag == "Ground")
        {
            //�浹�� �浹ü�� ���� ���� ������Ʈ�� �±װ� "Ground"�� ���.
            //�±�(tag)��?
            //�� ����� ������ ���� ������Ʈ�鳢�� ��Ƴ��� ���ؼ�
            //   ������ '�ν�ǥ'�� �޾Ƴ��� ���.
            //   ���� ����, [����] ��ü���� 'Enemy'�±׸� �޾Ƴ��� ���ð� �����Ѵ�.

            Is_Jump = false;
            //�÷��̾ ���� �����ϸ�[�浹�ϸ�]
            //'�������� �ƴϴ�' ���·� ��ȯ.
        }
    }
}