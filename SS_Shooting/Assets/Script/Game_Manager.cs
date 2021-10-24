using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Manager : MonoBehaviour
{   //�� ���� ������ ��ҵ��� �����ϰ� �Ѱ��� ��ũ��Ʈ.
    //   [�ʵ� ���� �� ��ü������ �����ϰ�, �� ��ü�� ������ ����]

    [Header("�÷��̾� �߰�����")]
    public int Score; //���� ȹ������.
    public TextMeshProUGUI Score_TMPRO; //���� UI
    public int Enemy_S_Score = 10; //�� ������ ������ �ο�����
    public int Enemy_M_Score = 15;
    public int Enemy_L_Score = 20;
    public int Enemy_Boss_Score = 200;

    [Header("�� ���� ����Ʈ")]
    public float Offset_X_Min;  //���� ������ X��ǥ �ּҰ�.
    public float Offset_X_Max;  //���� ������ X��ǥ �ִ밪.
    public float Offset_Y;      //���� ������ ���� Y��ǥ.

    [Header("�� ��ü ������")]
    public List<GameObject> Enemy_Prefab = new List<GameObject>();
    // ��> ��� �Ϲ� �� ��ü�� �������� �޾Ƴ��� ����Ʈ.
    public List<GameObject> Boss_Prefab = new List<GameObject>();
    // ��> ��� ���� ��ü�� �������� �޾Ƴ��� ����Ʈ.

    [Header("�ʵ忡 ������ �� ��ü����")]
    public List<GameObject> Enemy_List = new List<GameObject>();
    // ��>���� ������ ��� �� ��ü������ �޾Ƴ��� ����Ʈ.

    [Header("�������� �Ӽ�")]
    public int Limit_Enemy;
    // ��>�����Űâ�� ���ÿ� ������ �� �ִ� �� ��ü�� �ִ� ����.

    public float Rand_Spawn_Time_Min;  //�� ���������� �ּҰ�.
    public float Rand_Spawn_Time_Max;  //�� ���������� �ִ밪.
    public bool Is_Spawn;
    // �� ���� �����ǰ���, ��Ÿ���� ���� �����ΰ�?
    // ��> true => ���� ��Ÿ���� ������ �ʴ� ����.
    // ��> false => ���� �����ϰ�, ��Ÿ���� ���� ����. [���� �ٽ� ������ �غ� OK]

    public int Stage_LV; //���� �������� ����
    public bool Is_Boss_Spawn; //������ ���� ������ �����ΰ�?
    public int Boss_Count;  //�̹����������� ������ �����Ǳ���� �ʿ��� �� óġ ��



    void Start()
    {
        Start_Set();
        Get_Score(0);
    }

    
    void Update()
    {
        if (!Is_Boss_Spawn)
        {// �� ������ �ʵ忡 �������� ���� ��쿡��, �Ϲ� �� ��ü�� �����ϰڴ�.
            Enemy_Spawn();
        }
    }

    public void Get_Score(int Score)
    {
        this.Score += Score;
        // �� �޾ƿ� �Ķ���͸� ���� ���ھ �������ְڴ�.
        Score_TMPRO.text = "SCORE : " + this.Score.ToString();
        // �� Text UI�� ���� ���� String(���ڿ�) ��ȯ�Ͽ� �Ҵ����ְڴ�.
    }

    void Enemy_Spawn()
    {// �� ������ ������ �� , �� ��ü�� �������� ������ �Լ�.

        if (Enemy_List.Count < Limit_Enemy && !Is_Spawn)
        {// �� ���� ������ �� ���� Limit_Enemy �̸��̰�, ������Ÿ���� ���� ������ ���.

            Is_Spawn = true;
            //�� ���� �������� ���·� ��� ��ȯ�ϰ�
            int Rand_Count = Random.Range(0, Enemy_Prefab.Count);
            //�� 0���� ��� �Ϲ� �� ���� ���� ������, �������� �̰ڴ�.
            Vector2 Pos = new Vector2(Random.Range(Offset_X_Min, Offset_X_Max), Offset_Y);
            //�� X��ǥ�� �������� �̾� �Ҵ����ְ�, Y��ǥ�� ������ offset_Y �������� �Ҵ�.
            Enemy_List.Add(Instantiate(Enemy_Prefab[Rand_Count], Pos, Quaternion.identity));
            //�� ������ �� ������ ��ü�� ���� ��ǥ���� ������ ����, Enemy_List�� �߰��ϰڴ�.
            Invoke("Spawn_Set", Random.Range(Rand_Spawn_Time_Min, Rand_Spawn_Time_Max));
            //�� ���� ��������ŭ ����� ��, �� ������ ������ ���·� ��ȯ�ϰڴ�.
        }
    }

    public void Dead_Enemy(GameObject OBJ, bool Hit_Daed)
    {//�� ��ü�� ����ϴ� ������ Enemy_CT ���ο��� ������ �Լ�.
     // Hit_Dead = [�÷��̾�� �¾� �׾��� ��� true / �ƴ� ��� false]

        Enemy_List.Remove(OBJ);
        //�� �Ķ���ͷ� �޾ƿ� OBJ ��ü�� ������ ������Ʈ�� Enemy_List�� �ִٸ�, �����ϰڴ�.
        if(Hit_Daed) { 
            
            Boss_Count--;

            Enemy_CT EC = OBJ.GetComponent<Enemy_CT>();
            //�Ķ���ͷ� �޾ƿ� �� ��ü�� ���� ��ũ��Ʈ ������ �޾ƿ��ڴ�.

            if(EC.type == Enemy_Type.Enemy_S) { Get_Score(Enemy_S_Score); }
            else if (EC.type == Enemy_Type.Enemy_M) { Get_Score(Enemy_M_Score); }
            else if (EC.type == Enemy_Type.Enemy_L) { Get_Score(Enemy_L_Score); }
            // �� �ش� ���� Ÿ�Կ� �´� ������ ���� ���ھ ���������ְڴ�.
        }
        //�� ����, �÷��̾�� �¾Ƽ� �׾��ٸ�, Boss_Count�� 1 ���ҽ�Ű�ڴ�.
        Boss_Spawn();
        //�� Boss_Spawn �Լ� ��������.

    }

    void Boss_Spawn()
    {// �� ���� ����Ҷ����� ���� ���� ������ �����ϴ��� üũ�ϱ� ���� �Լ�.

        if(Boss_Count <= 0 && !Is_Boss_Spawn)
        {//������ ��ȯ�ϱ� ���� �ʿ��� �� ó�� ���� 0�����̰�,
         //���ÿ� �ʵ� ���� ������ ��ȯ�Ǿ����� �ʴ� ������ ���.

            Is_Boss_Spawn = true;
            //�� [1] ������ ��ȯ�� ���·� ��� ��ȯ�ϰ�,

            for(int A = 0; A < Enemy_List.Count; A++)
            {// �� ���� ������ ���� ����ŭ �ݸ��� ������
                Destroy(Enemy_List[A]);
                // �� ��� �Ϲ� �� ��ü�� �ı��� ��,
            }
            Enemy_List.Clear();
            // �� [2] Enemy_List�� ������ ����ְڴ� [����Ʈ ���̸� 0���� �Ҵ�]

            int Rand_Count = Random.Range(0, Boss_Prefab.Count);
            // �� [3] ������ ���� �� �Ѱ����� �������� �̰ڴ�.

            Instantiate(Boss_Prefab[Rand_Count], new Vector2(0, Offset_Y), Quaternion.identity);
            // �� [4] �����ϰ� ���� ���� �������� �ν��Ͻ�ȭ[����] �ϰڴ�.
        }
    }
        

    void Spawn_Set()
    {// �� ����Ǵ� ���� �� ������ ������ ���·� ��� ��ȯ�ϴ� �Լ�
        Is_Spawn = false;
    }
    void Start_Set()
    {// �� ���۰� ���ÿ� ��� ���� �Ҵ��� �Լ�.

        Stage_LV = 1;
        Limit_Enemy = 5;
        Boss_Count = 15;
        Is_Boss_Spawn = false;
        Is_Spawn = false;
    }
}
