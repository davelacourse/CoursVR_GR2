using TMPro;
using UnityEngine;

public class UIManagerMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panneauMainMenu = default(GameObject);
    [SerializeField] private GameObject _panneauOptions = default(GameObject);
    [SerializeField] private TMP_Text _txtSnapTurn = default(TMP_Text); 

    private Player _player;

    private void Start()
    {
        _player = FindAnyObjectByType<Player>();
    }

    public void OnDemarrerClick()
    {
        GameManagerMainMenu.Instance.UpdateGameState(GameState.Play);
        _panneauMainMenu.SetActive(false);
        _panneauOptions.SetActive(false); ;
    }

    public void OnOptionsClick()
    {
        _panneauMainMenu.SetActive(false);
        _panneauOptions.SetActive(true);
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
        _panneauMainMenu.SetActive(true);
        _panneauOptions.SetActive(false);
    }

}
