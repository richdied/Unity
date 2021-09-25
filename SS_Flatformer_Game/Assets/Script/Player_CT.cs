using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CT : MonoBehaviour
{

    [Header("플레이어 스텟")]
    public float Speed;
    public float Jump_Pos;
    public bool Is_Jump = false;
    public float Offset_X;

    [Header("플레이어 컴포넌트")]
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
    {// 해당 함수가 실행되면, 어떤 상태든 간에
     // 현재 할당된 모든 속력을 0으로 초기화한다.
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
            //부딪힌 적 객체의 Transform 컴포넌트 정보를 받아오겠다.

            if(transform.position.y >= Enemy.GetChild(0).transform.position.y)
            {// 부딪힌 적의 첫번째 자식보다 플레이어가 높이 있을 경우.

                // 적 피격 코드.
                E_Cs.Enemy_Hit(1); //적을 공격하고
                Velocity_Zero(); //속력을 초기화 한 뒤,
                My_Rigid.AddForce(Vector2.up * Jump_Pos, ForceMode2D.Impulse); //위로 튀어오르겠다.
            }
        }
    }
}
