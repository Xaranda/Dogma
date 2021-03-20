using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos
{
    public EnemigoBase Base { get; set; }
    public int Level { get; set; }

    public int HP { get; set; }

    public Enemigos(EnemigoBase pBase, int pLevel)
    {
        Base = pBase;
        Level = pLevel;
        HP = MaxHp;

    }

    public int Attack
    {
        get { return Mathf.FloorToInt((Base.Attack * Level) / 8f) + 5; }
    }
    public int Defense
    {
        get { return Mathf.FloorToInt((Base.Defense * Level) / 8f) + 5; }
    }
    public int SpAttack
    {
        get { return Mathf.FloorToInt((Base.SpAttack * Level) / 7f) + 5; }

    }
    public int SpDefense
    {
        get { return Mathf.FloorToInt((Base.SpDefense * Level) / 7f) + 5; }
    }
    public int Speed
    {
        get { return Mathf.FloorToInt((Base.Speed * Level) / 25f) + 5; }
    }
    public int MaxHp
    {
        get { return Mathf.FloorToInt((Base.MaxHp * Level)/10f) + 10; }
    }

    public bool Damage (Enemigos attacker)
    {
        float critical = 1f;
        if (Random.value * 100f < 6.25f)
        {
            critical = 2f;
        }
        float modifiers = Random.Range(0.9f, 1.05f) * critical;
        float a = (2 * attacker.Level + 10) / 250f;
        float b = a * ((float)attacker.Attack / Defense) + 1;
        int damage = Mathf.FloorToInt(b * modifiers);

        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            return true;
        }
        return false;
    }
}
