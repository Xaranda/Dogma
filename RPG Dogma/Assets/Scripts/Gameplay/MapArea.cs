using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArea : MonoBehaviour
{
    [SerializeField] List<Enemigos> worldEnemies;

    public Enemigos GetRandomEnemy()
    {
        var worldEnemy =  worldEnemies[Random.Range(0, worldEnemies.Count)];
        worldEnemy.Init();
        return worldEnemy;
    }
}
