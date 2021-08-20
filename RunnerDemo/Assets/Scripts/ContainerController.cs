using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerController : MonoBehaviour
{
    public float speed = 2.5f;
    public List<Transform> platforms = new List<Transform>();
    private bool _isMoving;
    private float _endPoint;
    
    private void Start()
    {
        _endPoint = WorldBuilder.Instance._destroyPoint.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NewPlatform()
    {
        Destroy(platforms[0].gameObject);
        platforms.RemoveAt(0);
        WorldBuilder.Instance.CreatePlatform();
    }

    public void AddPlatformToList(GameObject platform)
    {
        platforms.Add(platform.transform);
    }

    public void MovePlatforms()
    {
        transform.position -= Vector3.forward * speed * Time.deltaTime;
        if (platforms[0].position.z <= _endPoint)
        {
            NewPlatform();
        } 
    }
}
