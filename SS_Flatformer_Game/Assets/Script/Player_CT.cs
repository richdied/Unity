using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CT : MonoBehaviour
{

    [Header("�÷��̾� ����")]
    public float Speed;
    public float Jump_Pos;
    public bool Is_Jump = false;
    public float Offset_X;

    [Header("�÷��̾� ������Ʈ")]
    Animator My_Anim;
    Rigidbody2D My_Rigid;
    SpriteRenderer My_Render;
    void Start()
    {
        Component_Get();
    }


    void Update()
    {
        Input_Key();
    }

    void Component_Get()
    {
        My_Anim = GetComponent<Animator>();
        My_Rigid = GetComponent<Rigidbody2D>();
        My_Render = GetComponent<SpriteRenderer>();
    }

    public void Velocity_Zero()
    {// �ش� �Լ��� ����Ǹ�, � ���µ� ����
     // ���� �Ҵ�� ��� �ӷ��� 0���� �ʱ�ȭ�Ѵ�.
        My_Rigid.velocity = Vector2.zero;
    }


    void Input_Key()
    {
         Offset_X = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector2.right * Offset_X * Speed * Time.deltaTime);

        if(Offset_X == -1)
        {
            My_Render.flipX = true;
            My_Anim.SetInteger("Is_Run", 1);
        }
        else if(Offset_X == 1)
        {
            My_Render.flipX = false;
            My_Anim.SetInteger("Is_Run", 1);
        }
        else
        {
            My_Anim.SetInteger("Is_Run", 0);
        }

        if(Input.GetKeyDown(KeyCode.Space) && !Is_Jump)
        {
            Is_Jump = true;
            Velocity_Zero(); 
            My_Anim.SetBool("Is_Jump", true);
            My_Rigid.AddForce(Vector2.up * Jump_Pos, ForceMode2D.Impulse);
            My_Anim.Play("JUMP");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Is_Jump = false;
            My_Anim.SetBool("Is_Jump", false);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            Enemy_CT E_Cs = collision.gameObject.GetComponent<Enemy_CT>();
            Transform Enemy = collision.gameObject.GetComponent<Transform>();
            //�ε��� �� ��ü�� Transform ������Ʈ ������ �޾ƿ��ڴ�.

            if(transform.position.y >= Enemy.GetChild(0).transform.position.y)
            {// �ε��� ���� ù��° �ڽĺ��� �÷��̾ ���� ���� ���.

                // �� �ǰ� �ڵ�.
                E_Cs.Enemy_Hit(1); //���� �����ϰ�
                Velocity_Zero(); //�ӷ��� �ʱ�ȭ �� ��,
                My_Rigid.AddForce(Vector2.up * Jump_Pos, ForceMode2D.Impulse); //���� Ƣ������ڴ�.
            }
        }
    }
}