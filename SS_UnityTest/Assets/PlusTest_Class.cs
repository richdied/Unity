using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusTest_Class
{
    //심화문제 일반 클래스 스크립트.

    //해당 스크립트는 오브젝트에 적용하지 않고
    //Project 탭의 Asset 폴더에만 추가하도록 하겠습니다.
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
