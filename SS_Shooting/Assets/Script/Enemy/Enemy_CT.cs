using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI 타입을 사용하겠다.


//열거체 ( enum ) 란?
// ㄴ> 유니티에서 열거체는 각 객체를 구분하기 위한 용도로 사용된다.
//     유니티의 태그에는 상한 갯수가 있기 때문에 이를 방지하기 위하여,
//     열거체를 활용한 조건문으로 대체하기도 한다.

//     요약: 개발자 본인이 직접 선언하는 태그(tag) 시스템.

public enum Enemy_Type
{
    Enemy_S,
    Enemy_M,
    Enemy_L,
    BOSS,
    O
}

[System.Serializable]
public class Enemy 
{//ㄴ 에너미 객체가 가지고 있는 모든 속성정보를 가지는 클래스
    [Header("적 기본 스텟")]
    public float HP; //적의 현재체력.
    public float Max_HP; //적의 최대체력.
    public float Speed; //적의 이동속도.

    public float Shooting_Cool; //적의 연사 속도.
    public int Limit_Bullet; //적의 장탄수.
    public bool Shoot_Ready = true; //적의 장전여부.

    [Header("적 컴포넌트")]
    public GameObject E_Bullet; //적의 총알 프리펩.
    public Sprite E_Normal_Image; //적의 통상이미지.
    public Sprite E_Hit_Image; //적이 피격당했을때의 이미지.

    public void Enemy_Hit(int Damage)
    {//ㄴ 해당 객체가 공격받으면 호출할 함수.
        HP -= Damage;
        // ㄴ 들어온 데미지만큼 체력을 감소시키겠다.
    }

}
public class Enemy_CT : MonoBehaviour
{//ㄴ 적의 움직임이나, 공격을 제어 할 스크립트.

    public Enemy_Type type;
    //ㄴ 적의 타입을 지정해줄 enum타입 변수.
    
    public Enemy Info;
    //ㄴ 적의 기본 속성을 가지는 커스텀 클래스.

    [Header("플레이어 정보")]
    public GameObject Player;

    [Header("객체 컴포넌트")]
    public SpriteRenderer My_Render;

    [Header("적 매니저")]
    public Game_Manager G_Manager;

    [Header("적 UI정보")]
    public Slider My_HP_Val; //자신의 체력바 UI

    void Start() //객체가 생성될 때.
    {
        Component_Get();

        My_HP_Val = transform.GetChild(0).GetChild(0).GetComponent<Slider>();
        // ㄴ 이 객체의 자식의 자식에게 있는 Slider 컴포넌트를 GET하겠다.

        Set_UI();
        //ㄴ 그리고 감소된 체력에 맞게 UI값을 갱신해주겠다.
    }


    void Update()
    {
        if (type != Enemy_Type.BOSS)
        {
            transform.Translate(Vector2.down * Info.Speed * Time.deltaTime);
            //ㄴ 적이 자신의 속도에 맞게 아래로 점점 내려오도록 만들어주겠다.
        }
        else if(type == Enemy_Type.BOSS && transform.position.y > 2.8f)
        {
            transform.Translate(Vector2.down * Info.Speed * Time.deltaTime);
            // ㄴ y좌표가 2.8을 초과할때만 아래로 내려오게 해주겠다.
        }

        if(Info.Shoot_Ready && Info.Limit_Bullet > 0)
        {// ㄴ 총알이 장전된 상태고, 총알 잔량이 0발을 초과할 경우 [1발 이상일 경우]
            


                Info.Shoot_Ready = false; //장전중인 상태로 전환하고, 

                Info.Limit_Bullet--; //재고 탄환을 1발 감소시킨 뒤,

                Shoot_Bullet();

                if (type != Enemy_Type.BOSS)
                {
                    Invoke("Shoot_Cool", Info.Shooting_Cool);
                    //ㄴ 쿨타임만큼 대기한 뒤, 해당 함수를 실행하겠다.
                }
            }


        Enemy_Dead();
    }

    void Set_UI()
    {//ㄴ HP의 값이 변경될때마다 호출하여 최신 체력상태를 갱신하는 함수.

        My_HP_Val.value = (Info.HP / Info.Max_HP) * 100f;
    }

    public void Hit_Function(int Damage)
    {
        Info.Enemy_Hit(Damage);
        //ㄴ 받아온 데미지 만큼 체력을 감소시키겠다.
        Set_UI();
        //ㄴ 그리고 감소된 체력에 맞게 UI값을 갱신해주겠다.
        StartCoroutine(Hit_Effect());
        //ㄴ 그리고, 피격 이벤트 코루틴 함수를 실행하겠다.
        Enemy_Dead();
    }

    IEnumerator Hit_Effect()
    {
        My_Render.sprite = Info.E_Hit_Image;
        //ㄴ적이 공격당했다면, Hit_Image를 현재 스프라이트에 할당한 뒤,
        yield return new WaitForSeconds(0.05f);
        //ㄴ 0.05초간 대기한 후에.
        My_Render.sprite = Info.E_Normal_Image;
        //ㄴ 원래의 스프라이트 이미지로 다시 할당해주겠다.
        StopCoroutine(Hit_Effect());
        //ㄴ 상단의 모든 코드를 실행했다면, 해당 코루틴을 종료하겠다.
    }
      
