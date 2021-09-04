using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Basic_Timer : MonoBehaviour
{
    public TextMeshProUGUI S;
    public TextMeshProUGUI M;
    public TextMeshProUGUI H;


    [Header("시간변수")]
    public float Time_H;  //시간단위
    public float Time_M;  //분단위
    public float Time_S;  //초단위
                         
    public float Clock_Speed; //시간 속도

    //[1] 해당 변수들을 활용하여 인스펙터 내에서 
    // 타이머를 구현해보자

    //[2] 사용되는 키워드: Time.deltaTime

    //주의점: Tims_S가 60을 넘어가선 안된다.

    //1M = 60S

  

    void Start()
    {
        
    }


    void Update()
    {
        if(Time_S < 60.0f) //초 단위가 60 미만일 경우
        {
            Time_S += Time.deltaTime + (Clock_Speed * 0.01f);
            //계속해서 시간값을 누적해주겠다.
        }
        else if(Time_S >= 60.0f)
        {
            Time_S = 0;
            Time_M++;
        }
        else if(Time_M >= 60.0f)
        {
            Time_M = 0;
            Time_H++;
        }
        Set_UI();
    }

    void Set_UI()
    {
        S.text = Time_S.ToString("NO");
        M.text = Time_M.ToString("NO");
        H.text = Time_H.ToString("NO");
    }

}
