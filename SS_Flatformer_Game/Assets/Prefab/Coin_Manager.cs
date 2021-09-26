using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Manager : MonoBehaviour
{
  //게임 오브젝트의 부모를 변경하는 방법.
    void Start()
    {
        gameObject.transform.parent = GameObject.Find("Coin_Manager").GetComponent<Transform>();

        //[1] gameObject.transform.parent
        // ㄴ> 이 스크립트를 가진 게임오브젝트의 부모를 변경하겠다. [ 할당<Transform> ]

        //[2] GameObject.Find("Coin_Manager").GetComponent<Transform>()
        // ㄴ> 모든 게임오브젝트 중에 "Coin_Manager"라는 이름을 가진 객체를 찾아서,
        //     해당 GameObject의 <Transform> 컴포넌트를 받아오겠다.

    }
}
