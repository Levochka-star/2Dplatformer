using UnityEngine;

public class Patroller : MonoBehaviour
{
    [Tooltip("Вставьте сюда объект расположением которого будет правая граница перемещения")]
    [SerializeField] Transform _targetStart;
    [Tooltip("Вставьте сюда объект расположением которого будет левая граница перемещения")]
    [SerializeField] Transform _targetEnd;
    [SerializeField] Rotator _rotator;
 
    [SerializeField] private float _speedMove = 1f;

    private bool _isArrived;

    private void Start()
    {
        _isArrived = false;
    }

    private void Update()
    {
        if (_isArrived == false)
        {
            Work(_targetStart, false);
        }
        else if (_isArrived)
        {
            Work(_targetEnd, true);
        }
    }

    private void Work(Transform target, bool isArrived)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, _speedMove * Time.deltaTime);

        if ((transform.position - target.position).sqrMagnitude < 1f)
        {
            if (isArrived != true)
            {
                _isArrived = true;
                _rotator.LefttRotation();
            }
            else if (isArrived)
            {
                _isArrived = false;
                _rotator.RightRotation();
            }
        }
    }
}