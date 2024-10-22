using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
public enum GameState
{
    MainMenu,
    GamePlay,
    Setting,
    Win,
    Lose,
}
public class GameManager : Singleton<GameManager>
{

    private static GameState gameState = GameState.MainMenu;


    protected override void Awake()
    {
        base.Awake();
        Input.multiTouchEnabled = true;

        ChangeState(GameState.MainMenu);
        UIManager.Ins.OpenUI<MianMenu>();
        UIManager.Ins.OpenUI<BarMenu>();
    }

    public static void ChangeState(GameState state)
    {
        gameState = state;
    }

    public static bool IsState(GameState state)
    {
        return gameState == state;
    }

}
