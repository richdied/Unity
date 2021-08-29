using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Transform : MonoBehaviour
{
    //2021. 08. 29

    //객체의 좌표를 담당하는 컴포넌트 [ Transform ]

    //[Transform] 컴포넌트는 객체의
    //[1] 위치정보 ( 2차원, 3차원)
    //[2] 회전값 ( 2차원, 3차원 )
    //[3] 크기 ( 2차원, 3차원 )

    //이 세 가지를 제어하며, 게임 제작에 가장 중요한 역할을 담당한다.
    //이 스크립트에서는 [ Transform] 컴포넌트를 스크립트 내부에서
    //제어하는 방법에 대해 간략하게 알아보겠다.

    // 컴포넌트 [ Component(요소, 부품) ] 란?
    // -> 각 게임 오브젝트가 가지고 있는 기능.

    //[2] 좌표를 표현하는 키워드 [ Vector2 / Vector3 ]

    //[Vector2] => 2차원 좌표계를 담당. ( x축(수평) , y축(수직) )
    //[Vector3] => 3차원 좌표계를 담당. ( x축 , y축 , z축(앞뒤) )

    //ㄴ Vector타입을 활용할 수 있는 경우.
    // 1. 오브젝트의 좌표를 저장하는 경우.
    // 2. 오브젝트가 바라보는 방향을 벡터좌표로 받아오는 경우.
    // 3. 오브젝트간의 거리를 구하고자 할 때.

    //[2-1] Vector 고유 파생 키워드 

    //Vector의 고유 파생 키워드는 주로 좌표를 지정하기 위해 사용하기보단,
    //객체를 명령어로 움직일 때, 움직일 방향을 결정해주기 위해 사용한다.

    // Vector3.zero = (0,0,0)

    //[수평(x축)관련]
    // Vector3.left = (-1,0,0)
    // Vector3.right = (1,0,0)

    //[수직(y축)관련]
    // Vector3.up = (0,1,0)
    // Vector3.down = (0,-1,0)

    //[앞뒤(z축)관련]
    // Vector3.foward = (0,0,1)
    // Vector3.back = (0,0,-1)

    //[2-2] 사용자 지정 좌표를 할당하는 [ new Vector]

    // ㄴ 이미 정의되어 있는 파생 명령어가 아닌
    //    사용자가 원하는 좌표값을 할당하고자 할 때 사용하는 키워드로
    //    [ new Vector(float,float) ] 형태를 가지고 있다.


    public int Speed; //플레이어의 이동 속도.
    public float Set_Time; //런타임 계산기.



    void Start() //객체가 생성될 때 최초1번 실행되는 함수.
    {
        //[3] Transform 키워드 파생 명령어 [ position ] 
        // ㄴ 지정된 객체의 '좌표'를 입력받은 값으로 변경한다.

        //transform.position = Vector2.zero;
        //이 객체의 position(좌표)를 (0,0)으로 할당하겠다.

        //transform.position = new Vector2(1, 2);
        //이 객체의 좌표를 (1, 2)으로 할당하겠다.

        //[4] Transform 회전값 변경 명령어 [ Rotate() , rotation ] 

        //transform.Rotate(new Vector3(0, 0, 45));
        //Rotate(Vector3)
        // ㄴ 입력한 x,y,z회전값을 오브젝트의 현재 회전값에 더해주겠다. 

        //transform.rotation = Quaternion.Euler(0,0,45);
        //Quaternion.Euler(float,float,float)
        // ㄴ 입력한 x,y,z회전값을 오브젝트에 할당해주겠다.

        //transform.eulerAngles = new Vector3(0, 0, 45);
        //eulerAngles
        // ㄴ 할당받은 좌표값을 회전값으로 바꿔 오브젝트에게 할당해주겠다.


        //[5] 객체의 크기[Scale]을 스크립트에서 제어하는 방법.
        //transform.localScale = new Vector3(3, 3, 1);
        //transform.localScale = Vector
        // ㄴ 입력한 x,y,z 벡터값을 오브젝트의 Scale에 할당해주겠다.
    }

    void Update() // 1프레임 당 한번씩 호출하는 함수 ( 1프레임 = 평균 0.014초 )
    {
        //[6]입력받은 벡터 방향과 속도로 객체를 이동시키는 명령어
        // ㄴ [ Translate( 방향, 속도) ] 

        //transform.Translate(Vector2.left * Speed * Time.deltaTime);

        //[6-1] Time.deltaTime 키워드
        // ㄴ 1프레임이 지나는데 소요된 시간을 float타입으로 반환하는 키워드.
        //    이를 활용하여 다음과 같이 타이머를 구현할 수도 있다.

        Set_Time += Time.deltaTime;

        //[6-2] 키 입력을 받을 때만 객체 움직임 활성화하기 [ GetKey ]

        //1. GetKeyDown()
        // ㄴ 지정된 키를 누를때마다 한번씩 호출
        //2. GetKey()
        // ㄴ 지정된 키를 누르고 있는 동안 계속해서 호출.
        //3. GetKeyUp()
        // ㄴ 지정된 키에서 손을 떼면 한번씩 호출.

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            print("왼쪽 화살표가 눌렸습니다 [Down]");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
            print("왼쪽 화살표를 누르고 있습니다. [Stay]");
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            print("왼쪽 화살표 입력이 끝났습니다 [Up]");
        }

        //현재 플레이어가 왼쪽 키입력밖에 받지 못하는 상태이다.
        //위 코드를 활용하여 오른쪽,왼쪽 아래쪽 키입력을 받고 
        //맞는 방향으로 움직일 수 있도록 코드를 작성해보자.

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
         
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * Speed * Time.deltaTime);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * Speed * Time.deltaTime);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
        }

    }
}
