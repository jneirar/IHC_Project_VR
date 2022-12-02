using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(this);
    }
    #endregion

    public GameState gameState;
    public static event Action<GameState> OnGameStateChanged;

    private bool level1completed = false;
    private bool level2completed = false;

    void Start()
    {
        UpdateGameState(GameState.MainMenuState);
    }

    public void UpdateGameState(GameState newState)
    {
        gameState = newState;
        switch (newState)
        {
            case GameState.MainMenuState:
                HandleMainMenuState();
                break;
            case GameState.CampaignState:
                HandleCampaignState();
                break;
            case GameState.LevelOneState:
                HandleLevelOneState();
                break;
            case GameState.LevelTwoState:
                HandleLevelTwoState();
                break;
            case GameState.TrainState:
                HandleTrainState();
                break;
            case GameState.OptionsState:
                HandleOptionsState();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(gameState);
    }

    void HandleMainMenuState()
    {
        SwitchScene.Instance.loadScene("Assets/Scenes/MainMenuScene.unity");
    }

    void HandleCampaignState()
    {
        SwitchScene.Instance.loadScene("Assets/Scenes/CampaignScene.unity");
    }

    void HandleLevelOneState()
    {
        SwitchScene.Instance.loadScene("Assets/Scenes/LevelOneScene.unity");
    }

    void HandleLevelTwoState()
    {
        SwitchScene.Instance.loadScene("Assets/Scenes/LevelTwoScene.unity");
    }

    void HandleTrainState()
    {
        SwitchScene.Instance.loadScene("Assets/Scenes/TrainScene.unity");
    }

    void HandleOptionsState()
    {
        //SwitchScene.Instance.loadScene("Assets/Scenes/OptionsScene.unity");
    }

    public enum GameState
    {
        MainMenuState,
        CampaignState,
        LevelOneState,
        LevelTwoState,
        TrainState,
        OptionsState        
    }

    public bool getLevel1Completed()
    {
        return level1completed;
    }

    public void setLevel1Completed(bool value)
    {
        level1completed = value;
    }

    public bool getLevel2Completed()
    {
        return level2completed;
    }

    public void setLevel2Completed(bool value)
    {
        level2completed = value;
    }
}
