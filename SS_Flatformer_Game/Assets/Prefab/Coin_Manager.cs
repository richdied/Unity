using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Manager : MonoBehaviour
{
  //���� ������Ʈ�� �θ� �����ϴ� ���.
    void Start()
    {
        gameObject.transform.parent = GameObject.Find("Coin_Manager").GetComponent<Transform>();

        //[1] gameObject.transform.parent
        // ��> �� ��ũ��Ʈ�� ���� ���ӿ�����Ʈ�� �θ� �����ϰڴ�. [ �Ҵ�<Transform> ]

        //[2] GameObject.Find("Coin_Manager").GetComponent<Transform>()
        // ��> ��� ���ӿ�����Ʈ �߿� "Coin_Manager"��� �̸��� ���� ��ü�� ã�Ƽ�,
        //     �ش� GameObject�� <Transform> ������Ʈ�� �޾ƿ��ڴ�.

    }
}
