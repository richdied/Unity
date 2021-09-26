using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //���� ���࿡ �־� ���Ǵ� �������� ������ ��������
    //�Ѱ��� ���ӸŴ��� ��ũ��Ʈ. 

    [Header("�������� ����")]
    public int Stage_LV;  //���� �������� ����
    public List<GameObject> Stage_List = new List<GameObject>();
    //�� ���� ������ ��� Ÿ�ϸ� ��ü����.

    [Header("�̺�Ʈ ��ü")]
    public Transform Spawn_Point; //�÷��̾ ���ʻ����� ��ġ.
    public GameObject Player; //�÷��̾� ��ü����.

    
    void Start()
    {
        Spawn_Point = transform.GetChild(0);
        Player = GameObject.Find("Player");

        Player.transform.position = Spawn_Point.transform.position;
        Swap_Stage(Stage_LV);
    }

    void Swap_Stage(int LV)
    {
        //�Ķ���ͷ� �޾ƿ� ���� �������� ������ �´�
        //���������� Ȱ��ȭ�ϰ�, �� ���� ���������� ��Ȱ��ȭ���� �Լ�.

        for(int A = 0; A < Stage_List.Count; A++)
        {//Stage_List�� ���̸�ŭ �ݺ��ϰڴ�.

          if(A == LV)
            {
                Stage_List[A].SetActive(true);
                print("���� ���� : " + (Stage_LV + 1));
            }
            else
            {
                Stage_List[A].SetActive(false);
            }

        }
    }

    public void Get_Level() // �÷��̾ ����� ȹ���ϸ� ������ �Լ�.
    {
        //[1] �÷��̾ ���� ��ġ�� ���ư���,
        //[2] ���� �������� ������ ������ ��,
        //[3] ���� ������ �°� ���ҽ�Ų��.

        Player.transform.position = Spawn_Point.transform.position;
        // ��> �÷��̾� ��ġ�� ���� ����Ʈ�� ����.

        Stage_LV++;
        //��> �׸��� �������� ������ 1������Ų��.

        Swap_Stage(Stage_LV);
        //��> Swap_Stage(int) �Լ��� �����Ͽ� ���� ������ �´� Ÿ�ϸ��� �ҷ����ڴ�.

    }
}
