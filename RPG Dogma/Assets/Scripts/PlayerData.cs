using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{
  [SerializeField] Player PlayerUnit;
  public int level;
  public int health;
  public int exp;
  public float [] position;

  public PlayerData (SaeraController pos)
  {
    level = PlayerUnit.saera.level;
    health = PlayerUnit.saera.HP;
    exp = PlayerUnit.saera.Exp;
    position = new float [3];
    position[0] = pos.transform.position.x;
    position[1] = pos.transform.position.y;
    position[2] = pos.transform.position.z;
  }
}
