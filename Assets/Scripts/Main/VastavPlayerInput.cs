using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class VastavPlayerInput : MonoBehaviour
{
    private PlayerInputAction playerInputActions;

    public static Action<Vector2> OnMove;

    private void Awake()
    {
        if (playerInputActions == null)
        {
            playerInputActions = new PlayerInputAction();
            playerInputActions.Enable();
        }
    }

    private void Update()
    {
        Vector2 moveData = playerInputActions.Player.Movement.ReadValue<Vector2>();
        OnMove?.Invoke(moveData);


        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        Debug.Log("Mouse Delta: " + mouseDelta);
    }
}

