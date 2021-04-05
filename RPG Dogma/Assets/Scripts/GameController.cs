using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { World, Battle}

public class GameController : MonoBehaviour
{
    [SerializeField] SaeraController saeraController;
    [SerializeField] Player PlayerUnit;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] Camera worldCamera;

    GameState state;

    private void Start()
    {
        saeraController.OnEncountered += StartBattle;
        battleSystem.OnBattleOver += EndBattle;
    }

    void StartBattle()
    {
        state = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);

        var grupo = saeraController.GetComponent<Grupo>();
        var worldEnemy = FindObjectOfType<MapArea>().GetComponent<MapArea>().GetRandomEnemy();

        battleSystem.StartBattle(grupo, worldEnemy);
    }


    void EndBattle (bool won)
    {
        state = GameState.World;
        battleSystem.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }
    private void Update ()
    {
        if (state == GameState.World)
        {
            saeraController.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {
            battleSystem.SetupBattle();
            StartCoroutine(Wait());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          Application.Quit();
        }

    }

    IEnumerator Wait ()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
