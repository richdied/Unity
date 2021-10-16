using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Manager : MonoBehaviour
{
    //��� ��������Ʈ�� �����̰� ���� ���ũ��Ʈ.


    public List<SpriteRenderer> Ground_List = new List<SpriteRenderer>();
    //�ڽ� ������Ʈ�� ���ִ� �� ��� ��ü����
    //SpriteRenderer ������Ʈ�� ������ ����Ʈ.

    public float Scroll_Speed;
    //�� ��潺ũ�� �ӵ�

    void Start()
    {
        //Ground_List�� �ڽ��� �ڽ� ��ü�� Top,Middle,Bottom�� �����Ͽ�
        //�ش� ��ü�� �������ִ� SpriteRenderer ������Ʈ�� �������ڴ�.

        for(int A = 0; A < transform.childCount; A++)
        {//�� BG_Manager�� �ڽ��� ����ŭ �ݺ��ϰڴ�.

            Ground_List.Add(transform.GetChild(A).GetComponent<SpriteRenderer>());
            //�� �� 'A'��° �ڽ��� �������ִ� SpriteRenderer ������Ʈ�� �����ͼ�
            //   List ��ҷ� �߰����ٲ�.

        }
    }


    void Update()
    {
        for(int A = 0; A < Ground_List.Count; A++)
        {
            Vector2 Offset = new Vector2(Ground_List[A].material.mainTextureOffset.x,
               Ground_List[A].material.mainTextureOffset.y + (Scroll_Speed / (A+1)) * Time.deltaTime);
            //A = 0 ~ 2, ��ũ�Ѽӵ��� 10�̶�� ������ �ÿ�.

            //A���� 0�� ��� ��ũ�Ѽӵ�[TOP] = 10
            //A���� 1�� ��� ��ũ�Ѽӵ�[Middle] = 5
            //A���� 2�� ��� ��ũ�Ѽӵ�[Bottom] = 3.333

            Ground_List[A].material.mainTextureOffset = Offset;
        }
                
    }
}
