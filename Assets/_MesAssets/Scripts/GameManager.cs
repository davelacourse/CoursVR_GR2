using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _activate = default;
    [SerializeField] GameObject _sphere = default;

    private bool _estVisible = true;

    void Start()
    {
        _activate.action.performed += ShowHideSphere;
    }

    private void ShowHideSphere(InputAction.CallbackContext obj)
    {
        if (_estVisible)
        {
            _sphere.SetActive(false);
            _estVisible = false;
        }
        else
        {
            _sphere.SetActive(true);
            _estVisible = true;
        }
    }

    private void OnDestroy()
    {
        _activate.action.performed -= ShowHideSphere;
    }
}
