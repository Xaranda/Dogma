using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { World, Battle}

public class GameController : MonoBehaviour
{
    SaeraController saeraController;
    [SerializeField] Player player;
    [SerializeField] Camera worldCamera;
    GameState state;
    private void Start()
    {

    }

    void StartBattle()
    {
        state = GameState.Battle;
        player.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
        
    }
    private void Update ()
    {
        if (state == GameState.World)
        {
            
        }
        else if (state == GameState.Battle)
        {
            //player.HandleUpdate();
        }
    }
}
