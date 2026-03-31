using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Transform _radiusLegs;
    [SerializeField] private LayerMask _layerGround;
    [SerializeField] private float _jumpForce = 10f;

    private Rigidbody2D _rigidBody;

    public event Action Jumping;

    private void OnEnable()
    {
        _inputReader.VertiсalMovementStarted += OnJump;
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        _inputReader.VertiсalMovementStarted -= OnJump;
    }

    private void OnJump()
    {
        float radius = 0.1f;

        if (Physics2D.OverlapCircle(_radiusLegs.position, radius, _layerGround))
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);

            Jumping?.Invoke();
        }
    }
}