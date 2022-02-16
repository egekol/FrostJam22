using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Monkee monkee;
    [SerializeField] private List<Transform> spawnPointList;
    public static EnemyManager instance;
    private int waveCount=20;
    public float spawnDelay = 1f;
    private int _waveLevel;
    [SerializeField] private List<int> waveCountList;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    public void GameStart()
    {
        Wave = PlayerPrefs.GetInt("WaveLevel");
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (waveCount>0)
        {
            Instantiate(monkee, spawnPointList[Random.Range(0, spawnPointList.Count - 1)].position,
                quaternion.identity);
            waveCount--;
            yield return new WaitForSeconds(spawnDelay);
        }

        // if (waveCount ==0)
        // {
        //     
        //     yield return new WaitForSeconds(5f);
        //     Wave++;
        // }
    }

    public int Wave {
        get =>_waveLevel;
        set
        {
            _waveLevel = value;
            PlayerPrefs.SetInt("WaveLevel",value);
            ResetWaveCounts();
            UIManager.instance.StartCoroutine();
            StartCoroutine(SpawnEnemy());
        }
    }

    private void ResetWaveCounts()
    {
        waveCount = waveCountList[0]+_waveLevel*5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckEnemyCount()
    {
        var count = FindObjectsOfType<Monkee>();
        Debug.Log("Count:" + count.Length);
        if (count.Length == 1)
        {
            Debug.Log("WaveEnded");
            Wave++;
        }
    }
}
