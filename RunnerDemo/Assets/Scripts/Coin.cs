using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ParticleSystem _particleSystem;
    public GameObject coin;
    [SerializeField] private float _rotationSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _particleSystem.Play();
            coin.SetActive(false);
        }
        Invoke(nameof(Disactive),2);
    }

    private void Disactive()
    {
        coin.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        coin.transform.Rotate(0,0,_rotationSpeed*Time.deltaTime);

        if (transform.position.z < -10)
        {
            Disactive();
        }
    }
}
