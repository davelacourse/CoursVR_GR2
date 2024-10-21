using System;
using UnityEngine;

public enum GameState
{
    Start,
    Play,
    Pause,
    Quit
}

public class GameManagerMainMenu : MonoBehaviour
{
    //Singleton
    public static GameManagerMainMenu Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    //-----------------------------------------

    //Attributs
    public static event Action<GameState> OnGameStateChanged;
    private GameState _gamestate;
    public GameState GameState => _gamestate;

    private void Start()
    {
        UpdateGameState(GameState.Start);
        GameManagerMainMenu.OnGameStateChanged += UpdateGameState;
    }

    private void OnDestroy()
    {
        GameManagerMainMenu.OnGameStateChanged -= UpdateGameState;
    }

    public void UpdateGameState(GameState gameState)
    {
        if(gameState == _gamestate) { return; }
        
        
        _gamestate = gameState;  // voilà l'erreur je dois aussi changer la valeur de l'attribut !!!

        if(gameState == GameState.Quit)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        
        OnGameStateChanged?.Invoke(gameState);
    }
}
