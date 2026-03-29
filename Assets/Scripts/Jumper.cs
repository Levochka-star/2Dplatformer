using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Transform _radiusLegs;
    [SerializeField] private LayerMask _layerGround;
    [SerializeField] private float _jumpForce = 10f;

    private Rigidbody2D _rigidBody;

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
            Debug.Log("На земле");
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
        }
        else
        {
            Debug.Log("Не на земле");
        }
    }
}