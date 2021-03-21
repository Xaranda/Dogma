using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grupo : MonoBehaviour
{
    [SerializeField] List<Enemigos> grupo;

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
