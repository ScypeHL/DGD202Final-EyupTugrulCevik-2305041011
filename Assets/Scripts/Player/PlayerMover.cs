using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public PlayerInput input;
    public InputActionMap mover;
    public InputAction movement;
    
    [Header("Movement Parameters")]
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [SerializeField] private float _turnSpeed;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        mover = input.actions.FindActionMap("MovePlayer");
        movement = mover.FindAction("Movement");
        _rigidbody = GetComponent<Rigidbody>();
        mover.Enable();
    }

    private void FixedUpdate()
    {
        Vector2 inputValue = movement.ReadValue<Vector2>();
        Move(inputValue);
    }

    public void Move(Vector2 direction)
    {
        float moveX = direction.x;
        float moveZ = direction.y;

        transform.Rotate(Vector3.up, moveX * _turnSpeed * Time.deltaTime, Space.World);
        
        _rigidbody.linearVelocity = transform.forward * (moveZ * MoveSpeed);
    }
}
