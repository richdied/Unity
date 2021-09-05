using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_Transform : MonoBehaviour
{
    //2021. 09 . 04

    //Transform ���� ��ũ��Ʈ.

    //[1] ��ü�� ��ǥ�� ����ϴ� ������Ʈ [ Transform ]

    //Transform ������Ʈ�� ����ϴ� ��ü�� ����
    //1. ��ġ����(Position) [ 2���� , 3���� ]
    //2. ȸ����(Rotation)   [ 2���� , 3���� ]
    //3. ũ��(Scail)        [ 2���� , 3���� ]


    //[2] ��ǥ�� ǥ���ϴ� �ڷ��� [ Vector2 / Vector3 ]

    //[Vector2] => 2���� ��ǥ�踦 ���. [ x,y ]
    //[Vector3] => 3���� ��ǥ�踦 ���. [ x,y,z ]



    //[2-1] Vector���� ������ ǥ���ϴ� �Ļ� Ű����.

    //Vector3.zero = [0,0,0]

    //[����(x��)���� Ű����]
    //Vector3.left = [-1,0,0]
    //Vector3.right = [1,0,0]

    //[����(y��)���� Ű����]
    //Vector3.up = [0,1,0]
    //Vector3.down = [0,-1,0]

    //[����(z��)���� Ű����]
    //Vector3.forward = [0,0,1]
    //Vector3.back = [0,0,-1]



    //[2-2] ����� ���� ��ǥ�� �Ҵ��ϴ� [ new Vector ]
    // �� �̹� ���ǵǾ� �ִ� �Ļ� ��ɾ �ƴ�
    //    ����ڰ� ���ϴ� ��ǥ���� �Ҵ��ϰ��� �� �� ����ϴ� Ű�����
    //    [ new Vector(float x,float y,flaot z) ] ���¸� ������ �ִ�.


    //[3-1] VectorŸ�� ������ �����Ͽ� ��ü�� ��ġ������ �Ҵ��ϱ�.
    public Vector3 My_Pos;


    [Header("�Է� �� �ð����� ����")]
    public int Count = 0;  //�÷��̾��� ���� ������ī��Ʈ

    public float Set_Time = 0;  //���� ���� �ð�.
    public float Cool_Time = 0; //�ڵ��̵� ���� ��Ÿ��.

    public bool Is_Time = true; //��Ÿ���� ���� �����ΰ�?


    void Start()
    {
        //[3] Transform ������Ʈ�� �̿��Ͽ� ��ü��ġ �ٲٱ�.
        //gameObject.transform.position = Vector3.zero; //[0,0,0]

        //gameObject.transform.position = new Vector3(0, 0, 0);

        //gameObject.transform.position = My_Pos;

        //gameObject��?
        // �� �� ��ũ��Ʈ�� �������ִ� ��ü. => 'Player'
    }

    void Update() //1������ �� 1�� ����Ǵ� �Լ�(1������ = ��� 0.014��)
    {
        //gameObject.transform.position = My_Pos;

        

        //[4]Ű �Է��� Ȱ��ȭ�ϴ� Ű���� [ Input ]

        //1. Input.GetKeyDown()
        //   �� ������ Ű�� ���������� �� ���� ȣ��.
        //2. Input.GetKey()
        //   �� ������ Ű�� �������ִ� ���� ����ؼ� ȣ��.
        //3. Input.GetKeyUp()
        //   �� ������ Ű���� ���� ���� �� ���� ȣ��.

        //4. Input.GetMouseButton()
        //   �� ������ ���콺 ��ư�� ������ ȣ��Ǵ� ��ɾ�.

        // GetMouseButton() �Ķ���� ���� [intŸ��]

        // '0' => ��Ŭ��
        // '1' => ��Ŭ��
        // '2' => ��Ŭ��

        //if(Input.GetMouseButtonDown(0))
        //{  //��Ŭ���� ������ ������ true�� ��ȯ�ϰڴ�.
        //    print("Mouse_Down");
        //}
        //if(Input.GetMouseButton(0))
        //{  //��Ŭ���� �������ִ� ���� true�� ��ȯ�ϰڴ�.
        //    print("Mouse_Stay");
        //}
        //if(Input.GetMouseButtonUp(0))
        //{  //��Ŭ�� �Է��� ������ ���� true�� ��ȯ�ϰڴ�.
        //    print("Mouse_Up");
        //}



        //transform ������Ʈ ���� Ȱ�뿹��.

        //[1] ���콺 ��Ŭ���� ���� ������ ȭ���� �� �𼭸���
        //    �ð�������� �̵��ϴ� �ڵ带 �ۼ��غ���.

        //[2] ���� �� �ڷ��� Ȱ�� : ����


        if(Set_Time >= Cool_Time && !Is_Time)
        {
            //Set_Time�� ������ Cool_Time�� ���� �Ѿ��,
            //���� ��Ÿ�� ���� bool���� '����'�� ���.

            Set_Time = 0;  //Set_Time�� �ٽ� 0���� �ʱ�ȭ�ϰ�
            Is_Time = true; //��Ÿ���� �����ٴ� ��ȣ�� �����ڴ�.
            print("Is_Time = true");
        }
        else
        {
            Set_Time += Time.deltaTime;
            //�װ� �ƴ϶��, Set_Time�� ������ �� �ð�����
            //����ؼ� �������ְڴ�.
        }


        if(Is_Time)
        {  //��Ŭ���� �Է��Ҷ����� �ش� �ڵ带 �����ϰڴ�.

            Is_Time = false;
            //�̵� �ڵ尡 ����Ǵ� ����, ��Ÿ�� ���� ��ȯ�ϰڴ�.

            if(Count == 0)
            {
                Count++;
                transform.position = new Vector3(8, 4);
            }
            else if(Count == 1)
            {
                Count++;
                transform.position = new Vector3(8, -4);
            }
            else if (Count == 2)
            {
                Count++;
                transform.position = new Vector3(-8, -4);
            }
            else if (Count == 3)
            {
                Count = 0;
                transform.position = new Vector3(-8, 4);
            }
        }
        
    }

}
