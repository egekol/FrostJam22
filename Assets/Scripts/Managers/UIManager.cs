using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static UIManager instance;

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

    public void StartCoroutine()
    {
        StartCoroutine(ShowWaveText());
    }

    public IEnumerator ShowWaveText()
    {
        waveText.gameObject.SetActive(true);
        waveText.text = "WAVE:\n" +
                        EnemyManager.instance.Wave;
        yield return new WaitForSeconds(5f);
        waveText.gameObject.SetActive(false);

    }

    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }public void CLoseLoseScreen()
    {
        loseScreen.SetActive(false);
    }
    
}
