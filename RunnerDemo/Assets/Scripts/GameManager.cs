using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static private GameManager _Instance;
    static public GameManager Instance
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

    [SerializeField] private GameObject _finishPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _finishPanel.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EndLevel()
    {
        _finishPanel.SetActive(true);
    }
}
