using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grupo : MonoBehaviour
{
    [SerializeField] public List<Enemigos> grupo;

    public List<Enemigos> enemigos
    {
      get
      {
        return grupo;
      }
      set
      {
        //grupo = value;
      }
    }

    private void Start ()
    {
        foreach (var enemigos in grupo)
        {
            enemigos.Init();
        }
    }

    public Enemigos GetSaeraHealth()
    {
        return grupo.Where(x => x.HP > 0).FirstOrDefault();
    }
}
