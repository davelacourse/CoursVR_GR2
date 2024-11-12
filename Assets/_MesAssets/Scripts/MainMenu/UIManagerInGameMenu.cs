using TMPro;
using UnityEngine;

public class UIManagerInGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panneauInGameMenu = default(GameObject);
    [SerializeField] private GameObject _panneauInGameOptions = default(GameObject);
    [SerializeField] private TMP_Text _txtSnapTurn = default(TMP_Text); 

    private Player _player;
    private bool _isMenuOPen;

    private void Start()
    {
        _player = FindAnyObjectByType<Player>();
        _isMenuOPen = false;
    }

    public void OnOptionsClick()
    {
        _panneauInGameMenu.SetActive(false);
        _panneauInGameOptions.SetActive(true);
    }

    public void OnQuitterClick()
    {
        GameManagerMainMenu.Instance.UpdateGameState(GameState.Quit);
    }

    public void OnSnapTurnOClick()
    {
        bool isSnapTurnOn = _player.ChangerSnapturn();
        if (isSnapTurnOn)
        {
            _txtSnapTurn.text = "Snap Turn : ON";
        }
        else
        {
            _txtSnapTurn.text = "Snap Turn : OFF";
        }
    }

    public void OnRetourClick()
    {
        _panneauInGameMenu.SetActive(true);
        _panneauInGameOptions.SetActive(false);
    }

    public void ToggleMenu()
    {
        
        if(GameManagerMainMenu.Instance.GameState != GameState.Start) 
        {
            _isMenuOPen = !_isMenuOPen;
            _panneauInGameMenu.SetActive(_isMenuOPen);
            _panneauInGameOptions.SetActive(false);
            if (_isMenuOPen )
            {
                GameManagerMainMenu.Instance.UpdateGameState(GameState.Pause);
            }
            else
            {
                GameManagerMainMenu.Instance.UpdateGameState(GameState.Play);
            }
        }

    }

}
