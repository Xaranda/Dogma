using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[SerializeField] EnemigoBase _base;
	[SerializeField] int level;

	public Animator animator;
	public Enemigos saera { get; set; }
	private float cooldown;
	private float wait;


	public void Setup ()
    {
		saera = new Enemigos(_base, level);
		saera.Base.anim = GetComponent<Animator>();
		cooldown = 0.0f;
    }

    // Update is called once per frame
    public void Update()
    {
		if (BattleSystem.state.ToString() == "Action")
		{
			cooldown += Time.deltaTime;
			if (1.0f < cooldown) {
				if (Input.GetKeyDown(KeyCode.D))
				{
					BattleSystem.singleton.playerDodgeDer = true;
					StartCoroutine(Delay(() =>
					{
						BattleSystem.singleton.playerDodgeDer = false;
					}, 2f));
					Debug.Log(BattleSystem.singleton.playerDodgeDer);
					BattleSystem.singleton.StartPlayerAnimation("SaeraCombateDodgeDerecha");
					cooldown = 0.0f;
				}

				if (Input.GetKeyDown(KeyCode.A))
				{
					BattleSystem.singleton.playerDodgeIzq = true;
					StartCoroutine(Delay(() =>
					{
						BattleSystem.singleton.playerDodgeIzq = false;
					}, 2f));
					Debug.Log(BattleSystem.singleton.playerDodgeDer);
					BattleSystem.singleton.StartPlayerAnimation("SaeraCombateDodgeIzquierda");
					cooldown = 0.0f;
				}

				if (Input.GetKeyDown(KeyCode.S))
				{
					BattleSystem.singleton.playerDodgeDown = true;
					StartCoroutine(Delay(() =>
					{
						BattleSystem.singleton.playerDodgeDown = false;
					}, 2f));
					BattleSystem.singleton.StartPlayerAnimation("SaeraCombateDodgeDown");
					cooldown = 0.0f;
				}

				//if (Input.GetKeyDown (KeyCode.Space)){
				//	BattleManager.singleton.StartPlayerAnimation("SaeraCombateAttackCombo");
				//}
				//if (Input.GetKeyDown (KeyCode.R)){
				//BattleManager.singleton.StartPlayerAnimation("SaeraCombateTrance");
				//}
				if (Input.GetKeyDown(KeyCode.W))
				{
					BattleSystem.singleton.StartPlayerAnimation("SaeraCombateEstocada");
					cooldown = 0.0f;
				}
				if (Input.GetKeyDown(KeyCode.Q))
				{
					BattleSystem.singleton.StartPlayerAnimation("SaeraCombateAtackIzq");
					cooldown = 0.0f;
				}
				if (Input.GetKeyDown(KeyCode.E))
				{
					BattleSystem.singleton.StartPlayerAnimation("SaeraCombateAtackDer");
					cooldown = 0.0f;
				}
				
			}
		}
		
	}

	IEnumerator Delay(System.Action action, float delay)
	{
		yield return new WaitForSeconds(delay);
		action.Invoke();
	}
}
