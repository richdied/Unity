using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CT : MonoBehaviour
{
    //플레이어의 움직임과, 플레이어 입력을 처리하는 스크립트.

    [Header("플레이어 스텟")]
    public float Speed;         //플레이어의 속도

    public float Shooting_Cool; //플레이어의 연사속도
    public bool Is_Shooting;    //총알을 발사하고, 쿨타임을 기다리는 중인가?

    [Header("프리펩")]
    public GameObject Bullet_Type_1; //플레이어의 첫번째 총알 프리펩 정보.

    [Header("객체 컴포넌트")]
    public Animator My_Anim;        //객체 자신의 애니메이션 컴포넌트.
    public Rigidbody2D My_Rigid;    //객체 자신의 강체 컴포넌트.

    void Start()
    {
        Component_Get();
    }

    void Update()
    {
        Move_State();
    }

    void Component_Get()
    {   //시작과 동시에 필요한 컴포넌트들을 할당받는 함수.

        My_Anim = GetComponent<Animator>(); //자기 자신의 Animator 할당.
        My_Rigid = GetComponent<Rigidbody2D>(); //자기 자신의 강체 할당.
    }

    void Move_State()
    {   //키 입력에 따른 상/하/좌/우 이동 함수.

        float Offset_X = Input.GetAxisRaw("Horizontal"); //좌,우 키입력.
        float Offset_Y = Input.GetAxisRaw("Vertical");   //상,하 키입력.

        My_Rigid.velocity = new Vector2(Offset_X * Speed, Offset_Y * Speed);
        //이동처리 코드.

        My_Anim.SetInteger("Is_Move", (int)Offset_X);
        //애니메이션 처리 코드.

        if(Input.GetKey(KeyCode.Z) && !Is_Shooting)
        {   //공격 코드.

            Is_Shooting = true;  //쿨타임 상태로 전환

            Invoke("CoolTime_Set", Shooting_Cool);
            //Invoke(Function_Name, float)
            // ㄴ> 이 스크립트 내에서만 한정하여, 입력된 문자열과 같은 이름의 함수를 찾아
            //     실행하겠다. 단, 입력받은 float(실수)값만큼 대기한 후에.

            Instantiate(Bullet_Type_1, transform.position, Quaternion.identity);
            //Instantiate(GameObject, Vector, Quaternion)
            // ㄴ> 파라메터로 전달받은 GameObject 객체를 
            //     입력받은 Vector(좌표)와 Quaternion(회전값)에 맞게
            //     동적 생성하는 명령어.
        }
    }

    void CoolTime_Set()
    {
        Is_Shooting = false;
    }
}
