using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
	public Animator Saera;
	public Animator Enemigo;

	int currentHealth;
	public int enemigoHealth = 10;
   
	public bool playerDodgeDer;
	public bool playerDodgeIzq;
	public bool playerDodgeDown;

	public Slider enemigoHealthSlider;
	public Slider CurrentHealthSlider;

	public bool enemyDodge;
   
	public static BattleManager singleton;





	void Awake ()
	{
		if(singleton !=null) {
			Destroy (this);
			return;
		}
		singleton=this;

		enemigoHealthSlider.maxValue = enemigoHealth;


		CurrentHealthSlider.maxValue = SaeraController.SaeraMaxHealth;
		currentHealth = SaeraController.SaeraHealth;
		UpdateSliders();
		
	}
	void UpdateSliders()
    {
		enemigoHealthSlider.value = enemigoHealth;
		CurrentHealthSlider.value = currentHealth;
    }
   
	public void StartEnemyAnimation(string anim)
	{
		if (!playerDodgeDer || !playerDodgeDown)
		{
			if (anim == "AtackDerPerro")
			{
				StartCoroutine(Delay(() =>
			   {
				   //StartPlayerAnimation("Golpeado");
				   currentHealth -= 1;
				   UpdateSliders();
			   },
				0.5f));

			}
		}
		if (!playerDodgeIzq || !playerDodgeDown) 
		{ 
			if (anim == "AtackIzqPerro")
			{
				StartCoroutine(Delay(() =>
				{
					//StartPlayerAnimation("Golpeado");
					currentHealth -= 1;
					UpdateSliders();
				},
				0.5f));

			}
		}
		Enemigo.Play(anim, 0);
	}
	public void StartPlayerAnimation(string anim)
	{
		if (anim == "SaeraCombateAtackIzq")
		{
			if (!enemyDodge)
			{
				StartCoroutine(Delay(() =>
				{ 
					StartEnemyAnimation("IzquierdaAttackRecived");
					// aqui va algun aviso de UI de golpeo
					// aqui va algun sonido de golpeo
					enemigoHealth -= 1;
					UpdateSliders();
				},0.2f));
			}else{
				StartCoroutine(Delay(() =>
				{
					StartEnemyAnimation("IzquierdaAttackDodged");
				},0.2f));
			}
		//if (anim == "SaeraCombateAttackCombo"){
		//	if(!enemyDodge){
		//	   StartCoroutine (Delay(()=>
		//	   StartEnemyAnimation("ComboAttackRecived"),
		//	   0.2f));
		//	}else{
		//		StartCoroutine (Delay(()=>
		//		StartEnemyAnimation("ComboAttackDodged"),
		//		0.2f));
		//	}
	   //}else if (anim =="SaeraCombateTrance"){
		   
		}else if (anim =="SaeraCombateEstocada")
		{
		   if(!enemyDodge)
			{
			   StartCoroutine(Delay(() => {
				   StartEnemyAnimation("FrontalAttackRecived");
				   enemigoHealth -= 1;
				   UpdateSliders();
			   },0.2f));
			}else{
			   StartCoroutine(Delay(() => {
				   StartEnemyAnimation("FrontalAttackDodged");
			   },0.2f));
			}
		   
		}else if (anim =="SaeraCombateAtackDer"){
		   if(!enemyDodge){
			   StartCoroutine(Delay(() => {
				   StartEnemyAnimation("DerechaAttackRecived");
				   enemigoHealth -= 1;
				   UpdateSliders();
			   },0.2f));
		   }else{
			   StartCoroutine(Delay(() =>
			   {
				   StartEnemyAnimation("DerechaAttackDodged");
			   },0.2f));
		   }
		}
	   Saera.Play (anim, 0);
	}
   
	 IEnumerator Delay(System.Action action, float delay)
	{
	   yield return new WaitForSeconds (delay);
	   action.Invoke();
	}
   
   
}
