using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public Animator animator;
    public Enemigos enemy { get; set; }

    public void Setup(Enemigos enemigo)
    {
        enemy = enemigo;
        enemy.Base.anim = GetComponent<Animator>();
    }
    public float attackFreq; // creo variable para frecuencia de ataque
    public int attackProb; // creo variable para probabilidad de ataque
    public string[] ataque; // creo un array string para determinar el nombre de los 
    //ataques de las animaciones
    int i=1; // creo un contador para obligar a atacar en caso de que la casualidad determine
    // que el enemigo nunca ataca mediante el random range.

   public IEnumerator Start ()
    {
        while (BattleSystem.state.ToString() == "Action")// creo una iteración en funcion del estado
        {
            yield return new WaitForSeconds(attackFreq); // añado un contador
            bool attack = Random.Range(0, 100) < attackProb;//evalúo si hay ataque o no en función
            //de la probabilidad establecida
            if (i > 3)//compruebo que no se hayan atacado mas de un numero de veces 
            {
                attack = true; //si se ha atacado un numero de veces fuerzo el ataque
                i = 1; //reseteo el contador
            }
            if (attack)//si se produce el ataque
            {
                BattleSystem.singleton.StartEnemyAnimation//llamamos a la funcion del script
                    //BattleManager que activa animación y efectos del ataque
                    (ataque[Random.Range(0, ataque.Length)]);//damos el nombre de las animaciones
                //de ataque respectivas y ejecutamos un random para ver que ataque lanzará
                attack = false;//reseteamos el valor de attack
            }else if(!attack){//si no hay ataque
                i++;//subimos el contador
            }
            
        }
    }
}
