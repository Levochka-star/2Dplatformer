using UnityEngine;

public class ManageAnimator : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Animator _animator;
    [SerializeField] private Jumper _jumper;

    private void Start()
    {

        _jumper.Jumping += Jump;
        _inputReader.Walking += Walk;
        _inputReader.Runing += Run;
    }

    private void OnDestroy()
    {
        _jumper.Jumping -= Jump;
        _inputReader.Walking -= Walk;
        _inputReader.Runing -= Run;
    }

    private void Walk(bool isWalking)
    {
        _animator.SetBool("IsWalk", isWalking);
    }

    private void Run(bool isWalking)
    {
        _animator.SetBool("IsRun", isWalking);
    }

    private void Jump()
    {
        _animator.SetTrigger("IsJump");
    }
}