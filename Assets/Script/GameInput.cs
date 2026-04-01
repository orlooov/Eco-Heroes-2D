using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInput playerInput;


    private void Awake()
    {
        Instance = this;

        playerInput = new PlayerInput();
        playerInput.Enable();

        
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        return mousePos;
    }


}
