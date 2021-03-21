using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { Start, Action, End }

public class BattleSystem : MonoBehaviour
{
	[SerializeField] Player PlayerUnit;
	[SerializeField] Enemy EnemyUnit;
	[SerializeField] BattleHud SaeraHud;
	[SerializeField] BattleHud EnemyHud;
	[SerializeField] BattleDialogBox dialogBox;

	public static BattleState state;

	Grupo grupo;
	Enemigos worldEnemy;

	public event Action<bool> OnBattleOver;

	private bool enemyFainted = false;
	private bool playerFainted = false;

	public bool playerDodgeDer;
	public bool playerDodgeIzq;
	public bool playerDodgeDown;

	//public Slider enemigoHealthSlider;
	//public Slider CurrentHealthSlider;

	public bool enemyDodge;

	public static BattleSystem singleton;


	void Awake()
	{
		if (singleton != null)
		{
			Destroy(this);
			return;
		}
		singleton = this;

		//enemigoHealthSlider.maxValue = enemigoHealth;


		//CurrentHealthSlider.maxValue = SaeraController.SaeraMaxHealth;
		//currentHealth = SaeraController.SaeraHealth;
		//UpdateSliders();

	}
	void UpdateSliders()
	{
		//enemigoHealthSlider.value = enemigoHealth;
		//CurrentHealthSlider.value = currentHealth;
	}

	public void StartBattle(Grupo grupo, Enemigos worldEnemy)
	{
		this.grupo = grupo;
		this.worldEnemy = worldEnemy;
		StartCoroutine(SetupBattle());
	}
	public void HandleUpdate ()
    {
		Action();
    }


	public IEnumerator SetupBattle()
	{
		Debug.Log(state);

			PlayerUnit.Setup(grupo.GetSaeraHealth());
			SaeraHud.SetData(PlayerUnit.saera);
			EnemyUnit.Setup(worldEnemy);
			EnemyHud.SetData(EnemyUnit.enemy);

			yield return dialogBox.TypeDialog($"¡Cuidado! {EnemyUnit.enemy.Base.Name} te corta el paso");

			yield return new WaitForSeconds(1.5f);

			Action();

	}

	void Action()
    {
		state = BattleState.Action;
		dialogBox.EnableDialogBox(false);

		StartCoroutine(EnemyUnit.GetComponent<Enemy>().Start());

	}


	public void StartEnemyAnimation(string anim)
	{
		StartCoroutine(Delay(() =>
		{
			if (!playerDodgeDown && !playerDodgeIzq && anim == "AtackDerPerro") //si no esquivo abajo
																				// ni a la derecha (es decir me muevo a la izquierda) y me ataca por la derecha entonces:
			{
				//StartPlayerAnimation("Golpeado");
				playerFainted = PlayerUnit.saera.Damage(EnemyUnit.enemy);
				SaeraHud.UpdateHP();
				if (playerFainted)
				{
					//gameover
					Debug.Log("has perdido");
					SaeraHud.UpdateHP();
					dialogBox.EnableDialogBox(true);
					StartCoroutine(dialogBox.TypeDialog("Has perdido"));
					state = BattleState.End;
					StartCoroutine(Delay(() => {
						OnBattleOver(false);
					}, 2f));
				}
			}

			if (!playerDodgeDown && !playerDodgeDer && anim == "AtackIzqPerro") //si no esquivo abajo
																				// ni a la izquierda(es decir me muevo a la derecha) y me ataca por la izquierda entonces:
			{

				//StartPlayerAnimation("Golpeado");
				playerFainted = PlayerUnit.saera.Damage(EnemyUnit.enemy);
				SaeraHud.UpdateHP();
				if (playerFainted)
				{
					//gameover
					Debug.Log("has perdido");
					SaeraHud.UpdateHP();
					dialogBox.EnableDialogBox(true);
					StartCoroutine(dialogBox.TypeDialog("Has perdido"));
					state = BattleState.End;
					StartCoroutine(Delay(() => {
						OnBattleOver(false);
					}, 2f));
				}
			}
		}, 1f));
		EnemyUnit.animator.Play(anim, 0);
	}

	public void StartPlayerAnimation(string anim)
	{

		if (anim == "SaeraCombateAtackIzq")
		{
			if (!enemyDodge)
			{
				StartCoroutine(Delay(() =>
				{
					//StartEnemyAnimation("IzquierdaAttackRecived");
					// aqui va algun aviso de UI de golpeo
					// aqui va algun sonido de golpeo
					enemyFainted = EnemyUnit.enemy.Damage(PlayerUnit.saera);
					EnemyHud.UpdateHP();
					if (enemyFainted)
					{
						//has ganado
						Debug.Log("Has ganado");
						EnemyHud.UpdateHP();
						dialogBox.EnableDialogBox(true);
						StartCoroutine(dialogBox.TypeDialog("Has ganado"));
						state = BattleState.End;
						StartCoroutine(Delay(() => {
							OnBattleOver(true);
						}, 2f));

					}
				}, 0.2f));
			}
			else
			{
				StartCoroutine(Delay(() =>
				{
					//StartEnemyAnimation("IzquierdaAttackDodged");
				}, 0.2f));
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

		}
		else if (anim == "SaeraCombateEstocada")
		{
			if (!enemyDodge)
			{
				StartCoroutine(Delay(() => {
					//StartEnemyAnimation("FrontalAttackRecived");
					enemyFainted = EnemyUnit.enemy.Damage(PlayerUnit.saera);
					EnemyHud.UpdateHP();
					if (enemyFainted)
					{
						//has ganado
						Debug.Log("Has ganado");
						EnemyHud.UpdateHP();
						dialogBox.EnableDialogBox(true);
						StartCoroutine(dialogBox.TypeDialog("Has ganado"));
						state = BattleState.End;
						StartCoroutine(Delay(() => {
							OnBattleOver(true);
						}, 2f));

					}
				}, 0.2f));
			}
			else
			{
				StartCoroutine(Delay(() => {
					//StartEnemyAnimation("FrontalAttackDodged");
				}, 0.2f));
			}

		}
		else if (anim == "SaeraCombateAtackDer")
		{
			if (!enemyDodge)
			{
				StartCoroutine(Delay(() => {
					//StartEnemyAnimation("DerechaAttackRecived");
					enemyFainted = EnemyUnit.enemy.Damage(PlayerUnit.saera);
					EnemyHud.UpdateHP();
					if (enemyFainted)
					{
						//has ganado
						Debug.Log("Has ganado");
						EnemyHud.UpdateHP();
						dialogBox.EnableDialogBox(true);
						StartCoroutine(dialogBox.TypeDialog("Has ganado"));
						state = BattleState.End;
						StartCoroutine(Delay(() => {
							OnBattleOver(true);
						}, 2f));

					}
				}, 0.2f));
			}
			else
			{
				StartCoroutine(Delay(() =>
				{
					//StartEnemyAnimation("DerechaAttackDodged");
				}, 0.2f));
			}
		}
		PlayerUnit.animator.Play(anim, 0);

		
		

	}


	IEnumerator Delay(System.Action action, float delay)
	{
		yield return new WaitForSeconds(delay);
		action.Invoke();
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2f);
	}

}
