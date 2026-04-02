using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _keyRight = KeyCode.D;
    [SerializeField] private KeyCode _keyLeft = KeyCode.A;
    [SerializeField] private KeyCode _keyRun = KeyCode.LeftShift;
    [SerializeField] private KeyCode _keyJump = KeyCode.Space;

    public event Action<float> HorizontalMovementStarted;
    public event Action<float> HorizontalFastMovementStarted;
    public event Action VertiсalMovementStarted;

    private float _moveRight = 1f;
    private float _moveLeft = -1f;
    private float _idle = 0f;

    private void Update()
    {
        if (Input.GetKey(_keyRun) && Input.GetKey(_keyRight))
        {
            HorizontalFastMovementStarted?.Invoke(_moveRight);
        }
        else if (Input.GetKey(_keyRight))
        {
            HorizontalMovementStarted?.Invoke(_moveRight);
        }
        else if (Input.GetKey(_keyRun) && Input.GetKey(_keyLeft))
        {
            HorizontalFastMovementStarted?.Invoke(_moveLeft);
        }
        else if (Input.GetKey(_keyLeft))
        {
            HorizontalMovementStarted?.Invoke(_moveLeft);
        }
        else
        {
            HorizontalMovementStarted?.Invoke(_idle);
        }

        if (Input.GetKey(_keyJump) )
        {
            VertiсalMovementStarted?.Invoke();
        }
    }
}