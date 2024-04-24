using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharMovement : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    public float playerSpeed = 5.0f;
    private const float GravityValue = -9.81f;

    private PlayerInputActions _playerInputActions;

    private InputAction _moveAction;
    private InputAction _lookAction;
    private bool connected = false;

    //InputAction interactAction;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
    }

    

    private void OnEnable()
    {
        //PS5 controller support enabled
        _playerInputActions.Player.Enable();
        _moveAction = _playerInputActions.Player.Move;
        _moveAction.Enable();
        
        _lookAction = _playerInputActions.Player.Look;
        _lookAction.Enable();
        
        _playerInputActions.Player.Interact.performed += OnInteract;
        _playerInputActions.Player.Interact.Enable();

        _playerInputActions.Player.Inspect.performed += OnTriangle;
        _playerInputActions.Player.Inspect.Enable();

        _playerInputActions.Player.Back.performed += OnBack;
        _playerInputActions.Player.Back.Enable();

        _playerInputActions.Player.Square.performed += OnSquare;
        _playerInputActions.Player.Square.Enable();    
        
        _playerInputActions.Player.Options.performed += OnOptions;
        _playerInputActions.Player.Options.Enable();  
        
        //The share button is an exclusive used button by the ps5 hardware we can't access it
        //_playerInputActions.Player.Share.Enable();  
        
        _playerInputActions.Player.DPadUp.performed += OnDPadUp;
        _playerInputActions.Player.DPadUp.Enable();  
        _playerInputActions.Player.DPadDown.performed += OnDPadDown;
        _playerInputActions.Player.DPadDown.Enable();  
        _playerInputActions.Player.DPadLeft.performed += OnDPadLeft;
        _playerInputActions.Player.DPadLeft.Enable();  
        _playerInputActions.Player.DPadRight.performed += OnDPadRight;
        _playerInputActions.Player.DPadRight.Enable(); 
        Debug.Log(_playerInputActions.Player.Interact.expectedControlType);
    }
    
    private void OnDisable()
    {
        //PS5 controller support enabled
        _moveAction.Disable();
        _lookAction.Disable();
        _playerInputActions.Player.Interact.performed -= OnInteract;
        _playerInputActions.Player.Interact.Disable();
        
        _playerInputActions.Player.Inspect.performed -= OnTriangle;
        _playerInputActions.Player.Inspect.Disable();

        _playerInputActions.Player.Back.performed -= OnBack;
        _playerInputActions.Player.Back.Disable();

        _playerInputActions.Player.Square.performed -= OnSquare;
        _playerInputActions.Player.Square.Disable();    
        
        _playerInputActions.Player.Options.performed -= OnOptions;
        _playerInputActions.Player.Options.Disable();  
        
        //The share button is an exclusive used button by the ps5 hardware we can't access it
        //_playerInputActions.Player.Share.Enable();  
        
        _playerInputActions.Player.DPadUp.performed -= OnDPadUp;
        _playerInputActions.Player.DPadUp.Disable();  
        _playerInputActions.Player.DPadDown.performed -= OnDPadDown;
        _playerInputActions.Player.DPadDown.Disable();  
        _playerInputActions.Player.DPadLeft.performed -= OnDPadLeft;
        _playerInputActions.Player.DPadLeft.Disable();  
        _playerInputActions.Player.DPadRight.performed -= OnDPadRight;
        _playerInputActions.Player.DPadRight.Disable();  
        
        
        _playerInputActions.Player.Disable();

    }
    
    private void OnInteract(InputAction.CallbackContext context)
    {
        print("x button pressed");
    }
    
    private void OnBack(InputAction.CallbackContext context)
    {
        print("circle button pressed");
    }
    
    private void OnTriangle(InputAction.CallbackContext context)
    {
        print("triangle button pressed");
    }
    private void OnSquare(InputAction.CallbackContext context)
    {
        print("square button pressed");
    }
    
    private void OnOptions(InputAction.CallbackContext context)
    {
        print("options button pressed");
    }
    
    private void OnDPadUp(InputAction.CallbackContext context)
    {
        print("dpad up button pressed");
    }

    private void OnDPadDown(InputAction.CallbackContext context)
    {
        print("dpad down button pressed");
    }
    
    private void OnDPadLeft(InputAction.CallbackContext context)
    {
        print("dpad left button pressed");
    }
    private void OnDPadRight(InputAction.CallbackContext context)
    {
        print("dpad right button pressed");
    }
    

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        PlayerInput input = FindObjectOfType<PlayerInput>();
        Debug.Log(input.currentControlScheme);
        for(int i = 0; i < Gamepad.all.Count; i++)
        {
            Debug.Log(Gamepad.all[i].name);
        }
    }
    
    void FixedUpdate()
    {
        Vector3 move = new Vector3(_moveAction.ReadValue<Vector2>().x, 0, _moveAction.ReadValue<Vector2>().y);
        _controller.Move(Time.deltaTime * playerSpeed * move);
        
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        
        //Y Vector Space Value
        _playerVelocity.y += GravityValue * Time.deltaTime;
        
        //Relative movement, not absolute, 3D vector Space movement
        _controller.Move(_playerVelocity * Time.deltaTime);

    }
}
