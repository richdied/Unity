using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Transform : MonoBehaviour
{
    //2021. 08. 29

    //��ü�� ��ǥ�� ����ϴ� ������Ʈ [ Transform ]

    //[Transform] ������Ʈ�� ��ü��
    //[1] ��ġ���� ( 2����, 3����)
    //[2] ȸ���� ( 2����, 3���� )
    //[3] ũ�� ( 2����, 3���� )

    //�� �� ������ �����ϸ�, ���� ���ۿ� ���� �߿��� ������ ����Ѵ�.
    //�� ��ũ��Ʈ������ [ Transform] ������Ʈ�� ��ũ��Ʈ ���ο���
    //�����ϴ� ����� ���� �����ϰ� �˾ƺ��ڴ�.

    // ������Ʈ [ Component(���, ��ǰ) ] ��?
    // -> �� ���� ������Ʈ�� ������ �ִ� ���.

    //[2] ��ǥ�� ǥ���ϴ� Ű���� [ Vector2 / Vector3 ]

    //[Vector2] => 2���� ��ǥ�踦 ���. ( x��(����) , y��(����) )
    //[Vector3] => 3���� ��ǥ�踦 ���. ( x�� , y�� , z��(�յ�) )

    //�� VectorŸ���� Ȱ���� �� �ִ� ���.
    // 1. ������Ʈ�� ��ǥ�� �����ϴ� ���.
    // 2. ������Ʈ�� �ٶ󺸴� ������ ������ǥ�� �޾ƿ��� ���.
    // 3. ������Ʈ���� �Ÿ��� ���ϰ��� �� ��.

    //[2-1] Vector ���� �Ļ� Ű���� 

    //Vector�� ���� �Ļ� Ű����� �ַ� ��ǥ�� �����ϱ� ���� ����ϱ⺸��,
    //��ü�� ��ɾ�� ������ ��, ������ ������ �������ֱ� ���� ����Ѵ�.

    // Vector3.zero = (0,0,0)

    //[����(x��)����]
    // Vector3.left = (-1,0,0)
    // Vector3.right = (1,0,0)

    //[����(y��)����]
    // Vector3.up = (0,1,0)
    // Vector3.down = (0,-1,0)

    //[�յ�(z��)����]
    // Vector3.foward = (0,0,1)
    // Vector3.back = (0,0,-1)

    //[2-2] ����� ���� ��ǥ�� �Ҵ��ϴ� [ new Vector]

    // �� �̹� ���ǵǾ� �ִ� �Ļ� ��ɾ �ƴ�
    //    ����ڰ� ���ϴ� ��ǥ���� �Ҵ��ϰ��� �� �� ����ϴ� Ű�����
    //    [ new Vector(float,float) ] ���¸� ������ �ִ�.


    public int Speed; //�÷��̾��� �̵� �ӵ�.
    public float Set_Time; //��Ÿ�� ����.



    void Start() //��ü�� ������ �� ����1�� ����Ǵ� �Լ�.
    {
        //[3] Transform Ű���� �Ļ� ��ɾ� [ position ] 
        // �� ������ ��ü�� '��ǥ'�� �Է¹��� ������ �����Ѵ�.

        //transform.position = Vector2.zero;
        //�� ��ü�� position(��ǥ)�� (0,0)���� �Ҵ��ϰڴ�.

        //transform.position = new Vector2(1, 2);
        //�� ��ü�� ��ǥ�� (1, 2)���� �Ҵ��ϰڴ�.

        //[4] Transform ȸ���� ���� ��ɾ� [ Rotate() , rotation ] 

        //transform.Rotate(new Vector3(0, 0, 45));
        //Rotate(Vector3)
        // �� �Է��� x,y,zȸ������ ������Ʈ�� ���� ȸ������ �����ְڴ�. 

        //transform.rotation = Quaternion.Euler(0,0,45);
        //Quaternion.Euler(float,float,float)
        // �� �Է��� x,y,zȸ������ ������Ʈ�� �Ҵ����ְڴ�.

        //transform.eulerAngles = new Vector3(0, 0, 45);
        //eulerAngles
        // �� �Ҵ���� ��ǥ���� ȸ�������� �ٲ� ������Ʈ���� �Ҵ����ְڴ�.


        //[5] ��ü�� ũ��[Scale]�� ��ũ��Ʈ���� �����ϴ� ���.
        //transform.localScale = new Vector3(3, 3, 1);
        //transform.localScale = Vector
        // �� �Է��� x,y,z ���Ͱ��� ������Ʈ�� Scale�� �Ҵ����ְڴ�.
    }

    void Update() // 1������ �� �ѹ��� ȣ���ϴ� �Լ� ( 1������ = ��� 0.014�� )
    {
        //[6]�Է¹��� ���� ����� �ӵ��� ��ü�� �̵���Ű�� ��ɾ�
        // �� [ Translate( ����, �ӵ�) ] 

        //transform.Translate(Vector2.left * Speed * Time.deltaTime);

        //[6-1] Time.deltaTime Ű����
        // �� 1�������� �����µ� �ҿ�� �ð��� floatŸ������ ��ȯ�ϴ� Ű����.
        //    �̸� Ȱ���Ͽ� ������ ���� Ÿ�̸Ӹ� ������ ���� �ִ�.

        Set_Time += Time.deltaTime;

        //[6-2] Ű �Է��� ���� ���� ��ü ������ Ȱ��ȭ�ϱ� [ GetKey ]

        //1. GetKeyDown()
        // �� ������ Ű�� ���������� �ѹ��� ȣ��
        //2. GetKey()
        // �� ������ Ű�� ������ �ִ� ���� ����ؼ� ȣ��.
        //3. GetKeyUp()
        // �� ������ Ű���� ���� ���� �ѹ��� ȣ��.

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            print("���� ȭ��ǥ�� ���Ƚ��ϴ� [Down]");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
            print("���� ȭ��ǥ�� ������ �ֽ��ϴ�. [Stay]");
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            print("���� ȭ��ǥ �Է��� �������ϴ� [Up]");
        }

        //���� �÷��̾ ���� Ű�Է¹ۿ� ���� ���ϴ� �����̴�.
        //�� �ڵ带 Ȱ���Ͽ� ������,���� �Ʒ��� Ű�Է��� �ް� 
        //�´� �������� ������ �� �ֵ��� �ڵ带 �ۼ��غ���.

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
         
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * Speed * Time.deltaTime);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * Speed * Time.deltaTime);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
        }

    }
}
