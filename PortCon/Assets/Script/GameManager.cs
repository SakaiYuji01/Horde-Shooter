using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject WaveManager;

    // Start is called before the first frame update
    void Start()
    {
        WaveManager.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
