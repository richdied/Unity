using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Basic : MonoBehaviour
{
    // 2021.08.14

    //[1] Random [������ �����]

    // �� C#���� �������� �����ϱ� ���� ����ϴ� Ű�����,
    // �Ļ� ��ɾ� Range()�Լ��� �̿��� ���ϴ� ������
    // �������� �����Ͽ� ������ ���� �޾ƿ� �� �ִ�. 

    // ���콺 ��Ŭ�� �� �������� �̾� �ű⿡ �´� �������� 
    // ȹ���ϴ� ������ �ڵ� �ۼ�. 

    [Header("ȹ�泻��")]
    public int Get_S;
    public int Get_A;
    public int Get_B;
    public int Get_C;
    public int Get_G;

    [Header("���ݾ� �� �̱� Ƚ��")]
    public int Use_Money; //�� �Һ� ���
    public int Total_Amount;//�� �̱� Ƚ��
    public int Price; //1ȸ �̱� ��� [ ȸ�� 2500�� ]

    void Start()
    {
        print(Random.Range(0,101));
        // 0 ~ 100���� ���� �� �������� �̱�.
    }


    void Update()
    {

            if (Input.GetMouseButtonDown(0))
            {// ���� ���콺 ��ư�� ���������� �ѹ��� ȣ��.
            for (int A = 0; A <= 100; A++)
            {
                Total_Amount++; // �� �̱� ��� ����
                Use_Money += Price; // �Һ��� 1ȸġ ��ŭ ����

                int Rand = Random.Range(1, 100001);
                //1���� 100���� �� �������� �̰ڴ�.
                //�׸��� ���� ���� Rand ������ �Ҵ����ְڴ�.

                if (Rand > 0 && Rand <= 32)
                {//Rand�� 0 �ʰ� 3 ���ϸ� = (1,2,3) = 0.003%
                    print("< S��� ������ ȹ�� >");
                    Get_S++;
                }
                else if (Rand > 3 && Rand <= 50)
                {// Rand�� 3 �ʰ� 10 ���ϸ� = (4~10) = 7%
                    print("< A��� ������ ȹ�� >");
                    Get_A++;
                }
                else if (Rand > 50 && Rand <= 100)
                {// Rand�� 3 �ʰ� 10 ���ϸ� = (11~50) = 40%
                    print("< B��� ������ ȹ�� >");
                    Get_B++;
                }
                else if (Rand > 100 && Rand <= 300)
                {// Rand�� 3 �ʰ� 10 ���ϸ� = (51~80) = 30%
                    print("< C��� ������ ȹ�� >");
                    Get_C++;
                }
                else //�� ������ �ƴ� ��� ���
                {
                    print("�⵿��� ȹ��");
                    Get_G++;
                }
            }

        }
    }
}
