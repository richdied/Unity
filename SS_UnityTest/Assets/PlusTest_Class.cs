using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusTest_Class
{
    //��ȭ���� �Ϲ� Ŭ���� ��ũ��Ʈ.

    //�ش� ��ũ��Ʈ�� ������Ʈ�� �������� �ʰ�
    //Project ���� Asset �������� �߰��ϵ��� �ϰڽ��ϴ�.
}

[System.Serializable]
public class Monster
{
    public int HP;
    public int MP;
    public int ATK;
    public float Speed;
    public string Name;


    public Monster(int HP, int MP, int ATK , float Speed, string Name )
    {
        this.HP = HP;
        this.MP = MP;
        this.ATK = ATK;
        this.Speed = Speed;
        this.Name = Name;
    }

    public void Print_Status()
    {
        Debug.Log("HP = " + HP);
        Debug.Log("MP = " + MP);
        Debug.Log("Speed = " + Speed);
        Debug.Log("Name = " + Name);
    }
}

[System.Serializable]
public class Player
{
    public int HP;
    public int MP;
    public int ATK;
    public float Speed;
    public string Name;



    public Player(int HP, int MP, int ATK, float Speed, string Name)
    {
        this.HP = HP;
        this.MP = MP;
        this.ATK = ATK;
        this.Speed = Speed;
        this.Name = Name;
    }

    public void Print_Status()
    {
        Debug.Log("HP = " + HP);
        Debug.Log("MP = " + MP);
        Debug.Log("Speed = " + Speed);
        Debug.Log("Name = " + Name);
    }
}
