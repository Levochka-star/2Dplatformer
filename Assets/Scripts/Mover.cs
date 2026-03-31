using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Transform _radiusLegs;
    [SerializeField] private LayerMask _layerGround;

    [SerializeField] private float _speedMove = 7f;
    [SerializeField] private float _speedFastMove = 14f;
    [SerializeField] private float _acceleration = 4.5f;

    private Rigidbody2D _rigidBody;

    private Vector2 _targetVelocity;

    private Quaternion _localRotationRight = Quaternion.Euler(0f, 0f, 0f);
    private Quaternion _localRotationLeft = Quaternion.Euler(0f, -180f, 0f);

    private float _airSpeedDivider = 2f;
    private float _moveX;

    public event Action<Quaternion> PlayerTurning;
    
    private void OnEnable()
    {
        _inputReader.HorizontalMovementStarted += Move;
        _inputReader.HorizontalFastMovementStarted += FastMove;
        _rigidBody = GetComponent<Rigidbody2D>();
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
            PlayerTurning?.Invoke(_localRotationRight);
        }
        else if (_moveX < 0)
        {
            PlayerTurning?.Invoke(_localRotationLeft);
        }

        _rigidBody.velocity = Vector2.Lerp(_rigidBody.velocity, _targetVelocity, _acceleration * Time.deltaTime);
    }

    private void Move(float moveX)
    {
        _moveX = moveX;

        float radius = 0.3f;

        GetMoving(radius, _speedMove);
    }

    private void FastMove(float moveX)
    {
        _moveX = moveX;

        float radius = 0.1f;

        GetMoving(radius, _speedFastMove);
    }

    private void GetMoving(float radiusOverlap, float standartSpeedMove)
    {
        if (Physics2D.OverlapCircle(_radiusLegs.position, radiusOverlap, _layerGround))
        {
            _targetVelocity = new Vector2(_moveX * standartSpeedMove, _rigidBody.velocity.y);
        }
        else
        {
            float speedMove = _speedMove / _airSpeedDivider;
            _targetVelocity = new Vector2(_moveX * speedMove, _rigidBody.velocity.y);
        }
    }
}