using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    private void Start()
    {
        _mover.PlayerTurning += Rotation;
    }

    private void OnDestroy()
    {
        _mover.PlayerTurning -= Rotation;
    }

    private void Rotation (Quaternion quaternion)
    {
        transform.localRotation = quaternion;
    }
}
