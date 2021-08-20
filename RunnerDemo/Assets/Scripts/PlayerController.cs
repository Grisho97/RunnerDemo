using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float distance = 10f;
    [SerializeField] private float _horizontalSpeed;
    private Transform _playerTransform;
    private Camera _mainCamera;
    private Animator _animator;
    private void Awake()
    {
        _playerTransform = this.transform;
        _mainCamera = Camera.main;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _animator.SetBool("Run",true);
            Move();
        }
        else
        {
            _animator.SetBool("Run",false);
        }
    }

    private void Move()
    {
        WorldBuilder.Instance.MovePlatforms();
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 worldPointPosition = Camera.main.ScreenToWorldPoint(mousePosition); 
        Vector3 destination = new Vector3( worldPointPosition.x, _playerTransform.position.y, _playerTransform.position.z );

        _playerTransform.position =
            Vector3.MoveTowards(_playerTransform.position, destination, _horizontalSpeed * Time.deltaTime);
        
        //Setlimits
        Vector3 pos = _playerTransform.position;
        pos.x = Mathf.Clamp (pos.x, -5, 5);
        _playerTransform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinalPlatform")
        {
            GameManager.Instance.EndLevel();
        }

        if (other.tag == "Coin")
        {
            CoinsManager.Instance.CountCoin();
        }
    }
}
