using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private List<Transform> _tails;
    [SerializeField] private float _bonesDistance;
    [SerializeField] private GameObject _bonePrefab;

    [Range(0,4)]
    [SerializeField] private float _speed;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        MoveSnake(_transform.position + _transform.forward * _speed);

        float _angel = Input.GetAxis("Horizontal") * 4;
        _transform.Rotate(0, _angel, 0);
    }

    private void MoveSnake(Vector3 newPosition)
    {
        _transform.position = newPosition;
    }
}
