using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CT : MonoBehaviour
{
    //�÷��̾��� �����Ӱ�, �÷��̾� �Է��� ó���ϴ� ��ũ��Ʈ.

    [Header("�÷��̾� ����")]
    public float Speed;         //�÷��̾��� �ӵ�

    public float Shooting_Cool; //�÷��̾��� ����ӵ�
    public bool Is_Shooting;    //�Ѿ��� �߻��ϰ�, ��Ÿ���� ��ٸ��� ���ΰ�?

    [Header("������")]
    public GameObject Bullet_Type_1; //�÷��̾��� ù��° �Ѿ� ������ ����.

    [Header("��ü ������Ʈ")]
    public Animator My_Anim;        //��ü �ڽ��� �ִϸ��̼� ������Ʈ.
    public Rigidbody2D My_Rigid;    //��ü �ڽ��� ��ü ������Ʈ.

    void Start()
    {
        Component_Get();
    }

    void Update()
    {
        Move_State();
    }

    void Component_Get()
    {   //���۰� ���ÿ� �ʿ��� ������Ʈ���� �Ҵ�޴� �Լ�.

        My_Anim = GetComponent<Animator>(); //�ڱ� �ڽ��� Animator �Ҵ�.
        My_Rigid = GetComponent<Rigidbody2D>(); //�ڱ� �ڽ��� ��ü �Ҵ�.
    }

    void Move_State()
    {   //Ű �Է¿� ���� ��/��/��/�� �̵� �Լ�.

        float Offset_X = Input.GetAxisRaw("Horizontal"); //��,�� Ű�Է�.
        float Offset_Y = Input.GetAxisRaw("Vertical");   //��,�� Ű�Է�.

        My_Rigid.velocity = new Vector2(Offset_X * Speed, Offset_Y * Speed);
        //�̵�ó�� �ڵ�.

        My_Anim.SetInteger("Is_Move", (int)Offset_X);
        //�ִϸ��̼� ó�� �ڵ�.

        if(Input.GetKey(KeyCode.Z) && !Is_Shooting)
        {   //���� �ڵ�.

            Is_Shooting = true;  //��Ÿ�� ���·� ��ȯ

            Invoke("CoolTime_Set", Shooting_Cool);
            //Invoke(Function_Name, float)
            // ��> �� ��ũ��Ʈ �������� �����Ͽ�, �Էµ� ���ڿ��� ���� �̸��� �Լ��� ã��
            //     �����ϰڴ�. ��, �Է¹��� float(�Ǽ�)����ŭ ����� �Ŀ�.

            Instantiate(Bullet_Type_1, transform.position, Quaternion.identity);
            //Instantiate(GameObject, Vector, Quaternion)
            // ��> �Ķ���ͷ� ���޹��� GameObject ��ü�� 
            //     �Է¹��� Vector(��ǥ)�� Quaternion(ȸ����)�� �°�
            //     ���� �����ϴ� ��ɾ�.
        }
    }

    void CoolTime_Set()
    {
        Is_Shooting = false;
    }
}
