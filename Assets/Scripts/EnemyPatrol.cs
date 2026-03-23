using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Tooltip("Вставьте сюда объект краями которого будут границы зоны перемещения")]
    [SerializeField] Transform _zone;
    [SerializeField] private float _speedMove = 1f;

    private Vector3 _targetStart;
    private Vector3 _targetEnd;
    private Vector3 _currentPosition;
    private Quaternion _currentRotation;

    private bool _isArrived;

    private void Start()
    {
        _currentPosition = transform.position;

        _isArrived = false;
        _targetStart = _zone.position + _zone.localScale / 2;
        _targetEnd = _zone.position - _zone.localScale / 2;

        _currentPosition.x = Random.Range(_targetStart.x, _targetEnd.x);

        transform.position = _currentPosition;
    }

    private void Update()
    {
        _currentRotation = transform.rotation;
        if (_isArrived == false)
        {
            Work(_targetEnd, false);
        }
        else if (_isArrived)
        {
            Work(_targetStart, true);
        }
    }

    private void Work(Vector3 target, bool isArrived)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speedMove * Time.deltaTime);
        if (Vector2.Distance(transform.position, target) < 1f)
        {
            if (isArrived != true)
            {
                _isArrived = true;
                _currentRotation.y = -180;
            }
            else if (isArrived)
            {
                _isArrived = false;
                _currentRotation.y = 0;
                transform.rotation = _currentRotation;
            }

            transform.rotation = _currentRotation;
        }
    }
}
