using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Manager : MonoBehaviour
{
    //배경 스프라이트를 움직이게 해줄 제어스크립트.


    public List<SpriteRenderer> Ground_List = new List<SpriteRenderer>();
    //자식 오브젝트로 들어가있는 각 배경 객체들의
    //SpriteRenderer 컴포넌트를 가져올 리스트.

    public float Scroll_Speed;
    //ㄴ 배경스크롤 속도

    void Start()
    {
        //Ground_List에 자신의 자식 객체인 Top,Middle,Bottom에 접근하여
        //해당 객체가 가지고있는 SpriteRenderer 컴포넌트를 가져오겠다.

        for(int A = 0; A < transform.childCount; A++)
        {//ㄴ BG_Manager의 자식의 수만큼 반복하겠다.

            Ground_List.Add(transform.GetChild(A).GetComponent<SpriteRenderer>());
            //ㄴ 내 'A'번째 자식이 가지고있는 SpriteRenderer 컴포넌트를 가져와서
            //   List 요소로 추가해줄께.

        }
    }


    void Update()
    {
        for(int A = 0; A < Ground_List.Count; A++)
        {
            Vector2 Offset = new Vector2(Ground_List[A].material.mainTextureOffset.x,
               Ground_List[A].material.mainTextureOffset.y + (Scroll_Speed / (A+1)) * Time.deltaTime);
            //A = 0 ~ 2, 스크롤속도가 10이라고 가정할 시에.

            //A값이 0일 경우 스크롤속도[TOP] = 10
            //A값이 1일 경우 스크롤속도[Middle] = 5
            //A값이 2일 경우 스크롤속도[Bottom] = 3.333

            Ground_List[A].material.mainTextureOffset = Offset;
        }
                
    }
}
