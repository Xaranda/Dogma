using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemigos", menuName = "Enemigo/Nuevo enemigo")]

public class EnemigoBase : ScriptableObject
{
    [SerializeField] string name;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] public Animator anim;
    [SerializeField] EnemyType type1;
    [SerializeField] EnemyType type2;

    //Estadisticas del enemigo
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;
    
    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }
    public Animator Anim
    {
        get { return anim; }
    }
    public EnemyType Type1
    {
        get { return type1; }
    }
    public EnemyType Type2
    {
        get { return type2; }
    }
    public int MaxHp
    {
        get { return maxHp; }
    }
    public int Attack
    {
        get { return attack; }
    }
    public int SpAttack
    {
        get { return spAttack; }
    }
    public int Defense
    {
        get { return defense; }
    }
    public int SpDefense
    {
        get { return spDefense; }
    }
    public int Speed
    {
        get { return speed; }
    }


}
public enum EnemyType
{
    None,
    Bestia,
    Deidad,
    Elemental,
    Homunculo,
    Humanoide,
    Insecto,
    Mecanizado,
    Dragon,
    Fantasma
}
