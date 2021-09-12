using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Camera : MonoBehaviour
{
    // 카메라가 플레이어를 찾아 따라다니는 코드.
    [SerializeField]
    GameObject Player; //플레이어 객체.

    public Vector3 Add_Pos; //추가적인 좌표 조정에 사용할 정보.
    public float Camera_Speed; //카메라의 이동속도.

    void Start()
    {
        
    }

    void Update()
    {
        if (Player == null) //플레이어 객체가 할당되지 않은 상태일 경우.
        {
            Player_Set();
        }
        else if (Player != null) //플레이어가 할당되어있는 상태일 경우.
        {
            Follow_Player(); //플레이어를 따라 다니겠다.
        }
    }
    
    void Player_Set()
    { // 'Player'객체가 없을 경우 찾아서 넣어줄 함수.
        Player = GameObject.Find("Player");
        //하이어라키 창의 모든 객체중 "Player"라는 이름의 객체를 찾아 넣어주겠다.
    }

    void Follow_Player()
    { // 'Player'객체가 있을 경우 따라다닐 코드.

        Vector3 Move_Pos = (Player.transform.position 
             + Add_Pos );
        transform.position = Vector3.Lerp(transform.position, Move_Pos, Camera_Speed * Time.deltaTime);
        
        //Vector.Lerp(시작좌표,목표좌표,속도)

        //ㄴ> [시작 좌표]부터 [목표 좌표]까지 [속도]의 빠르기 만큼 이동하되
        //    [목표 좌표]에 가까워질수록 점점 느려진다.
    }
}
