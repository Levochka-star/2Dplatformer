using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _keyRight = KeyCode.D;
    [SerializeField] private KeyCode _keyLeft = KeyCode.A;
    [SerializeField] private KeyCode _keyJump = KeyCode.Space;

    public event Action<float> HorizontalMovementStarted;
    public event Action VertiсalMovementStarted;

    private void Update()
    {
        if (Input.GetKey(_keyRight))
        {
            HorizontalMovementStarted?.Invoke(1f);
        }
        else if (Input.GetKey(_keyLeft))
        {
            HorizontalMovementStarted?.Invoke(-1f);
        }

        if (Input.GetKey(_keyJump))
        {
            VertiсalMovementStarted?.Invoke();
        }
        //    else if (Input.GetKey(_keyLeft))
        //    {
        //        VertiсalMovementStarted?.Invoke(-1f);
        //    }
    }
}
