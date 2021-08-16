using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Basic : MonoBehaviour
{
    // 2021.08.14

    //[1] Random [랜덤값 만들기]

    // ㄴ C#에서 랜덤값을 도출하기 위해 사용하는 키워드로,
    // 파생 명령어 Range()함수를 이용해 원하는 범위의
    // 랜덤값을 지정하여 임의의 값을 받아올 수 있다. 

    // 마우스 좌클릭 시 랜덤값을 뽑아 거기에 맞는 아이템을 
    // 획득하는 간단한 코드 작성. 

    [Header("획득내역")]
    public int Get_S;
    public int Get_A;
    public int Get_B;
    public int Get_C;
    public int Get_G;

    [Header("사용금액 및 뽑기 횟수")]
    public int Use_Money; //총 소비 비용
    public int Total_Amount;//총 뽑기 횟수
    public int Price; //1회 뽑기 비용 [ 회당 2500원 ]

    void Start()
    {
        print(Random.Range(0,101));
        // 0 ~ 100까지 숫자 중 랜덤으로 뽑기.
    }


    void Update()
    {

            if (Input.GetMouseButtonDown(0))
            {// 왼쪽 마우스 버튼을 누를때마다 한번씩 호출.
            for (int A = 0; A <= 100; A++)
            {
                Total_Amount++; // 총 뽑기 비용 증가
                Use_Money += Price; // 소비비용 1회치 만큼 증가

                int Rand = Random.Range(1, 100001);
                //1부터 100까지 중 랜덤값을 뽑겠다.
                //그리고 나온 값을 Rand 변수에 할당해주겠다.

                if (Rand > 0 && Rand <= 32)
                {//Rand가 0 초과 3 이하면 = (1,2,3) = 0.003%
                    print("< S등급 아이템 획득 >");
                    Get_S++;
                }
                else if (Rand > 3 && Rand <= 50)
                {// Rand가 3 초과 10 이하면 = (4~10) = 7%
                    print("< A등급 아이템 획득 >");
                    Get_A++;
                }
                else if (Rand > 50 && Rand <= 100)
                {// Rand가 3 초과 10 이하면 = (11~50) = 40%
                    print("< B등급 아이템 획득 >");
                    Get_B++;
                }
                else if (Rand > 100 && Rand <= 300)
                {// Rand가 3 초과 10 이하면 = (51~80) = 30%
                    print("< C등급 아이템 획득 >");
                    Get_C++;
                }
                else //위 조건이 아닌 모든 경우
                {
                    print("잡동사니 획득");
                    Get_G++;
                }
            }

        }
    }
}
