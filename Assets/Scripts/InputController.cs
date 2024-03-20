using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private CharacterMovement _characterMovement;

    private void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        _characterMovement.Move(input.x);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
            _characterMovement.Jump();
    }
}
