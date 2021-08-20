using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CoinsManager : MonoBehaviour
{
    private static CoinsManager _instance;
     
    public static CoinsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("error");
            }
     
            return _instance;
        }
    }
    
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _coinsContainer;
    [SerializeField] private List<GameObject> _listOfCoins;

    [SerializeField] private List<Transform> _coinsPositions;
    [SerializeField] private Text _coinCounterText;
    private int _coinCounter = 0;

    public void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _listOfCoins = GenarateCoins(5);
        _coinCounterText.text = _coinCounter.ToString();
    }

    List<GameObject> GenarateCoins(int ammountOfCoins)
    {
        for (int i = 0; i < ammountOfCoins; i++)
        {
            GameObject coin = Instantiate(_coinPrefab);
            coin.transform.parent = _coinsContainer.transform;
            coin.SetActive(false);
            _listOfCoins.Add(coin);
        }
        
        return _listOfCoins;
    }

    public GameObject RequestCoin()
    {
        foreach (var bull in _listOfCoins)
        {
            if (bull.activeInHierarchy == false)
            {
                bull.SetActive(true);
                return bull;
            }
        }
        GameObject newCoin = Instantiate(_coinPrefab);
        newCoin.transform.parent = _coinsContainer.transform;
        _listOfCoins.Add(newCoin);
        return newCoin;
    }

    public void GanarateCoin()
    {
        
        int posNum = Random.Range(0, _coinsPositions.Count);
        if (_coinsPositions[posNum] != null)
        {
            var coin = RequestCoin();
            coin.transform.position = _coinsPositions[posNum].position;
        }
    }

    public void CountCoin()
    {
        _coinCounter++;
        _coinCounterText.text = _coinCounter.ToString();
    }
}
