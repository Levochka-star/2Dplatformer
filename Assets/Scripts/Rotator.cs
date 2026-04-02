using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Quaternion _localRotationRight = Quaternion.Euler(0f, 0f, 0f);
    private Quaternion _localRotationLeft = Quaternion.Euler(0f, -180f, 0f);

    public void RightRotation ()
    {
        transform.localRotation = _localRotationRight;
    }

    public void LefttRotation ()
    {
        transform.localRotation = _localRotationLeft;
    }
}
