using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_List : MonoBehaviour
{
    //2021. 08. 22

    //C# ����Ʈ [List]

    //�� ����Ʈ�� ������ �迭�� ũ�� �ٸ� �� ������,
    // ����Ʈ�� ���, �迭ó�� �迭�� ���̿� ������ ���� �ʰ�,
    // �ʿ��Ҷ� ��Ҹ� �����Ӱ� �����ϰ�, �߰��ϴ� ����
    // �����ϴ�.

    // ��Ȳ�� ���� ��Ҹ� �߰��ؾ��ϰų�, �����ؾ� �ϴ�
    // ���� �� ��Ұ� ���� �� ��� �������ϰ� Ȱ�� �� �� �ִ�.

    //Array[�迭] : �ִ� ������ �������ִ� ��ü�� ������ ��,
    //ex ) �÷��̾� �κ��丮, �� ���� �Ǵ� ������[���� ���� ����].

    //List[����Ʈ]: �ǽð����� ��ü�� ���ϴ� ��ü���� ������ ��.
    //ex ) Player HP, ���� ��ü, �ʵ� �� ���������.

    //�� List ���� �⺻����.
    List<int> Int_List = new List<int>();
    //[1] int�� List���� Int_List�� �����ϰ�,
    //[2] List<int>�� ������ ������ �Ҵ����ְڴ�.
    //[3] Int_List��� ������ ����� �غ� ��.


    //�� Ŀ���� Ŭ���� ���ϰ�ü �����ϱ�.
    public Player P_1 = new Player(50, 10, 5, "ȫ�浿");

    //�� Ŀ���� Ŭ����Ÿ�� List �����ϰ�, ��ü �����.
    public List<Player> Player_List = new List<Player>();

    void Start()
    {
        //[ List �Ļ� ��ɾ� ]

        //[ 1.List.Add() ]
        //  �� ����Ʈ ��� �߰� ��ɾ�.
        //  �� ���ϴ� ���� ����Ʈ�� �� ���� ��ҷ� �߰��Ѵ�.

        Int_List.Add(25); //0�� ��� [ ù��° ���]
        Int_List.Add(50); //1�� ��� [ �ι�° ���]
        Int_List.Add(75);
        Int_List.Add(100);
        Int_List.Add(125);
        Int_List.Add(150);
        Int_List.Add(175);
        Int_List.Add(200);
        Int_List.Add(225);
        Int_List.Add(250);

        Print_List("List_Add ȣ�� �� �迭��");


        //[ 2. List.Remove() ]
        //  �� �Է��� ���� ���� ��Ҹ� 1�� ������ �� �ִ� ��ɾ�.

        //������: �迭��ҳ��� �Է��� ���� ���� ��Ұ� 2�� �̻� �ִٸ�, 
        //       0�� ��ҿ��� ���� ����� ��� 1���� �����Ѵ�.

        Int_List.Remove(50);
        // �� �迭��� ������ 50�� ���� ���� ��Ұ� �ִٸ�,
        //    0�� ��ҿ��� ���� ����� 50�� ���� ���� ��� 1���� �����ϰڴ�.

        Print_List("List_Remove ȣ�� �� �迭��");

        //[ 3. List.RemoveAt() ] 
        //  �� List����� �迭 ��ȣ�� �����ؼ� �����ϴ� ��ɾ�.

        Int_List.RemoveAt(3);
        // �� �迭 ����� 3�� ��Ҹ� �����ϰڴ�. // 125 ����

        //[����1]
        //RemoveAt �Լ��� ����Ͽ� List ���̿� �������
        //������ ������ ��Ҹ� ������ �� �ֵ��� �ڵ带 �ۼ��Ͻÿ�.
        //��, ������ ����Ͽ� �����ϴ°��� ����.
        if (Int_List.Count >= 1)
        {
            Int_List.RemoveAt(Int_List.Count - 1); // 250 ����
            // �� �迭�� ������ ��ҿ� �����Ͽ� �����ϱ�.
            Print_List("List_RemoveAt ȣ�� �� �迭��");

            // [ 4. List.Clear() ]
            //   �� List�� ���ο�Ҹ� ��� ���������ڴ�.
            //   �� ���� �� List ���̴� 0���� �Ҵ�.
            Int_List.Clear();
            Print_List("List_Clear ȣ�� �� �迭��");


            //[ 5. Ŭ���� Ÿ�� ��ü�� �����ڸ� ȣ���Ͽ� ����Ʈ�� �߰��ϴ� ��� ]
            Player_List.Add(new Player(300, 50, 5, "���"));
            Player_List.Add(new Player(200, 100, 7, "������"));

            Player_List[0].Set_Status();
            Player_List[1].Set_Status();
        }
    }

    void Print_List(string Str)
    {
        print(Str);

        print("Int_List�� �� ���� : " + Int_List.Count);

        for (int A = 0; A < Int_List.Count; A++)
        {
            print("Int_List��" + (A + 1) + "��° ��� :" + Int_List[A]);
        }
    }
}
