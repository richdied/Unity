using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_Transform : MonoBehaviour
{
    //2021. 09 . 04

    //Transform 복습 스크립트.

    //[1] 객체의 좌표를 담당하는 컴포넌트 [ Transform ]

    //Transform 컴포넌트가 담당하는 객체의 정보
    //1. 위치정보(Position) [ 2차원 , 3차원 ]
    //2. 회전값(Rotation)   [ 2차원 , 3차원 ]
    //3. 크기(Scail)        [ 2차원 , 3차원 ]


    //[2] 좌표를 표현하는 자료형 [ Vector2 / Vector3 ]

    //[Vector2] => 2차원 좌표계를 담당. [ x,y ]
    //[Vector3] => 3차원 좌표계를 담당. [ x,y,z ]



    //[2-1] Vector에서 방향을 표현하는 파생 키워드.

    //Vector3.zero = [0,0,0]

    //[수평(x축)관련 키워드]
    //Vector3.left = [-1,0,0]
    //Vector3.right = [1,0,0]

    //[수직(y축)관련 키워드]
    //Vector3.up = [0,1,0]
    //Vector3.down = [0,-1,0]

    //[전후(z축)관련 키워드]
    //Vector3.forward = [0,0,1]
    //Vector3.back = [0,0,-1]



    //[2-2] 사용자 지정 좌표를 할당하는 [ new Vector ]
    // ㄴ 이미 정의되어 있는 파생 명령어가 아닌
    //    사용자가 원하는 좌표값을 할당하고자 할 때 사용하는 키워드로
    //    [ new Vector(float x,float y,flaot z) ] 형태를 가지고 있다.


    //[3-1] Vector타입 변수를 선언하여 객체의 위치정보에 할당하기.
    public Vector3 My_Pos;


    [Header("입력 및 시간관련 변수")]
    public int Count = 0;  //플레이어의 현재 포지션카운트

    public float Set_Time = 0;  //현재 지난 시간.
    public float Cool_Time = 0; //자동이동 간의 쿨타임.

    public bool Is_Time = true; //쿨타임이 끝난 상태인가?


    void Start()
    {
        //[3] Transform 컴포넌트를 이용하여 객체위치 바꾸기.
        //gameObject.transform.position = Vector3.zero; //[0,0,0]

        //gameObject.transform.position = new Vector3(0, 0, 0);

        //gameObject.transform.position = My_Pos;

        //gameObject란?
        // ㄴ 이 스크립트를 가지고있는 객체. => 'Player'
    }

    void Update() //1프레임 당 1번 실행되는 함수(1프레임 = 평균 0.014초)
    {
        //gameObject.transform.position = My_Pos;

        

        //[4]키 입력을 활성화하는 키워드 [ Input ]

        //1. Input.GetKeyDown()
        //   ㄴ 지정된 키를 누를때마다 한 번씩 호출.
        //2. Input.GetKey()
        //   ㄴ 지정된 키를 누르고있는 동안 계속해서 호출.
        //3. Input.GetKeyUp()
        //   ㄴ 지정된 키에서 손을 떼면 한 번씩 호출.

        //4. Input.GetMouseButton()
        //   ㄴ 지정된 마우스 버튼을 누르면 호출되는 명령어.

        // GetMouseButton() 파라메터 종류 [int타입]

        // '0' => 좌클릭
        // '1' => 우클릭
        // '2' => 휠클릭

        //if(Input.GetMouseButtonDown(0))
        //{  //좌클릭이 눌리는 순간에 true를 반환하겠다.
        //    print("Mouse_Down");
        //}
        //if(Input.GetMouseButton(0))
        //{  //좌클릭을 누르고있는 동안 true를 반환하겠다.
        //    print("Mouse_Stay");
        //}
        //if(Input.GetMouseButtonUp(0))
        //{  //좌클릭 입력이 끝나는 순간 true를 반환하겠다.
        //    print("Mouse_Up");
        //}



        //transform 컴포넌트 기초 활용예제.

        //[1] 마우스 좌클릭을 누를 때마다 화면의 각 모서리를
        //    시계방향으로 이동하는 코드를 작성해보자.

        //[2] 변수 및 자료형 활용 : 자유


        if(Set_Time >= Cool_Time && !Is_Time)
        {
            //Set_Time이 지정된 Cool_Time의 값을 넘어서고,
            //현재 쿨타임 판정 bool값이 '거짓'일 경우.

            Set_Time = 0;  //Set_Time을 다시 0으로 초기화하고
            Is_Time = true; //쿨타임이 끝났다는 신호를 보내겠다.
            print("Is_Time = true");
        }
        else
        {
            Set_Time += Time.deltaTime;
            //그게 아니라면, Set_Time에 프레임 당 시간값을
            //계속해서 누적해주겠다.
        }


        if(Is_Time)
        {  //좌클릭을 입력할때마다 해당 코드를 실행하겠다.

            Is_Time = false;
            //이동 코드가 실행되는 순간, 쿨타임 모드로 전환하겠다.

            if(Count == 0)
            {
                Count++;
                transform.position = new Vector3(8, 4);
            }
            else if(Count == 1)
            {
                Count++;
                transform.position = new Vector3(8, -4);
            }
            else if (Count == 2)
            {
                Count++;
                transform.position = new Vector3(-8, -4);
            }
            else if (Count == 3)
            {
                Count = 0;
                transform.position = new Vector3(-8, 4);
            }
        }
        
    }

}
