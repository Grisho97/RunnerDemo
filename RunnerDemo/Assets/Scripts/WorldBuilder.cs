using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldBuilder : MonoBehaviour
{
    public GameObject[] freePlatform;
    public GameObject[] obstaclePlatform;
    public ContainerController containerController;
    public Transform containerTransform;
    public Transform _destroyPoint;
    public Transform _instancePoint;
    [SerializeField] private int _numberOfPlatforms;
    private int _currentNumber;
    private bool isObstacle;
    
    
    static private WorldBuilder _Instance;
    static public WorldBuilder Instance
    {
        get { return _Instance; }
        private set
        {
            if (_Instance != null)
            {
                Debug.LogWarning("Second attempt to set WorldBuilder.");
            }

            _Instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;

    }

    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CreatePlatform()
    {
        if (_currentNumber >= 0)
        {
            if (_currentNumber < _numberOfPlatforms)
            {
                CreateFreePlatform();
                CoinsManager.Instance.GanarateCoin();
                _currentNumber++;
            }
            else if (_currentNumber == _numberOfPlatforms)
            {
                CreateFinalPlatform();
                _currentNumber = -100;
            }
        }

    }

    private void CreateFreePlatform()
    {
        int index = Random.Range(0, freePlatform.Length);
        GameObject res = Instantiate(freePlatform[index], _instancePoint.position, Quaternion.identity, containerTransform);
        containerController.AddPlatformToList(res);
    }
    
    private void CreateFinalPlatform()
    {
        int index = Random.Range(0, obstaclePlatform.Length);
        GameObject res = Instantiate(obstaclePlatform[index], _instancePoint.position, Quaternion.identity, containerTransform);
        containerController.AddPlatformToList(res);
    }

    public void Init()
    {
        Vector3 startPos1 = new Vector3(_instancePoint.position.x, _instancePoint.position.y, 16);
        Vector3 startPos2 = new Vector3(_instancePoint.position.x, _instancePoint.position.y, 24);
        Vector3 startPos3 = new Vector3(_instancePoint.position.x, _instancePoint.position.y, 32);
        
        int index1 = Random.Range(0, freePlatform.Length);
        GameObject res1 = Instantiate(freePlatform[index1], startPos1, Quaternion.identity, containerTransform);
        containerController.AddPlatformToList(res1);
        
        int index2 = Random.Range(0, freePlatform.Length);
        GameObject res2 = Instantiate(freePlatform[index2], startPos2, Quaternion.identity, containerTransform);
        containerController.AddPlatformToList(res2);
        
        int index3 = Random.Range(0, freePlatform.Length);
        GameObject res3 = Instantiate(freePlatform[index2], startPos3, Quaternion.identity, containerTransform);
        containerController.AddPlatformToList(res3);
        
        CreatePlatform();
    }

    public void MovePlatforms()
    {
        containerController.MovePlatforms();
    }
}
