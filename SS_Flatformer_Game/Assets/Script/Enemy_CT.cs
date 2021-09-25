using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CT : MonoBehaviour
{
    // 적 객체의 움직을 조건에 따라 분류해둘 스크립트.
    [Header("적 객체 스텟")]
    public float Speed; //적 객체의 속도
    public int HP; //적 객체의 체력
    public float Distance; // 적이 플레이어를 인식할 수 있는 최대거리.

    [Header("객체 자료")]
    public GameObject Player; //적 객체의 타겟 오브젝트 정보
    public SpriteRenderer My_Render; //자기 자신의 컴포넌트
    public Animator My_Anim; //자기 자신의 컴포넌트
    public Rigidbody2D My_Rigid; //자기 자신의 컴포넌트


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
        //적 피격 애니메이션 구문.

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
        //플레이어와 자신의 현재 거리를 계산해서 
        //최대 사정거리 내에 들었다면, 추적을 시작하는 코드.

        float dis = Vector2.Distance(Player.transform.position, transform.position);
        //Vector.Distance(Vector A, Vector B)
        // ㄴ 파라메터에 입력된 두 좌표의 거리를 구해서 
        //    float값으로 return해주는 함수.

        if (dis < Distance)
        { //플레이어와 자신의 거리가 미리 설정된 최대 사정거리 미만일 경우.

            //플레이어 추격 코드
            if (Player.transform.position.x > transform.position.x)
            { //ㄴ> 플레이어가 자신보다 오른쪽에 위치할 경우.
                transform.Translate(Vector2.right * Speed * Time.deltaTime);
                //My_rigid.velocity = new Vector2(Speed, My_rigid.velocity.y);
                My_Render.flipX = false;
            }
        }
        else if (Player.transform.position.x < transform.position.x)
        { //ㄴ> 플레이어가 자신보다 왼쪽에 위치할 경우.
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
            My_Render.flipX = true;
        }
        else
        {
            print("추적 해제 상태");
        }

    }
} 
   