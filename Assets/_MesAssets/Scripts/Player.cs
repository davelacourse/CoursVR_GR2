using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class Player : MonoBehaviour
{
    private ActionBasedControllerManager[] _actionBasedControllerManager;

    private DynamicMoveProvider _dynamicMoveProvider;

    private void Awake()
    {
        _actionBasedControllerManager = GetComponentsInChildren<ActionBasedControllerManager>();
        _dynamicMoveProvider = GetComponentInChildren<DynamicMoveProvider>();
    }

    private void Start()
    {
        GererGameStateChanged(GameManagerMainMenu.Instance.GameState); // sécurité pour s'assurer d'avoir la bonne valeur au départ
        GameManagerMainMenu.OnGameStateChanged += GererGameStateChanged;
    }

    private void GererGameStateChanged(GameState gamestate)
    {
        switch (gamestate)
        {
            case GameState.Start:
                MouvementsJoueur(false);
                break;
            case GameState.Play:
                MouvementsJoueur(true);
                break;
            case GameState.Pause:
                MouvementsJoueur(false);
                break;
            default:
                break;
        }
    }

    private void MouvementsJoueur(bool isMoving)
    {
        if(isMoving)
        {
            _dynamicMoveProvider.moveSpeed = 1;
        }
        else
        {
            _dynamicMoveProvider.moveSpeed = 0;
        }
    }

    public bool ChangerSnapturn()
    {

        foreach (var controller in _actionBasedControllerManager)
        {
            controller.smoothTurnEnabled = !controller.smoothTurnEnabled;
        }

        return !_actionBasedControllerManager[0].smoothTurnEnabled;
    }

    
}
