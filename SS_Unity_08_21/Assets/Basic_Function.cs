using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Function : MonoBehaviour
{
    //2021 . 08. 21 

    //Function ( 함수 )

    //함수란?
    //ㄴ 사용자가 지정한 기능이나 연산을 수행하는 일종의 
    //   기계부품으로, 프로젝트 내에서 여러번 사용해야하는 
    //   연산식을 함수기능으로 대체함으로써
    //   코드의 가독성을 높이고 편의성까지 챙길 수 있다.

    //함수 선언 기본형태
    // -> [데이터 타입] [함수명] (매개변수) {코드몸통}


    //[1] 함수 기본 형태
    void Get_Print()
    {
        print("Get_Print 함수 실행");
    }

    //[2] 함수의 반환 타입 ( return )
    // ㄴ 함수의 반환 타입이란?
    // ㄴ 모든 함수는 [데이터 타입]을 가지고 있다.
    //    지금부터 우리는 이 함수의 [데이터 타입]에 따라 달라지는
    //    반환값에 대해 알아보도록 할 것 이다.

    //    함수 데이터 타입은 존재하는 모든 타입으로 선언이 가능하며,
    //    [void] 타입이 아닌 다른 데이터 타입을 가지게 될 경우,
    //    함수에서 자판기처럼 배출[반환]해줄 [데이터 타입]에 맞는
    //    반환값을 필요로 하게 된다. 

    //    이를 요약하자면,
    //    [int]형 데이터 타입을 가진 함수 
    //    => [int]형 반환값을 꼭 반환해야한다.

    int Get_intteger()
    {
        return 3;
    }

    //[3] 함수 매개 변수(파라메터)

    //함수 파라메터란?
    //ㄴ 함수 실행시에 필요한 요소들을 직접 지정하여 
    //   함수를 정의 할 수 있는 기능이다.
    //   단, 파라메터가 1개 이상 존재하는 함수 실행시.,
    //   할당 받은 요소가 함수 파라메터의 타입과 맞기 않거나,
    //   필요한 파라메터의 수가 다를 경우
    //   함수 실행에 문제가 발생하므로
    //   주의가 필요하다.

    int Add(int A , int B )
    {//함수 실행시에 파라메터로 두개의 정수값을 받아와서
     //받아온 두 정수의 합을 반환해주겠다. 
        return A * B;
    }

    [SerializeField]
    int P_HP; //플레이어의 현재 체력

    [SerializeField]
    int P_MaxHP; //플레이어의 최대 체력

    [SerializeField]
    int E_ATK; //적의 공격력

    void Start()
    {
        //선언된 함수를 호출하여 사용하는 방법.
        Get_Print();
        
        //[2-1]  함수의 return(반환)값 받아오는 방법.

        int Result = Get_intteger();
        print("Result = " + Result);

        //[2-2]  함수의 return(반환)값 받아오는 방법.
        print("Get_Int = " + Get_intteger());

        //[3-1] 파라메터를 가진 함수 실행하기.
        Result = Add(20, 30);
        print("Add함수 실행 뒤 Result = " + Result);

        //[3-2]
        //Add()함수를 이용하여 반환값을 5500이 나오도록 
        //출력문에 활용해봅시다.
        //단, 방식은 본인 자유입니다.

        int c;
        c = Add(550, 10);
        print("Add함수 실행 결과 = " + c);

        //결과예시 : "Add함수 실행결과 = 5500"

        P_HP = P_MaxHP;
    }

    void Update()
    {
        //마우스 좌클릭 시 , 플레이어의 체력을
        //받은 데미지만큼 감소시키는 함수를 만들 것이다.

        if (Input.GetMouseButtonDown(0))
        {//마우스 좌클릭 시 true를 반환하는 키워드.

            int Damage = Random.Range(E_ATK - 5, E_ATK + 6);
            //최소값 = 적 공격력 -5
            //최대값 = 적 공격력 +5
            if (P_HP > 0)
            {
                if (Damage > 0)
                {
                    Player_Hit(Damage);
                }
                else
                {
                    print("데미지가 0 미만 입니다.");
                }
            }
            else
            {
                print("플레이어가 이미 쓰러진 상태입니다.");
            }
        }
    }

    void Player_Hit(int DMG)
    {
        P_HP -= DMG;
        print("플레이어 잔여체력: " + P_HP + " / 받은 데미지 : " + DMG);
    }
}
