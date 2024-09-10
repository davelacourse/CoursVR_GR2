using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementSphere : MonoBehaviour
{
    [SerializeField] private InputActionReference _move = default;
    private Vector3 _direction = Vector3.zero;
    [SerializeField] private float _vitesse = 10f;

    void Start()
    {
        _move.action.performed += BougerSphere;
    }

    private void BougerSphere(InputAction.CallbackContext obj)
    {
        Vector2 direction2D = obj.ReadValue<Vector2>();
        _direction = new Vector3(direction2D.x, 0f, direction2D.y);
        transform.Translate(_direction * Time.fixedDeltaTime * _vitesse);
    }

    private void OnDestroy()
    {
        _move.action.performed -= BougerSphere;
    }
}