    void Shoot_Bullet() //총알발사 함수.
    {
        Vector3 Direction = (Player.transform.position - transform.position);
        //목표좌표를 바라보는 연산식 = [목표물 좌표] - [본인 좌표]

        float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;

        //Mathf.Atan2(float y, float x)
        // ㄴ> 오브젝트를 바라보는 벡터값(Direction)의 y,x값을 입력받아서,
        //     2d환경에서 해당 오브젝트를 바라볼 수 있는 z 회전값을 라디안 각도로
        //     반환해주는 함수.

        //Mathf.Rad2Deg
        //ㄴ> 유니티에서 정상적으로 표현할 수 없는 라디안 각도 단위를
        //    Vector 좌표 단위를 변환해주는 명령어.

        if(type == Enemy_Type.Enemy_L)
        {
            Instantiate(Info.E_Bullet, new Vector2(transform.position.x + 0.35f, transform.position.y - 0.5f), 
                Quaternion.AngleAxis(Angle +90, Vector3.forward));

            Instantiate(Info.E_Bullet, new Vector2(transform.position.x - 0.35f, transform.position.y - 0.5f),
               Quaternion.AngleAxis(Angle + 90, Vector3.forward));
        }
        else if (type == Enemy_Type.Enemy_M)
        {
            Instantiate(Info.E_Bullet, new Vector2(transform.position.x + 0.35f, transform.position.y - 0.35f),
                Quaternion.AngleAxis(Angle + 90, Vector3.forward));
        }
        else if (type == Enemy_Type.Enemy_S)
        {
            Instantiate(Info.E_Bullet, new Vector2(transform.position.x, transform.position.y-0.25f),
                Quaternion.AngleAxis(Angle + 90, Vector3.forward));
        }
        else if (type == Enemy_Type.BOSS)
        {
            StartCoroutine(Boss_Skill());
        }
        //Quaternion.AngleAxis(float Angle, Vector3 Axis)
        // ㄴ> Axis[중심축] 을 기준으로, Angle만큼 회전한 회전값을
        //     반환받는 객체에게 할당해주겠다.

    }

    IEnumerator Boss_Skill()
    {
        int Rand = Random.Range(0, 1);

        if(Rand == 0) //1번 패턴
        {
            int Main_Angle = 0;
            int Sub_Angle = 0;

            for(int A = 0; A < 15; A++)
            {
                for(int B = 0; B < 30; B++)
                {
                    Instantiate(Info.E_Bullet, new Vector2(transform.position.x, transform.position.y),
                        Quaternion.AngleAxis(Main_Angle + Sub_Angle, Vector3.forward));

                    Main_Angle += 12;

                }
                Sub_Angle += 1;
                yield return new WaitForSeconds(0.1f);
            }
        }

        Invoke("Shoot_Cool", Info.Shooting_Cool);
        //패턴이 전부 끝났다면, 쿨타임을 돌리겟다.
    }

    void Shoot_Cool() //재장전 함수
    {
        Info.Shoot_Ready = true;
        //이 함수를 실행하면 재장전이 완료된 상태로 전환하겠다. => 총알발사 준비 완료.
 
    }

    void Enemy_Dead()
    {
        if(type != Enemy_Type.BOSS)
        {

            if (transform.position.y <= -6.0f)
            {//ㄴ y좌표값이 -6 이하일 경우.
                StopAllCoroutines();
                //ㄴ 객체를 파괴하기 전, 실행중인 모든 코루틴 함수를 정지한 뒤, 
                G_Manager.Dead_Enemy(gameObject, false); //자연사
                //ㄴ 적 리스트에서 자신을 제거한 뒤,
                Destroy(gameObject);
                //ㄴ 자기 자신을 파괴하겠다.
            }
            else if (Info.HP <= 0)
            {
                StopAllCoroutines();
                //ㄴ 객체를 파괴하기 전, 실행중인 모든 코루틴 함수를 정지한 뒤, 
                G_Manager.Dead_Enemy(gameObject, true); //맞아죽음
                //ㄴ 적 리스트에서 자신을 제거한 뒤,
                Destroy(gameObject);
                //ㄴ 자기 자신을 파괴하겠다.
            }
        }
        else if(type == Enemy_Type.BOSS)
        {
            if(Info.HP <= 0)
            {// ㄴ 보스 객체의 체력이 0 이하일 경우.
                G_Manager.Get_Score(G_Manager.Enemy_Boss_Score);
                // ㄴ 보스가 가지고있는 점수만큼 스코어를 누적해주겠다.
                G_Manager.Stage_LV++;
                //스테이지 레벨을 1 증가시키고
                G_Manager.Is_Boss_Spawn = false;
                //보스가 스폰되어있지 않는 상태로 전환한 뒤,
                G_Manager.Boss_Count = (15 + (G_Manager.Stage_LV - 1));
                //현재 레벨에 따라 보스 카운트를 1씩 증가시키겠다.

                StopAllCoroutines();
                Destroy(gameObject);
            }
        }
    }

    void Component_Get()
    {   //ㄴ 시작과 동시에 필요한 컴포넌트와 각 변수를 할당할 함수.

        Info.HP = Info.Max_HP;
        // ㄴ 현재 체력에 최대 체력을 할당해주겠다.

        Player = GameObject.Find("Player");
        // ㄴ 히어라키 창의 모든 객체 중 "Player"라는 이름을 가진 객체를 찾아 넣겠다.
        My_Render = GetComponent<SpriteRenderer>();
        // ㄴ 자기 자신이 가지고 있는 <> 컴포넌트를 찾아 할당하겠다.
        G_Manager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
    }
}
