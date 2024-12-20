using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Game.Constants;

public interface IPlayerActions
{
    void OnMove(InputAction.CallbackContext context);
    void OnLook(InputAction.CallbackContext context);
    void OnFire(InputAction.CallbackContext context);
    void OnInteract(InputAction.CallbackContext context);
    void OnInspect(InputAction.CallbackContext context);
    void OnBack(InputAction.CallbackContext context);
    void OnSquare(InputAction.CallbackContext context);
    void OnOptions(InputAction.CallbackContext context);
    void OnDPadUp(InputAction.CallbackContext context);
    void OnDPadDown(InputAction.CallbackContext context);
    void OnDPadLeft(InputAction.CallbackContext context);
    void OnDPadRight(InputAction.CallbackContext context);
}

public class CharMovement : MonoBehaviour, PlayerInputActions.IPlayerActions
{

    private CharacterController _controller;
    private Vector3 _playerVelocity;
    public float playerSpeed = 5.0f;
    private const float GravityValue = -9.81f;
    public GameObject objectPrefab;

    private GameObject obj;
    private List<bullet> bullets;
    int bullet_lim = 4;
    public static Vector3 movement_vector;
    public static Vector3 position_vector;
    private Vector3 start_vector;
    private Vector3 end_vector;
    private Bounds bounds;

    private PlayerInputActions _playerInputActions;

    // private InputAction _moveAction;
    // private InputAction _lookAction;
    private bool connected = false;
    
    public GameObject associatedCrosshair;
    
    private LineRenderer lineRenderer;

    private Vector3 moveValue;

