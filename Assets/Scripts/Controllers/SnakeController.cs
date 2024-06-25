using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private List<Transform> _tails;
    [Range(0, 3)]
    [SerializeField] private float _bonesDistance;
    [SerializeField] private GameObject _bonePrefab;
    [Range(0,4)]
    [SerializeField] private float _speed;

    private Transform _transform;

    public UnityEvent OnEat;


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
       float _sqrDistance = _bonesDistance * _bonesDistance; // comparison of distances between bones 
       Vector3 _previousPosition = _transform.position;

       foreach (var bone in _tails)
       {
            if ((bone.position - _previousPosition).sqrMagnitude > _sqrDistance)
            {
                var _temp = bone.position;
                bone.position = _previousPosition;
                _previousPosition = _temp;
            }
            else
            {
                break;
            }
       }

       _transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {       
           Destroy(collision.gameObject);

           var bone = Instantiate(_bonePrefab);
            _tails.Add(bone.transform);

            if (OnEat != null)
            {
                OnEat.Invoke();
            }
        }   
    }



}
