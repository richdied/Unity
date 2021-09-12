using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Manager : MonoBehaviour
{
    [Header("배경 오브젝트")]
    public GameObject Player; //플레이어 정보
    public GameObject BackGround; //배경오프젝트
    public float Scroll_Speed; // 오프셋 변경 속도

    public Player_CT Player_Script; //플레이어 스크립트 정보
    public SpriteRenderer BG_Render; //배경 스프라이트 정보



    void Start()
    {
        Player_Script = Player.GetComponent<Player_CT>();
        BG_Render = BackGround.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 Camera_Pos = transform.position;

        BackGround.transform.position = Camera_Pos;
        //배경 객체가 카메라를 실시간으로 따라다니는 코드.

        //플레이어가 움직이는 방향에 따라 오프셋 방향을 결정할 코드.
        if(Player_Script.Offset_X == -1)
        {
            float Add_X = BG_Render.material.mainTextureOffset.x - (Scroll_Speed * Time.deltaTime);

            BG_Render.material.mainTextureOffset = new Vector2(Add_X, 0);
        }
        else if (Player_Script.Offset_X == 1)
        {
            float Add_X = BG_Render.material.mainTextureOffset.x + (Scroll_Speed * Time.deltaTime);

            BG_Render.material.mainTextureOffset = new Vector2(Add_X, 0);
        }


    }
}
