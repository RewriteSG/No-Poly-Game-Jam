using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private PlayerInput _playerInput;

    public bool WasSelectPressed;
    public bool IsSelectDown;
    public bool WasSelectReleased;

    public bool WasMoveActionPressed;
    public bool IsMoveDown;
    public bool WasMoveActionReleased;

    public Vector2 PointerPos;

    private InputAction _selectAction;
    private InputAction _moveAction;
    private InputAction _lookAction;

    public void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.enabled = true;

        _lookAction = _playerInput.actions["Look"];

        _selectAction = _playerInput.actions["Select"];
        _moveAction = _playerInput.actions["Move"];
        

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }

    void Update()
    {
        PointerPos = Camera.main.ScreenToWorldPoint(_lookAction.ReadValue<Vector2>());
        IsSelectDown = _selectAction.IsPressed();
        WasSelectPressed = _selectAction.WasPerformedThisFrame();
        WasSelectReleased = _selectAction.WasReleasedThisFrame();

        IsMoveDown = _moveAction.IsPressed();
        WasMoveActionPressed = _moveAction.WasPerformedThisFrame();

    }
}
