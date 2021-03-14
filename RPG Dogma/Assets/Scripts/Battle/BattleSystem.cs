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



	public int currentHealth;
	public int enemigoHealth = 10;

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
		currentHealth = SaeraController.SaeraHealth;
		//UpdateSliders();

	}
	void UpdateSliders()
	{
		//enemigoHealthSlider.value = enemigoHealth;
		//CurrentHealthSlider.value = currentHealth;
	}

	private void Start()
	{
		StartCoroutine(SetupBattle());
	}


	public IEnumerator SetupBattle()
	{
		PlayerUnit.Setup();
		SaeraHud.SetData(PlayerUnit.saera);
		EnemyUnit.Setup();
		EnemyHud.SetData(EnemyUnit.enemy);

		yield return dialogBox.TypeDialog($"¡Cuidado! {PlayerUnit.saera.Base.Name} te corta el paso");

		yield return new WaitForSeconds(1.5f);

		Action();

		yield return EnemyHud.UpdateHP();
		yield return SaeraHud.UpdateHP();

	}

	void Action()
    {
		state = BattleState.Action;
		dialogBox.EnableDialogBox(false);

		StartCoroutine(EnemyUnit.GetComponent<Enemy>().Start());
		


	}
	public void StartEnemyAnimation(string anim)
	{
		Debug.Log(anim);
		StartCoroutine(Delay(() =>
		{
			if (!playerDodgeDown && !playerDodgeIzq && anim == "AtackDerPerro") //si no esquivo abajo
																				// ni a la derecha (es decir me muevo a la izquierda) y me ataca por la derecha entonces:
			{
				//StartPlayerAnimation("Golpeado");
				bool isFainted = PlayerUnit.saera.Damage(EnemyUnit.enemy);
				

			}

			if (!playerDodgeDown && !playerDodgeDer && anim == "AtackIzqPerro") //si no esquivo abajo
																				// ni a la izquierda(es decir me muevo a la derecha) y me ataca por la izquierda entonces:
			{

				//StartPlayerAnimation("Golpeado");
				bool isFainted = PlayerUnit.saera.Damage(EnemyUnit.enemy);
				

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
					bool isFainted = EnemyUnit.enemy.Damage(PlayerUnit.saera);
					
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
					bool isFainted = EnemyUnit.enemy.Damage(PlayerUnit.saera);
					
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
					bool isFainted = EnemyUnit.enemy.Damage(PlayerUnit.saera);

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

		if (PlayerUnit.saera.Damage(EnemyUnit.enemy) == true)
		{
			//gameover
			Debug.Log("has perdido");
		}
		else if (EnemyUnit.enemy.Damage(PlayerUnit.saera) == true)
		{
			//has ganado
			Debug.Log("Has ganado");
		}
	}


	IEnumerator Delay(System.Action action, float delay)
	{
		yield return new WaitForSeconds(delay);
		yield return EnemyHud.UpdateHP();
		yield return SaeraHud.UpdateHP();
		action.Invoke();
	}


}
