using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class ManageAnimator : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _radiusLegs;
    [SerializeField] private LayerMask _layerGround;

    private float _speedMoveX;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _speedMoveX = Mathf.Abs(_rigidbody.velocity.x);

        _animator.SetFloat("Blend", _speedMoveX);

        float radius = 0.2f;

        if (Physics2D.OverlapCircle(_radiusLegs.position, radius, _layerGround))
        {
            _animator.SetBool("PushSpace", false);
        }
        else
        {
            _animator.SetBool("PushSpace", true);
        }
    }
}
