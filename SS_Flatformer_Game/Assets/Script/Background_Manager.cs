using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Manager : MonoBehaviour
{
    [Header("��� ������Ʈ")]
    public GameObject Player; //�÷��̾� ����
    public GameObject BackGround; //��������Ʈ
    public float Scroll_Speed; // ������ ���� �ӵ�

    public Player_CT Player_Script; //�÷��̾� ��ũ��Ʈ ����
    public SpriteRenderer BG_Render; //��� ��������Ʈ ����



    void Start()
    {
        Player_Script = Player.GetComponent<Player_CT>();
        BG_Render = BackGround.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 Camera_Pos = transform.position;

        BackGround.transform.position = Camera_Pos;
        //��� ��ü�� ī�޶� �ǽð����� ����ٴϴ� �ڵ�.

        //�÷��̾ �����̴� ���⿡ ���� ������ ������ ������ �ڵ�.
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
