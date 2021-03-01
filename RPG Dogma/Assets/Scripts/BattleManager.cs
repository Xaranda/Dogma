using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
   public Animator animPlayer;
   public Animator animEnemy;

   public int playerHealth;
   public int enemyHealth;
   
   public bool playerDodge;
   public bool enemyDodge;
   
   public static BattleManager singleton;
   
   void Awake ()
   {
		if(singleton !=null) {
			Destroy (this);
			return;
		}
		singleton=this;
		
   }
   
   public void StartEnemyAnimation(string anim)
   {
		animEnemy.Play(anim, 0);
   }
   public void StartPlayerAnimation(string anim)
   {
	   if (anim == "SaeraCombateAttackCombo"){
		   if(!enemyDodge){
			   StartCoroutine (Delay(()=>
			   StartEnemyAnimation("ComboAttackRecived"),
			   0.2f));
		   }else{
				StartCoroutine (Delay(()=>
				StartEnemyAnimation("ComboAttackDodged"),
				0.2f));
		   }
	   }else if (anim =="SaeraCombateTrance"){
		   
	   }else if (anim =="SaeraCombateAtackFrontal"){
		   if(!enemyDodge){
			   StartCoroutine (Delay(()=>
			   StartEnemyAnimation("FrontalAttackRecived"),
			   0.2f));
		   }else{
			   StartCoroutine (Delay(()=>
			   StartEnemyAnimation("FrontalAttackDodged"),
			   0.2f));
		   }
		   
	   }else if (anim =="SaeraCombateAtackIzquierda"){
		   if(!enemyDodge){
			   StartCoroutine (Delay(()=>
			   StartEnemyAnimation("IzquierdaAttackRecived"),
			   0.2f));
		   }else{
			   StartCoroutine (Delay(()=>
			   StartEnemyAnimation("IzquierdaAttackDodged"),
			   0.2f));
		   }
	   }else if (anim =="SaeraCombateAtackDerecha"){
		   if(!enemyDodge){
			   StartCoroutine (Delay(()=>
			   StartEnemyAnimation("DerechaAttackRecived"),
			   0.2f));
		   }else{
			   StartCoroutine (Delay(()=>
			   StartEnemyAnimation("DerechaAttackDodged"),
			   0.2f));
		   }
	   }
	   animPlayer.Play (anim, 0);
   }
   
   IEnumerator Delay(System.Action action, float delay)
   {
	   yield return new WaitForSeconds (delay);
	   action.Invoke();
   }
   
   
}
