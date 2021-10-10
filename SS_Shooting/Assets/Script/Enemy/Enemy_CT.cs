using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//����ü ( enum ) ��?
// ��> ����Ƽ���� ����ü�� �� ��ü�� �����ϱ� ���� �뵵�� ���ȴ�.
//     ����Ƽ�� �±׿��� ���� ������ �ֱ� ������ �̸� �����ϱ� ���Ͽ�,
//     ����ü�� Ȱ���� ���ǹ����� ��ü�ϱ⵵ �Ѵ�.

//     ���: ������ ������ ���� �����ϴ� �±�(tag) �ý���.

public enum Enemy_Type
{
    Enemy_S,
    Enemy_M,
    Enemy_L,
    BOSS,
    O
}

[System.Serializable]
public class Enemy 
{//�� ���ʹ� ��ü�� ������ �ִ� ��� �Ӽ������� ������ Ŭ����
    [Header("�� �⺻ ����")]
    public float HP; //���� ����ü��.
    public float Max_HP; //���� �ִ�ü��.
    public float Speed; //���� �̵��ӵ�.

    public float Shooting_Cool; //���� ���� �ӵ�.
    public int Limit_Bullet; //���� ��ź��.
    public bool Shoot_Ready = true; //���� ��������.

    [Header("�� ������Ʈ")]
    public GameObject E_Bullet; //���� �Ѿ� ������.
    public Sprite E_Normal_Image; //���� ����̹���.
    public Sprite E_Hit_Image; //���� �ǰݴ��������� �̹���.

    public void Enemy_Hit(int Damage)
    {//�� �ش� ��ü�� ���ݹ����� ȣ���� �Լ�.
        HP -= Damage;
        // �� ���� ��������ŭ ü���� ���ҽ�Ű�ڴ�.
    }

}
public class Enemy_CT : MonoBehaviour
{//�� ���� �������̳�, ������ ���� �� ��ũ��Ʈ.

    public Enemy_Type type;
    //�� ���� Ÿ���� �������� enumŸ�� ����.
    
    public Enemy Info;
    //�� ���� �⺻ �Ӽ��� ������ Ŀ���� Ŭ����.

    [Header("�÷��̾� ����")]
    public GameObject Player;

    [Header("��ü ������Ʈ")]
    public SpriteRenderer My_Render;

    void Start() //��ü�� ������ ��.
    {
        Component_Get();
    }

    
    void Update()
    {
        transform.Translate(Vector2.down * Info.Speed * Time.deltaTime);
        //�� ���� �ڽ��� �ӵ��� �°� �Ʒ��� ���� ���������� ������ְڴ�.
        
        if(Info.Shoot_Ready && Info.Limit_Bullet > 0)
        {// �� �Ѿ��� ������ ���°�, �Ѿ� �ܷ��� 0���� �ʰ��� ��� [1�� �̻��� ���]
            
            if(type != Enemy_Type.BOSS)
            {// �� �� ��ü�� BOSS�� �ƴ� ���.

                Info.Shoot_Ready = false; //�������� ���·� ��ȯ�ϰ�, 

                Info.Limit_Bullet--; //��� źȯ�� 1�� ���ҽ�Ų ��,

                Shoot_Bullet();

                Invoke("Shoot_Cool",Info.Shooting_Cool);
                //�� ��Ÿ�Ӹ�ŭ ����� ��, �ش� �Լ��� �����ϰڴ�.


            }
        }

        Enemy_Dead();
    }

    public void Hit_Function(int Damage)
    {
        Info.Enemy_Hit(Damage);
        //�� �޾ƿ� ������ ��ŭ ü���� ���ҽ�Ű�ڴ�.

        StartCoroutine(Hit_Effect());
        //�� �׸���, �ǰ� �̺�Ʈ �ڷ�ƾ �Լ��� �����ϰڴ�.
    }

    IEnumerator Hit_Effect()
    {
        My_Render.sprite = Info.E_Hit_Image;
        //������ ���ݴ��ߴٸ�, Hit_Image�� ���� ��������Ʈ�� �Ҵ��� ��,
        yield return new WaitForSeconds(0.05f);
        //�� 0.05�ʰ� ����� �Ŀ�.
        My_Render.sprite = Info.E_Normal_Image;
        //�� ������ ��������Ʈ �̹����� �ٽ� �Ҵ����ְڴ�.
        StopCoroutine(Hit_Effect());
        //�� ����� ��� �ڵ带 �����ߴٸ�, �ش� �ڷ�ƾ�� �����ϰڴ�.
    }
      
