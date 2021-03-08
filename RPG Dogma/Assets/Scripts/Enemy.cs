using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackFreq;
    public int attackProb;
    public string[] ataque;

   IEnumerator Start ()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackFreq);
            bool attack = Random.Range(0, 100) > attackProb;
            if (attack)
                BattleManager.singleton.StartEnemyAnimation
                    (ataque[Random.Range(0, ataque.Length)]);
        }
    }
}
