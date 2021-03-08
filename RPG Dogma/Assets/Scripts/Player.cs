using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.D)){
			BattleManager.singleton.playerDodgeDer = true;
			StartCoroutine(Delay(() =>
			  BattleManager.singleton.playerDodgeDer = false,
			   0.8f));
			Debug.Log(BattleManager.singleton.playerDodgeDer);
			BattleManager.singleton.StartPlayerAnimation("SaeraCombateDodgeDerecha");
		}

		if (Input.GetKeyDown (KeyCode.A)){
			BattleManager.singleton.playerDodgeIzq = true;
			StartCoroutine(Delay(() =>
			  BattleManager.singleton.playerDodgeIzq = false,
			   0.8f));
			Debug.Log(BattleManager.singleton.playerDodgeDer);
			BattleManager.singleton.StartPlayerAnimation( "SaeraCombateDodgeIzquierda");
		}

		if (Input.GetKeyDown (KeyCode.S))
		{
			BattleManager.singleton.playerDodgeDown = true;
			StartCoroutine(Delay(() =>
			  BattleManager.singleton.playerDodgeDown = false,
			   0.8f));
			BattleManager.singleton.StartPlayerAnimation( "SaeraCombateDodgeDown");
		}

		//if (Input.GetKeyDown (KeyCode.Space)){
		//	BattleManager.singleton.StartPlayerAnimation("SaeraCombateAttackCombo");
		//}
		//if (Input.GetKeyDown (KeyCode.R)){
		//BattleManager.singleton.StartPlayerAnimation("SaeraCombateTrance");
		//}
		if (Input.GetKeyDown (KeyCode.W))
		{
			BattleManager.singleton.StartPlayerAnimation( "SaeraCombateEstocada");
		}
		if (Input.GetKeyDown (KeyCode.Q))
		{
			BattleManager.singleton.StartPlayerAnimation( "SaeraCombateAtackIzq");
		}
		if (Input.GetKeyDown (KeyCode.E))
		{
			BattleManager.singleton.StartPlayerAnimation( "SaeraCombateAtackDer");
		}
		
	}

	IEnumerator Delay(System.Action action, float delay)
	{
		yield return new WaitForSeconds(delay);
		action.Invoke();
	}
}
