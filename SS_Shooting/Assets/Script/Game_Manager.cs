using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Manager : MonoBehaviour
{   //ㄴ 게임 내적인 요소들을 수집하고 총괄할 스크립트.
    //   [필드 내의 적 객체정보를 수집하고, 각 객체의 정보를 관리]

    [Header("플레이어 추가정보")]
    public int Score; //현재 획득점수.
    public TextMeshProUGUI Score_TMPRO; //점수 UI
    public int Enemy_S_Score = 10; //각 사이즈 적군의 부여점수
    public int Enemy_M_Score = 15;
    public int Enemy_L_Score = 20;
    public int Enemy_Boss_Score = 200;

    [Header("적 스폰 포인트")]
    public float Offset_X_Min;  //적이 스폰된 X좌표 최소값.
    public float Offset_X_Max;  //적이 스폰된 X좌표 최대값.
    public float Offset_Y;      //적이 스폰될 고정 Y좌표.

    [Header("적 객체 프리펩")]
    public List<GameObject> Enemy_Prefab = new List<GameObject>();
    // ㄴ> 모든 일반 적 객체의 프리펩을 받아놓을 리스트.
    public List<GameObject> Boss_Prefab = new List<GameObject>();
    // ㄴ> 모든 보스 객체의 프리펩을 받아놓을 리스트.

    [Header("필드에 생성된 적 객체정보")]
    public List<GameObject> Enemy_List = new List<GameObject>();
    // ㄴ>현재 생성된 모든 적 객체정보를 받아놓을 리스트.

    [Header("스테이지 속성")]
    public int Limit_Enemy;
    // ㄴ>히어라키창에 동시에 존재할 수 있는 적 객체의 최대 숫자.

    public float Rand_Spawn_Time_Min;  //적 스폰딜레이 최소값.
    public float Rand_Spawn_Time_Max;  //적 스폰딜레이 최대값.
    public bool Is_Spawn;
    // ㄴ 적이 스폰되고나서, 쿨타임이 끝난 상태인가?
    // ㄴ> true => 아직 쿨타임이 지나지 않는 상태.
    // ㄴ> false => 적을 생성하고, 쿨타임이 끝난 상태. [적을 다시 생성할 준비 OK]

    public int Stage_LV; //현재 스테이지 레벨
    public bool Is_Boss_Spawn; //보스가 현재 스폰된 상태인가?
    public int Boss_Count;  //이번스테이지의 보스가 생성되기까지 필요한 적 처치 수



    void Start()
    {
        Start_Set();
        Get_Score(0);
    }

    
    void Update()
    {
        if (!Is_Boss_Spawn)
        {// ㄴ 보스가 필드에 존재하지 않을 경우에만, 일반 적 객체를 스폰하겠다.
            Enemy_Spawn();
        }
    }

    public void Get_Score(int Score)
    {
        this.Score += Score;
        // ㄴ 받아온 파라메터를 현재 스코어에 누적해주겠다.
        Score_TMPRO.text = "SCORE : " + this.Score.ToString();
        // ㄴ Text UI에 현재 점수 String(문자열) 변환하여 할달해주겠다.
    }

    void Enemy_Spawn()
    {// ㄴ 조건을 만족할 시 , 적 객체를 랜덤으로 생성할 함수.

        if (Enemy_List.Count < Limit_Enemy && !Is_Spawn)
        {// ㄴ 현재 생성된 적 수가 Limit_Enemy 미만이고, 스폰쿨타임이 끝난 상태일 경우.

            Is_Spawn = true;
            //ㄴ 적이 생성중인 상태로 즉시 전환하고
            int Rand_Count = Random.Range(0, Enemy_Prefab.Count);
            //ㄴ 0부터 모든 일반 적 종류 갯수 사이의, 랜덤값을 뽑겠다.
            Vector2 Pos = new Vector2(Random.Range(Offset_X_Min, Offset_X_Max), Offset_Y);
            //ㄴ X좌표는 랜덤으로 뽑아 할당해주고, Y좌표는 고정된 offset_Y 변수값을 할당.
            Enemy_List.Add(Instantiate(Enemy_Prefab[Rand_Count], Pos, Quaternion.identity));
            //ㄴ 랜덤한 적 프리펩 객체를 랜덤 좌표에서 생성한 다음, Enemy_List에 추가하겠다.
            Invoke("Spawn_Set", Random.Range(Rand_Spawn_Time_Min, Rand_Spawn_Time_Max));
            //ㄴ 뽑은 랜덤값만큼 대기한 뒤, 적 스폰이 가능한 상태로 전환하겠다.
        }
    }

    public void Dead_Enemy(GameObject OBJ, bool Hit_Daed)
    {//적 객체가 사망하는 시점에 Enemy_CT 내부에서 실행할 함수.
     // Hit_Dead = [플레이어에게 맞아 죽었을 경우 true / 아닐 경우 false]

        Enemy_List.Remove(OBJ);
        //ㄴ 파라메터로 받아온 OBJ 객체와 동일한 오브젝트가 Enemy_List에 있다면, 삭제하겠다.
        if(Hit_Daed) { 
            
            Boss_Count--;

            Enemy_CT EC = OBJ.GetComponent<Enemy_CT>();
            //파라메터로 받아온 적 객체의 현재 스크립트 정보를 받아오겠다.

            if(EC.type == Enemy_Type.Enemy_S) { Get_Score(Enemy_S_Score); }
            else if (EC.type == Enemy_Type.Enemy_M) { Get_Score(Enemy_M_Score); }
            else if (EC.type == Enemy_Type.Enemy_L) { Get_Score(Enemy_L_Score); }
            // ㄴ 해당 적의 타입에 맞는 점수를 현재 스코어에 누적시켜주겠다.
        }
        //ㄴ 만약, 플레이어에게 맞아서 죽었다면, Boss_Count를 1 감소시키겠다.
        Boss_Spawn();
        //ㄴ Boss_Spawn 함수 실행지점.

    }

    void Boss_Spawn()
    {// ㄴ 적이 사망할때마다 보스 스폰 조건이 만족하는지 체크하기 위한 함수.

        if(Boss_Count <= 0 && !Is_Boss_Spawn)
        {//보스를 소환하기 위해 필요한 적 처지 수가 0이하이고,
         //동시에 필드 내에 보스가 소환되어있지 않는 상태일 경우.

            Is_Boss_Spawn = true;
            //ㄴ [1] 보스가 소환된 상태로 즉시 전환하고,

            for(int A = 0; A < Enemy_List.Count; A++)
            {// ㄴ 현재 생성된 적의 수만큼 반목문을 돌려서
                Destroy(Enemy_List[A]);
                // ㄴ 모든 일반 적 객체를 파괴한 뒤,
            }
            Enemy_List.Clear();
            // ㄴ [2] Enemy_List를 완전히 비워주겠다 [리스트 길이를 0으로 할당]

            int Rand_Count = Random.Range(0, Boss_Prefab.Count);
            // ㄴ [3] 보스의 종류 중 한가지를 랜덤으로 뽑겠다.

            Instantiate(Boss_Prefab[Rand_Count], new Vector2(0, Offset_Y), Quaternion.identity);
            // ㄴ [4] 랜덤하게 뽑은 보스 프리펩을 인스턴스화[생성] 하겠다.
        }
    }
        

    void Spawn_Set()
    {// ㄴ 실행되는 순간 적 스폰이 가능한 상태로 즉시 전환하는 함수
        Is_Spawn = false;
    }
    void Start_Set()
    {// ㄴ 시작과 동시에 모든 값을 할당할 함수.

        Stage_LV = 1;
        Limit_Enemy = 5;
        Boss_Count = 15;
        Is_Boss_Spawn = false;
        Is_Spawn = false;
    }
}
