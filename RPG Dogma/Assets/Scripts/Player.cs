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
		 BattleManager.singleton.StartPlayerAnimation( "SaeraCombateDodgeDerecha");
		}
		if (Input.GetKeyDown (KeyCode.A)){
		 BattleManager.singleton.StartPlayerAnimation( "SaeraCombateDodgeIzquierda");
		}
		if (Input.GetKeyDown (KeyCode.S)){
		 BattleManager.singleton.StartPlayerAnimation( "SaeraCombateDodgeAgacharse");
		}
		if (Input.GetKeyDown (KeyCode.Space)){
			BattleManager.singleton.StartPlayerAnimation("SaeraCombateAttackCombo");
		}
		if (Input.GetKeyDown (KeyCode.R)){
			BattleManager.singleton.StartPlayerAnimation("SaeraCombateTrance");
		}
		if (Input.GetKeyDown (KeyCode.W)){
		 BattleManager.singleton.StartPlayerAnimation( "SaeraCombateAtackFrontal");
		}
		if (Input.GetKeyDown (KeyCode.Q)){
		 BattleManager.singleton.StartPlayerAnimation( "SaeraCombateAtackIzquierda");
		}
		if (Input.GetKeyDown (KeyCode.E)){
		 BattleManager.singleton.StartPlayerAnimation( "SaeraCombateAtackDerecha");
		}
		
		void SetDodgeFalse()
		{
			BattleManager.singleton.playerDodge = false;
		}
    }
}
