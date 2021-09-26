using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //게임 진행에 있어 사용되는 전반적인 변수와 정보들을
    //총괄할 게임매니저 스크립트. 

    [Header("스테이지 정보")]
    public int Stage_LV;  //현재 스테이지 레벨
    public List<GameObject> Stage_List = new List<GameObject>();
    //ㄴ 현재 생성된 모든 타일맵 객체정보.

    [Header("이벤트 객체")]
    public Transform Spawn_Point; //플레이어가 최초생성될 위치.
    public GameObject Player; //플레이어 객체정보.

    
    void Start()
    {
        Spawn_Point = transform.GetChild(0);
        Player = GameObject.Find("Player");

        Player.transform.position = Spawn_Point.transform.position;
        Swap_Stage(Stage_LV);
    }

    void Swap_Stage(int LV)
    {
        //파라메터로 받아온 현재 스테이지 레벨에 맞는
        //스테이지를 활성화하고, 그 외의 스테이지를 비활성화해줄 함수.

        for(int A = 0; A < Stage_List.Count; A++)
        {//Stage_List의 길이만큼 반복하겠다.

          if(A == LV)
            {
                Stage_List[A].SetActive(true);
                print("현재 레벨 : " + (Stage_LV + 1));
            }
            else
            {
                Stage_List[A].SetActive(false);
            }

        }
    }

    public void Get_Level() // 플레이어가 깃발을 획득하면 실행할 함수.
    {
        //[1] 플레이어가 스폰 위치로 돌아가고,
        //[2] 현재 스테이지 레벨을 증가한 뒤,
        //[3] 맵을 레벨에 맞게 스왑시킨다.

        Player.transform.position = Spawn_Point.transform.position;
        // ㄴ> 플레이어 위치를 스폰 포인트로 변경.

        Stage_LV++;
        //ㄴ> 그리고 스테이지 레벨을 1증가시킨다.

        Swap_Stage(Stage_LV);
        //ㄴ> Swap_Stage(int) 함수를 실행하여 현재 레벨에 맞는 타일맵을 불러오겠다.

    }
}
