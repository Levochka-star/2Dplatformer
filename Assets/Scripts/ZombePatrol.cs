using UnityEngine;

public class ZombePatrol : MonoBehaviour
{
    [Tooltip("Вставьте сюда объект расположением которого будет правая граница перемещения")]
    [SerializeField] Transform _targetStart;
    [Tooltip("Вставьте сюда объект расположением которого будет левая граница перемещения")]
    [SerializeField] Transform _targetEnd;

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

        if (Vector2.Distance(transform.position, target.position) < 1f)
        {
            if (isArrived != true)
            {
                _isArrived = true;
                transform.rotation = Quaternion.Euler(0, -180f, 0); 
            }
            else if (isArrived)
            {
                _isArrived = false;
                transform.rotation = Quaternion.Euler(0, 0f, 0);
            }
        }
    }
}