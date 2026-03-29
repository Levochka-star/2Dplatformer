using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Transform _radiusLegs;
    [SerializeField] private LayerMask _layerGround;

    [SerializeField] private float _speedMove = 5f;
    [SerializeField] private float _acceleration = 6f;

    private Rigidbody2D _rigidBody;

    private Vector2 _targetVelocity;

    private Quaternion _localRotationRight = Quaternion.Euler(0f, 0f, 0f);
    private Quaternion _localRotationLeft = Quaternion.Euler(0f, -180f, 0f);

    private float _airSpeedDivider = 3.5f;
    private float _defaultMoveX = 0f;

    private void OnEnable()
    {
        _inputReader.HorizontalMovementStarted += Work;
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        _inputReader.HorizontalMovementStarted -= Work;
    }

    private void Update()
    {
        Work(_defaultMoveX);
    }

    private void Work(float moveX)
    {
        if (moveX > 0)
        {
            transform.localRotation = _localRotationRight;
        }
        else if (moveX < 0)
        {
            transform.localRotation = _localRotationLeft;
        }

        float radius = 0.1f;

        if (Physics2D.OverlapCircle(_radiusLegs.position, radius, _layerGround))
        {
            _targetVelocity = new Vector2(moveX * _speedMove, _rigidBody.velocity.y);
        }
        else
        {
            float speedMove = _speedMove / _airSpeedDivider;
            _targetVelocity = new Vector2(moveX * speedMove, _rigidBody.velocity.y);
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = Vector2.Lerp(_rigidBody.velocity, _targetVelocity, _acceleration * Time.deltaTime);
    }
}
