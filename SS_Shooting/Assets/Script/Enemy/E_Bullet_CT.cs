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
{//ㄴ 적군의 총알 움직임을 총괄할 스크립트.

    [Header("객체 컴포넌트")]
    public SpriteRenderer My_Render;

    [Header("총알 정보")]
    public Bullet_Type type; //총알 타입.
    public float Speed; //총알 속도.
    public float Bullet_ATK; //총알 공격력.
    public float Alive_Time; //총알의 생존시간.

    void Start()
    {
        My_Render = GetComponent<SpriteRenderer>();
        My_Render.flipY = true; //거꾸로 뒤집겠다.

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
            //플레이어에게 데미지를 주고 자신을 파괴할 코드
            print("플레이어 피격!");
            Destroy(gameObject);
        }
    }
}

