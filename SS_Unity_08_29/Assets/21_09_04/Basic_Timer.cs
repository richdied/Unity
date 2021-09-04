using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Basic_Timer : MonoBehaviour
{
    public TextMeshProUGUI S;
    public TextMeshProUGUI M;
    public TextMeshProUGUI H;


    [Header("�ð�����")]
    public float Time_H;  //�ð�����
    public float Time_M;  //�д���
    public float Time_S;  //�ʴ���
                         
    public float Clock_Speed; //�ð� �ӵ�

    //[1] �ش� �������� Ȱ���Ͽ� �ν����� ������ 
    // Ÿ�̸Ӹ� �����غ���

    //[2] ���Ǵ� Ű����: Time.deltaTime

    //������: Tims_S�� 60�� �Ѿ�� �ȵȴ�.

    //1M = 60S

  

    void Start()
    {
        
    }


    void Update()
    {
        if(Time_S < 60.0f) //�� ������ 60 �̸��� ���
        {
            Time_S += Time.deltaTime + (Clock_Speed * 0.01f);
            //����ؼ� �ð����� �������ְڴ�.
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
