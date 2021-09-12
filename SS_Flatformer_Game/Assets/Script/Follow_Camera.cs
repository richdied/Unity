using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Camera : MonoBehaviour
{
    // ī�޶� �÷��̾ ã�� ����ٴϴ� �ڵ�.
    [SerializeField]
    GameObject Player; //�÷��̾� ��ü.

    public Vector3 Add_Pos; //�߰����� ��ǥ ������ ����� ����.
    public float Camera_Speed; //ī�޶��� �̵��ӵ�.

    void Start()
    {
        
    }

    void Update()
    {
        if (Player == null) //�÷��̾� ��ü�� �Ҵ���� ���� ������ ���.
        {
            Player_Set();
        }
        else if (Player != null) //�÷��̾ �Ҵ�Ǿ��ִ� ������ ���.
        {
            Follow_Player(); //�÷��̾ ���� �ٴϰڴ�.
        }
    }
    
    void Player_Set()
    { // 'Player'��ü�� ���� ��� ã�Ƽ� �־��� �Լ�.
        Player = GameObject.Find("Player");
        //���̾��Ű â�� ��� ��ü�� "Player"��� �̸��� ��ü�� ã�� �־��ְڴ�.
    }

    void Follow_Player()
    { // 'Player'��ü�� ���� ��� ����ٴ� �ڵ�.

        Vector3 Move_Pos = (Player.transform.position 
             + Add_Pos );
        transform.position = Vector3.Lerp(transform.position, Move_Pos, Camera_Speed * Time.deltaTime);
        
        //Vector.Lerp(������ǥ,��ǥ��ǥ,�ӵ�)

        //��> [���� ��ǥ]���� [��ǥ ��ǥ]���� [�ӵ�]�� ������ ��ŭ �̵��ϵ�
        //    [��ǥ ��ǥ]�� ����������� ���� ��������.
    }
}
