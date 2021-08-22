using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_List : MonoBehaviour
{
    //2021. 08. 22

    //C# 리스트 [List]

    //ㄴ 리스트의 구조는 배열과 크게 다를 바 없으나,
    // 리스트의 경우, 배열처럼 배열의 길이에 제한을 받지 않고,
    // 필요할때 요소를 자유롭게 삭제하고, 추가하는 것이
    // 가능하다.

    // 상황에 따라 요소를 추가해야하거나, 삭제해야 하는
    // 게임 내 요소가 존재 할 경우 광범위하게 활용 할 수 있다.

    //Array[배열] : 최대 개수가 정해져있는 객체를 저장할 때,
    //ex ) 플레이어 인벤토리, 적 에셋 또는 프리펩[적을 찍어내는 도장].

    //List[리스트]: 실시간으로 객체가 변하는 객체들을 관리할 때.
    //ex ) Player HP, 몬스터 객체, 필드 내 드랍아이템.

    //★ List 선언 기본형태.
    List<int> Int_List = new List<int>();
    //[1] int형 List변수 Int_List를 선언하고,
    //[2] List<int>형 공간을 새로히 할당해주겠다.
    //[3] Int_List라는 변수를 사용할 준비 끝.


    //★ 커스텀 클래스 단일객체 생성하기.
    public Player P_1 = new Player(50, 10, 5, "홍길동");

    //★ 커스텀 클래스타입 List 생성하고, 객체 만들기.
    public List<Player> Player_List = new List<Player>();

    void Start()
    {
        //[ List 파생 명령어 ]

        //[ 1.List.Add() ]
        //  ㄴ 리스트 요소 추가 명령어.
        //  ㄴ 원하는 값을 리스트의 맨 뒤쪽 요소로 추가한다.

        Int_List.Add(25); //0번 요소 [ 첫번째 요소]
        Int_List.Add(50); //1번 요소 [ 두번째 요소]
        Int_List.Add(75);
        Int_List.Add(100);
        Int_List.Add(125);
        Int_List.Add(150);
        Int_List.Add(175);
        Int_List.Add(200);
        Int_List.Add(225);
        Int_List.Add(250);

        Print_List("List_Add 호출 후 배열값");


        //[ 2. List.Remove() ]
        //  ㄴ 입력한 값을 가진 요소를 1개 삭제할 수 있는 명령어.

        //주의점: 배열요소내에 입력한 값을 가진 요소가 2개 이상 있다면, 
        //       0번 요소에서 가장 가까운 요소 1개를 삭제한다.

        Int_List.Remove(50);
        // ㄴ 배열요소 내에서 50의 값을 가진 요소가 있다면,
        //    0번 요소에서 가장 가까운 50의 값을 가진 요소 1개를 삭제하겠다.

        Print_List("List_Remove 호출 후 배열값");

        //[ 3. List.RemoveAt() ] 
        //  ㄴ List요소의 배열 번호를 지정해서 삭제하는 명령어.

        Int_List.RemoveAt(3);
        // ㄴ 배열 요소중 3번 요소를 삭제하겠다. // 125 삭제

        //[문제1]
        //RemoveAt 함수를 사용하여 List 길이에 상관없이
        //언제나 마지막 요소를 삭제할 수 있도록 코드를 작성하시오.
        //단, 정수만 사용하여 삭제하는것은 금지.
        if (Int_List.Count >= 1)
        {
            Int_List.RemoveAt(Int_List.Count - 1); // 250 삭제
            // ㄴ 배열의 마지막 요소에 접근하여 삭제하기.
            Print_List("List_RemoveAt 호출 후 배열값");

            // [ 4. List.Clear() ]
            //   ㄴ List의 내부요소를 모두 지워버리겠다.
            //   ㄴ 실행 시 List 길이는 0으로 할당.
            Int_List.Clear();
            Print_List("List_Clear 호출 후 배열값");


            //[ 5. 클래스 타입 객체의 생성자를 호출하여 리스트에 추가하는 방법 ]
            Player_List.Add(new Player(300, 50, 5, "기사"));
            Player_List.Add(new Player(200, 100, 7, "마법사"));

            Player_List[0].Set_Status();
            Player_List[1].Set_Status();
        }
    }

    void Print_List(string Str)
    {
        print(Str);

        print("Int_List의 총 길이 : " + Int_List.Count);

        for (int A = 0; A < Int_List.Count; A++)
        {
            print("Int_List의" + (A + 1) + "번째 요소 :" + Int_List[A]);
        }
    }
}
