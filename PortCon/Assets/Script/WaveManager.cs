using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public static WaveManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private GameObject O_Robot;
    [SerializeField] private Transform SpawnPoint;
    // Start is called before the first frame update

    void OnEnable()
    {
        StartCoroutine(ActivationRoutine());
    }

    public void SpawnEnemy()
    {
        O_Robot = PoolManager.SharedInstance.GetPooledObject("Robot");
        if (O_Robot != null)
        {
            O_Robot.transform.position = SpawnPoint.transform.position;
            O_Robot.transform.rotation = SpawnPoint.transform.rotation;
            O_Robot.SetActive(true);
            Debug.Log("Spawning enemy");    
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ActivationRoutine()
    {
        

        yield return new WaitForSeconds(1);
        SpawnEnemy();
        yield return new WaitForSeconds(4);
        StartCoroutine(ActivationRoutine());

    }
}
