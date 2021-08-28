using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusTest_Script : MonoBehaviour
{
    //심화문제 MonoBehaviour 스크립트.

    //게임 오브젝트에 장착할 스크립트입니다.
    //아무 게임오브젝트나 생성한 뒤, 이 스크립트를 적용시켜주시고
    //유니티 실행 뒤 마우스 좌클릭을 입력해보세요.


    public Monster My_Status = new Monster(200, 100, 10, 10, "고블린");
    public Player My_Player = new Player(3000, 100, 250, 5, "탱커");

    public List<Monster> Monster_List = new List<Monster>();

    void Start()
    {
        Monster_List.Add(new Monster(500, 200, 10, 15, "골렘"));
        Monster_List.Add(new Monster(1500, 300, 10, 15, "스톤골렘"));
        Monster_List.Add(new Monster(3500, 400, 10, 15, "고대골렘"));
        Monster_List.Add(new Monster(5500, 500, 10, 15, "짱센골렘"));
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Monster_List.Count > 0 && My_Player != null)
            {  //리스트의 길이가 1 이상이고 플레이어 객체가 비어있지 않은 상태라면

                print("플레이어가 적을 공격하여 " + My_Player.ATK + " 만큼의 피해를 입혔습니다.");
                Monster_List[0].HP -= My_Player.ATK;
                //0번 객체의 HP를 플레이어의 ATK만큼 차감하겠다.

                print("적이 플레이어를 공격하여 " + Monster_List[0].ATK + "만큼의 피해를 입혔습니다.");
                My_Player.HP -= Monster_List[0].ATK;

                print("플레이어 잔여체력 = " + My_Player.HP + " / " + 
                      Monster_List[0].Name + " 잔여체력 = " + Monster_List[0].HP);

                if(My_Player.HP <= 0)
                {
                    print("플레이어가 사망하였습니다.");
                    My_Player = null;
                }
                if(Monster_List[0].HP <= 0)
                {
                    print(Monster_List[0].Name + "(이) 토벌되었습니다.");
                    Monster_List.RemoveAt(0);
                }               
            }
            if (Monster_List.Count == 0)
            {
                print("모든 몬스터가 토벌되었습니다.");
            }
        }
    }
}
