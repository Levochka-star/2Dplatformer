using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AnimationPlayerSwitch))]
public class Mover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Transform _radiusLegs;
    [SerializeField] private LayerMask _layerGround;
    [SerializeField] private Rotator _rotator;

    [SerializeField] private float _speedMove = 7f;
    [SerializeField] private float _speedFastMove = 14f;
    [SerializeField] private float _acceleration = 4.5f;

    private Rigidbody2D _rigidBody;
    private AnimationPlayerSwitch _animationPlayerSwitch;

    private Vector2 _targetVelocity;

    private float _airSpeedDivider = 2f;
    private float _moveX;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animationPlayerSwitch = GetComponent<AnimationPlayerSwitch>();
    }

    private void OnEnable()
    {
        _inputReader.HorizontalMovementStarted += Move;
        _inputReader.HorizontalFastMovementStarted += FastMove;
    }

    private void OnDisable()
    {
        _inputReader.HorizontalMovementStarted -= Move;
        _inputReader.HorizontalFastMovementStarted -= FastMove;
    }

    private void FixedUpdate()
    {
        if (_moveX > 0)
        {
            _rotator.RightRotation();
        }
        else if (_moveX < 0)
        {
            _rotator.LefttRotation();
        }

        _rigidBody.velocity = Vector2.Lerp(_rigidBody.velocity, _targetVelocity, _acceleration * Time.deltaTime);
    }

    private void Move(float moveX)
    {
        _moveX = moveX;

        float radius = 0.3f;

        GetMoving(radius, _speedMove);

        if (moveX == 0)
        {
            _animationPlayerSwitch.OffPlayerWalk();
            _animationPlayerSwitch.OffPlayerRun();
        }
        else
        {
            _animationPlayerSwitch.OnPlayerWalk();
            _animationPlayerSwitch.OffPlayerRun();
        }
    }

    private void FastMove(float moveX)
    {
        _moveX = moveX;

        float radius = 0.1f;

        _animationPlayerSwitch.OnPlayerRun();
        GetMoving(radius, _speedFastMove);
    }

    private void GetMoving(float radiusOverlap, float speedMove)
    {
        if (Physics2D.OverlapCircle(_radiusLegs.position, radiusOverlap, _layerGround))
        {
            _targetVelocity = new Vector2(_moveX * speedMove, _rigidBody.velocity.y);
        }
        else
        {
            float speed = _speedMove / _airSpeedDivider;
            _targetVelocity = new Vector2(_moveX * speed, _rigidBody.velocity.y);
        }
    }
}