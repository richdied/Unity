using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_RigidBody : MonoBehaviour
{
    //2021. 09. 05

    //Rigidbody [ 강체 ]
    // ㄴ 해당 컴포넌트를 가진 객체가 물리 제어를 받도록 도움을 주는
    //    컴포넌트.
    //    대표적인 파생 키워드로는,
    //    [1] Rigidbody.Addforce()
    //     ㄴ 입력한만큼의 힘을 객체에게 가하는 함수.
    //    [2] Rigidbody.velocity
    //     ㄴ 물체의 속력값을 받아오거나, 할당할 수 있는 키워드.


    //Collider [ 충돌체 ]
    // ㄴ 해당 물체의 충돌 범위를 할당하는 컴포넌트.
    //    후에 학습한 [충돌체이벤트 함수]에서 [Rigidbody]와 함께
    //    사용된다.



    //[1] 해당 객체가 가지고 있는 [Transform] 이외의 컴포넌트에
    //    접근하는 방법.

    Rigidbody2D My_rigid;
    //RIgidbody2D 컴포넌트를 할당받을 수 있는 변수 My_rigid를 선언하겠다.
    SpriteRenderer My_Render;

    [Header("움직임 관련")]
    public float P_Speed;       //플레이어의 이동속도.
    public float P_JumpPos;     //플레이어의 점프강도.
    public bool Is_Jump = false;//플레이어가 점프중인가?

    [Header("속력정보")]
    public float X_Velocity;    //플레이어의 수평 속도.
    public float Y_Velocity;    //플레이어의 수직 속도.

    [Header("점프관련")]
    public float Min_JumpPos;  //차징중인 점프강도.
    public float Max_JumpPos;  //최대 점프강도.

    public float Charging_Speed; //JumpPos를 충전하는 속도

    public float Direction_X;  //x축으로 가할 힘.
    public float Direction_Y;  //y축으로 가할 힘.

    void Start()
    {
        //컴포넌트 할당 처리는 Start에서!
        My_rigid = gameObject.GetComponent<Rigidbody2D>();
        //[1] 이 스크립트를 가지고 있는 오브젝트의 Rigidbody2D 컴포넌트를
        //    가져와서
        //[2] Rigidbody2D 타입 변수 'My_rigid'에 할당해주겠다.
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
        //[1] 지정키를 누르는 동안 힘을 축적하고
        //[2] 지정키에서 손을 떼면 점프를 실행하는 코드.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //스페이스바를 누르는 순간 '점프중'으로 전환.
            Is_Jump = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //스페이스바를 누르는 동안 힘을 축적하겠다.
            if (Min_JumpPos < Max_JumpPos)
            {  //충전중인 힘이 최대 상환 미만일 경우에만 힘을 축적하겠다.
                Min_JumpPos += Charging_Speed;
            }
            else if(Min_JumpPos >= Max_JumpPos)
            {  //만약 충전중인 힘이 최대 상한 이상으로 넘어간다면,
                Min_JumpPos = Max_JumpPos;
                //최대 상한치를 할당해주겠다.
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            //스페이스바에서 손을 떼면, 모은 힘만큼 바라보는 방향으로
            //점프하겠다.
            if (!My_Render.flipX) //오른쪽을 바라보고 있을 경우.
                My_rigid.AddForce(new Vector2(3, Min_JumpPos), ForceMode2D.Impulse);
            if (My_Render.flipX) //왼쪽을 바라보고 있을 경우.
                My_rigid.AddForce(new Vector2(-3, Min_JumpPos), ForceMode2D.Impulse);

            Min_JumpPos = 0; //점프처리가 끝났으면 모은 힘을 초기화해두겠다.
        }
    }
    

    void Click_Jump()
    {
        //인스펙터에 입력한 x,y방향으로 AddForce를 실행할 함수

        if (Input.GetMouseButtonDown(0) && !Is_Jump)
        {
            Is_Jump = true;
            My_rigid.AddForce(new Vector2(Direction_X, Direction_Y),
                              ForceMode2D.Impulse);
        }
    }
    void Velocity_Move()
    {
        //좌,우 움직임 구현 구문

        float Offset_X = Input.GetAxisRaw("Horizontal");
        //수평 키 입력을 받아 -1 , 1을 반환하겠다.

        if(Offset_X == 1)
        {
            My_Render.flipX = false;
        }
        else if(Offset_X == -1)
        {
            My_Render.flipX = true;
        }

        My_rigid.velocity = new Vector2(Offset_X * P_Speed, My_rigid.velocity.y);

        //[1] 이 객체의 X축 속력에 (방향  * 속도) 만큼의 힘을 더해줄건데,
        //[2] Y축 속력은 이 객체의 현재 속력을 그대로 유지하겠다. 

        X_Velocity = My_rigid.velocity.x; //현재 수평 속력값을 할당하겠다.
        Y_Velocity = My_rigid.velocity.y; //현재 수직 속력값을 할당하겠다.
    }

    //collision[충돌체] 이벤트 함수 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //이 객체와 충돌한 콜라이더를 가진 오브젝트의 정보를 가져오는 이벤트 함수
        //< 작동 조건 >

        //[1] 충돌한 두 객체중 하나 이상의 객체가 Rigidbody를 가지고 있을 것.
        //[2] 두 객체 모두 충돌체를 가지고 있을 것.

        if(collision.gameObject.tag == "Ground")
        {
            //충돌한 충돌체를 가진 게임 오브젝트의 태그가 "Ground"일 경우.
            //태그(tag)란?
            //ㄴ 비슷한 성질을 지닌 오브젝트들끼리 모아놓기 위해서
            //   일종의 '인식표'를 달아놓는 기능.
            //   쉬운 예로, [몬스터] 객체에게 'Enemy'태그를 달아놓는 예시가 존재한다.

            Is_Jump = false;
            //플레이어가 땅에 안착하면[충돌하면]
            //'점프중이 아니다' 상태로 전환.
        }
    }
}