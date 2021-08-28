using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusTest_Script : MonoBehaviour
{
    //��ȭ���� MonoBehaviour ��ũ��Ʈ.

    //���� ������Ʈ�� ������ ��ũ��Ʈ�Դϴ�.
    //�ƹ� ���ӿ�����Ʈ�� ������ ��, �� ��ũ��Ʈ�� ��������ֽð�
    //����Ƽ ���� �� ���콺 ��Ŭ���� �Է��غ�����.


    public Monster My_Status = new Monster(200, 100, 10, 10, "���");
    public Player My_Player = new Player(3000, 100, 250, 5, "��Ŀ");

    public List<Monster> Monster_List = new List<Monster>();

    void Start()
    {
        Monster_List.Add(new Monster(500, 200, 10, 15, "��"));
        Monster_List.Add(new Monster(1500, 300, 10, 15, "�����"));
        Monster_List.Add(new Monster(3500, 400, 10, 15, "����"));
        Monster_List.Add(new Monster(5500, 500, 10, 15, "¯����"));
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Monster_List.Count > 0 && My_Player != null)
            {  //����Ʈ�� ���̰� 1 �̻��̰� �÷��̾� ��ü�� ������� ���� ���¶��

                print("�÷��̾ ���� �����Ͽ� " + My_Player.ATK + " ��ŭ�� ���ظ� �������ϴ�.");
                Monster_List[0].HP -= My_Player.ATK;
                //0�� ��ü�� HP�� �÷��̾��� ATK��ŭ �����ϰڴ�.

                print("���� �÷��̾ �����Ͽ� " + Monster_List[0].ATK + "��ŭ�� ���ظ� �������ϴ�.");
                My_Player.HP -= Monster_List[0].ATK;

                print("�÷��̾� �ܿ�ü�� = " + My_Player.HP + " / " + 
                      Monster_List[0].Name + " �ܿ�ü�� = " + Monster_List[0].HP);

                if(My_Player.HP <= 0)
                {
                    print("�÷��̾ ����Ͽ����ϴ�.");
                    My_Player = null;
                }
                if(Monster_List[0].HP <= 0)
                {
                    print(Monster_List[0].Name + "(��) ����Ǿ����ϴ�.");
                    Monster_List.RemoveAt(0);
                }               
            }
            if (Monster_List.Count == 0)
            {
                print("��� ���Ͱ� ����Ǿ����ϴ�.");
            }
        }
    }
}
