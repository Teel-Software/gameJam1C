using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed = 5f;

    private Vector3 _movement;
    private bool _isCanMoving;

    private void Start()
    {
        StartCoroutine(GetDirection());
    }


    void Update()
    {
        if (_isCanMoving)
        {
            _animator.SetFloat("Horizontal", _movement.x);
            _animator.SetFloat("Vertical", _movement.y);
            _animator.SetFloat("Speed", _movement.sqrMagnitude);
        }
    }

    private IEnumerator GetDirection()
    {
        while (true)
        {
            _isCanMoving = false;

            var rndX = Random.Range(-1, 2);
            var rndY = 0;

            if (rndX == 0)
                rndY = Random.Range(-1, 2);

            _movement.x = rndX;
            _movement.y = rndY;

            var nextPosition = transform.position + _movement;
            if (GridController.Instance.CheckEmptyBlock(nextPosition))
            {
                _isCanMoving = true;
                yield return new WaitForSeconds(1);   
            }
            
            else _isCanMoving = false;
        }
    }

    private void FixedUpdate()
    {
        if (_isCanMoving)
            _rb.MovePosition(transform.position + _movement * (Time.deltaTime * _moveSpeed));
    }
}