    void Shoot_Bullet() //�Ѿ˹߻� �Լ�.
    {
        Vector3 Direction = (Player.transform.position - transform.position);
        //��ǥ��ǥ�� �ٶ󺸴� ����� = [��ǥ�� ��ǥ] - [���� ��ǥ]

        float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;

        //Mathf.Atan2(float y, float x)
        // ��> ������Ʈ�� �ٶ󺸴� ���Ͱ�(Direction)�� y,x���� �Է¹޾Ƽ�,
        //     2dȯ�濡�� �ش� ������Ʈ�� �ٶ� �� �ִ� z ȸ������ ���� ������
        //     ��ȯ���ִ� �Լ�.

        //Mathf.Rad2Deg
        //��> ����Ƽ���� ���������� ǥ���� �� ���� ���� ���� ������
        //    Vector ��ǥ ������ ��ȯ���ִ� ��ɾ�.

        if(type == Enemy_Type.Enemy_L)
        {
            Instantiate(Info.E_Bullet, new Vector2(transform.position.x + 0.35f, transform.position.y - 0.5f), 
                Quaternion.AngleAxis(Angle +90, Vector3.forward));

            Instantiate(Info.E_Bullet, new Vector2(transform.position.x - 0.35f, transform.position.y - 0.5f),
               Quaternion.AngleAxis(Angle + 90, Vector3.forward));
        }
        if (type == Enemy_Type.Enemy_M)
        {
            Instantiate(Info.E_Bullet, new Vector2(transform.position.x + 0.35f, transform.position.y - 0.5f),
                Quaternion.AngleAxis(Angle + 90, Vector3.forward));

            Instantiate(Info.E_Bullet, new Vector2(transform.position.x - 0.35f, transform.position.y - 0.5f),
               Quaternion.AngleAxis(Angle + 90, Vector3.forward));
        }
        if (type == Enemy_Type.Enemy_S)
        {
            Instantiate(Info.E_Bullet, new Vector2(transform.position.x + 0.35f, transform.position.y - 0.5f),
                Quaternion.AngleAxis(Angle + 90, Vector3.forward));

        }
        if (type == Enemy_Type.O)
        {
            Instantiate(Info.E_Bullet, new Vector2(transform.position.x + 0.35f, transform.position.y - 0.5f),
    Quaternion.AngleAxis(Angle + 90, Vector3.forward));

            Instantiate(Info.E_Bullet, new Vector2(transform.position.x - 0.35f, transform.position.y - 0.5f),
               Quaternion.AngleAxis(Angle + 90, Vector3.forward));
            Instantiate(Info.E_Bullet, new Vector2(transform.position.x + 0.35f, transform.position.y - 0.5f),
    Quaternion.AngleAxis(Angle + 90, Vector3.forward));

            Instantiate(Info.E_Bullet, new Vector2(transform.position.x - 0.35f, transform.position.y - 0.5f),
               Quaternion.AngleAxis(Angle + 90, Vector3.forward));
        }
        //Quaternion.AngleAxis(float Angle, Vector3 Axis)
        // ��> Axis[�߽���] �� ��������, Angle��ŭ ȸ���� ȸ������
        //     ��ȯ�޴� ��ü���� �Ҵ����ְڴ�.

    }

    void Shoot_Cool() //������ �Լ�
    {
        Info.Shoot_Ready = true;
        //�� �Լ��� �����ϸ� �������� �Ϸ�� ���·� ��ȯ�ϰڴ�. => �Ѿ˹߻� �غ� �Ϸ�.
 
    }

    void Enemy_Dead()
    {
        if(transform.position.y <= -6.0f || Info.HP <= 0)
        {//�� y��ǥ���� -6 �����̰ų�, ���� HP�� 0 ������ ���.
            StopAllCoroutines();
            //�� ��ü�� �ı��ϱ� ��, �������� ��� �ڷ�ƾ �Լ��� ������ ��, 
            Destroy(gameObject);
            //�� �ڱ� �ڽ��� �ı��ϰڴ�.
        }
    }

    void Component_Get()
    {   //�� ���۰� ���ÿ� �ʿ��� ������Ʈ�� �� ������ �Ҵ��� �Լ�.

        Info.HP = Info.Max_HP;
        // �� ���� ü�¿� �ִ� ü���� �Ҵ����ְڴ�.

        Player = GameObject.Find("Player");
        // �� �����Ű â�� ��� ��ü �� "Player"��� �̸��� ���� ��ü�� ã�� �ְڴ�.
        My_Render = GetComponent<SpriteRenderer>();
        // �� �ڱ� �ڽ��� ������ �ִ� <> ������Ʈ�� ã�� �Ҵ��ϰڴ�.
    }
}
