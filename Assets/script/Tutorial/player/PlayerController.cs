using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _jumpSpeed;

    private PlayerInput _playerInput;
    private GroundController _groundController;
    private Rigidbody _rigidbody;
    private bool _jumpTriggered;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _groundController = GetComponent<GroundController>();
        _rigidbody = GetComponent<Rigidbody>();

        _playerInput.OnJumpButtonPressed += JumpButtonPressed;
    }

    private void FixedUpdate()
    {
        Vector3 velocity = new Vector3(
            _playerInput.MovementInputVector.x,
            0,
            _playerInput.MovementInputVector.y)
        * _speed;

        velocity.y = _rigidbody.linearVelocity.y;

        if (_jumpTriggered)
        {
            velocity.y = _jumpSpeed;
            _jumpTriggered= false;
        }
        _rigidbody.linearVelocity = velocity;
        
    }

    private void JumpButtonPressed()
    {
        if (_groundController.IsGrounded)
        {
            _jumpTriggered = true;
        }
    }
}