    private Vector3 moveCharCrosshair;
    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.SetCallbacks(this);
    }

    private void OnEnable()
    {
        _playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Player.Disable();
    }

    //InputAction interactAction;

    // private void Awake()
    // {
    //     gameObject.SetActive(true);
    //     _playerInputActions = new PlayerInputActions();
    // }
    //
    //
    //
    // private void OnEnable()
    // {
    //     //PS5 controller support enabled
    //     _playerInputActions.Player.Enable();
    //     
    //     //These need to be their own movement vars
    //     _moveAction = _playerInputActions.Player.Move;
    //     _moveAction.Enable();
    //     
    //     _lookAction = _playerInputActions.Player.Look;
    //     _lookAction.Enable();
    //     //
    //     _playerInputActions.Player.Interact.performed += OnInteract;
    //     _playerInputActions.Player.Interact.Enable();
    //
    //     _playerInputActions.Player.Inspect.performed += OnTriangle;
    //     _playerInputActions.Player.Inspect.Enable();
    //
    //     _playerInputActions.Player.Back.performed += OnBack;
    //     _playerInputActions.Player.Back.Enable();
    //
    //     _playerInputActions.Player.Square.performed += OnSquare;
    //     _playerInputActions.Player.Square.Enable();    
    //     
    //     _playerInputActions.Player.Options.performed += OnOptions;
    //     _playerInputActions.Player.Options.Enable();  
    //     
    //     //The share button is an exclusive used button by the ps5 hardware we can't access it
    //     //_playerInputActions.Player.Share.Enable();  
    //     
    //     _playerInputActions.Player.DPadUp.performed += OnDPadUp;
    //     _playerInputActions.Player.DPadUp.Enable();  
    //     _playerInputActions.Player.DPadDown.performed += OnDPadDown;
    //     _playerInputActions.Player.DPadDown.Enable();  
    //     _playerInputActions.Player.DPadLeft.performed += OnDPadLeft;
    //     _playerInputActions.Player.DPadLeft.Enable();  
    //     _playerInputActions.Player.DPadRight.performed += OnDPadRight;
    //     _playerInputActions.Player.DPadRight.Enable(); 
    //     Debug.Log(_playerInputActions.Player.Interact.expectedControlType);
    // }
    //
    // private void OnDisable()
    // {
    //     //PS5 controller support enabled
    //     _moveAction.Disable();
    //     _lookAction.Disable();
    //     _playerInputActions.Player.Interact.performed -= OnInteract;
    //     _playerInputActions.Player.Interact.Disable();
    //     
    //     _playerInputActions.Player.Inspect.performed -= OnTriangle;
    //     _playerInputActions.Player.Inspect.Disable();
    //
    //     _playerInputActions.Player.Back.performed -= OnBack;
    //     _playerInputActions.Player.Back.Disable();
    //
    //     _playerInputActions.Player.Square.performed -= OnSquare;
    //     _playerInputActions.Player.Square.Disable();    
    //     
    //     _playerInputActions.Player.Options.performed -= OnOptions;
    //     _playerInputActions.Player.Options.Disable();  
    //     
    //     //The share button is an exclusive used button by the ps5 hardware we can't access it
    //     //_playerInputActions.Player.Share.Enable();  
    //     
    //     _playerInputActions.Player.DPadUp.performed -= OnDPadUp;
    //     _playerInputActions.Player.DPadUp.Disable();  
    //     _playerInputActions.Player.DPadDown.performed -= OnDPadDown;
    //     _playerInputActions.Player.DPadDown.Disable();  
    //     _playerInputActions.Player.DPadLeft.performed -= OnDPadLeft;
    //     _playerInputActions.Player.DPadLeft.Disable();  
    //     _playerInputActions.Player.DPadRight.performed -= OnDPadRight;
    //     _playerInputActions.Player.DPadRight.Disable();  
    //     
    //     
    //     _playerInputActions.Player.Disable();
    //
    // }
    //
    public void OnInteract(InputAction.CallbackContext context)
    {
        print("x button pressed");
        
        if (bullets.Count <= this.bullet_lim)
        {
            Vector3 movement_vector = (end_vector - start_vector).normalized;
            
            bullets.Add(new bullet( gameObject.transform.position, movement_vector));
        }
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        print("fire b pressed");
        
    }
    
    public void OnLook(InputAction.CallbackContext context)
    {
        //print("fire b pressed");
        
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        //print("fire b pressed");
        
    }
    public void OnShare(InputAction.CallbackContext context)
    {
        print("fire b pressed");
        
    }
    public void OnInspect(InputAction.CallbackContext context)
    {
        print("triangle button pressed");
        
    }
    public void OnBack(InputAction.CallbackContext context)
    {
        print("circle button pressed");
    }
    
    public void OnSquare(InputAction.CallbackContext context)
    {
        print("square buttonADJUISHDIUHSAIUHUFID");

        print("square button pressed");
    }
    
    public void OnOptions(InputAction.CallbackContext context)
    {
        print("options button pressed");
    }
    
    public void OnDPadUp(InputAction.CallbackContext context)
    {
        print("dpad up button pressed");
    }

    public void OnDPadDown(InputAction.CallbackContext context)
    {
        print("dpad down button pressed");
       ///Debug.Log(bullets.Count);
    }
    
    public void OnDPadLeft(InputAction.CallbackContext context)
    {
        print("dpad left button pressed");
    }
    public void OnDPadRight(InputAction.CallbackContext context)
    {
        print("dpad right button pressed");
    }
    

    private void Start()
    {
        bounds = new Bounds(new Vector3(0, 0, 0), new Vector3(20, 10, 10));

        bullets = new List<bullet>();
        
        _controller = GetComponent<CharacterController>();
        
        
        if (GameConstants.Debug)
        {
            // Add LineRenderer and configure it
            lineRenderer = GetComponent<LineRenderer>();
            // lineRenderer.startColor = Color.white;
            // lineRenderer.endColor = Color.white;
            // lineRenderer.startWidth = 0.05f;
            // lineRenderer.endWidth = 0.05f;
            // lineRenderer.positionCount = 2; 
        }
        
        
        // PlayerInput input = FindObjectOfType<PlayerInput>();
        // Debug.Log(input.currentControlScheme);
        // for(int i = 0; i < Gamepad.all.Count; i++)
        // {
        //     Debug.Log(Gamepad.all[i].name);
        // }
    }

    public void MoveObject(InputAction.CallbackContext context)
    {
        
        moveValue = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
        
        //Y Vector Space Value
        // _playerVelocity.y += GravityValue * Time.deltaTime;
        // //Relative movement, not absolute, 3D vector Space movement
        // _controller.Move(_playerVelocity * Time.deltaTime);
    }

    private void ActuallyMoveObj()
    {
        _controller.Move(Time.deltaTime * playerSpeed * moveValue);
        
        if (moveValue != Vector3.zero)
        {
            //moves the literal gameObject associated with this script
            gameObject.transform.forward = moveValue;
        }
    }

    // public void MoveTank(InputAction.CallbackContext context)
    // {
    //     Vector3 moveChar = new Vector3(_moveAction.ReadValue<Vector2>().x, 0, _moveAction.ReadValue<Vector2>().y);
    //     _controller.Move(Time.deltaTime * playerSpeed * moveChar);
    //     
    //     if (moveChar != Vector3.zero)
    //     {
    //         //moves the literal gameObject associated with this script
    //         gameObject.transform.forward = moveChar;
    //     }
    //     //Y Vector Space Value
    //     _playerVelocity.y += GravityValue * Time.deltaTime;
    //     //Relative movement, not absolute, 3D vector Space movement
    //     _controller.Move(_playerVelocity * Time.deltaTime);
    // }
    //
    public void MoveCrosshair(InputAction.CallbackContext context)
    {
        //TODO: EXPLAIN WHY THIS WORKS
        moveCharCrosshair = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
       
    }

    private void ActuallyMoveCrosshair()
    {
        if (moveCharCrosshair != Vector3.zero)
        {
            // Convert input into a direction vector appropriate for movement
            Vector3 moveDirection = new Vector3(moveCharCrosshair.x, 0, moveCharCrosshair.z) * playerSpeed;
            associatedCrosshair.transform.position += moveDirection * Time.deltaTime; // Move associatedCrosshair
        }
    }
    
    
    void UpdateLineRenderer()
    {
        if (lineRenderer != null && associatedCrosshair != null)
        {
            // Set the positions for the line renderer
            lineRenderer.SetPosition(0, transform.position);
            //start_vector = transform.position;
            lineRenderer.SetPosition(1, associatedCrosshair.transform.position);
            //end_vector = associatedCrosshair.transform.position;
            
            
        }
    }
    
    void Update()
    {
        //MoveTank();
        //MoveCrosshair();
        ActuallyMoveObj();
        ActuallyMoveCrosshair();
        if (GameConstants.Debug)
        {
            UpdateLineRenderer();
        }

        update_bullets();

    }
    
    private void update_bullets()
    {
        List<int> indices = new List<int>();
        foreach (bullet bullet in this.bullets)
        {

            
            if (!bounds.Contains(bullet.get_position()))
            {
                indices.Add(this.bullets.IndexOf(bullet));
            }
            else
            {
                Debug.Log("updating");

                bullet.move();
            }
            
        }

        foreach (int index in indices)
        {
            this.bullets[index].delete();
            this.bullets.RemoveAt(index);

        }
    }

}
