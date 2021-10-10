using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bullet_CT : MonoBehaviour
{
    //[1] 플레이어 총알의 기본적인 움직임을 제어.
    //[2] 조건을 만족했을 시, 자기 자신을 파괴할 코드.
    //
    //[2-2] 총알이 파괴되는 조건
    //      ㄴ 1. 적 객체와 충돌했을 경우.
    //      ㄴ 2. 일정 y좌표를 초과했을 경우.

    [Header("총알 속성")]
    public float Speed;     //총알 속도.
    public float Limit_Y;   //총알이 날아갈 수 있는 최대 y좌표

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);

        if(transform.position.y >= Limit_Y)
        {  //ㄴ 자신의 y좌표가 지정된 값 이상일 경우.

            Destroy(gameObject);
            // ㄴ 자기 자신을 파괴하겠다.
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //첫번째 방법.
            collision.gameObject.GetComponent<Enemy_CT>().Hit_Function(1);

            //두번째 방법.
            //Enemy_CT EC = collision.gameObject.GetComponent<Enemy_CT>();
            //EC.Hit_Function(1);

            print("적 객체 감지!");
            Destroy(gameObject);
        }
        //적 객체 피격함수 호출.
        //자기 자신을 파괴.
    }
}
