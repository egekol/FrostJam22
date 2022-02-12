using System.Collections;
using System.Collections.Generic;
using _Main.Scripts.GamePlay;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;
    public PlayerAnimationController playerAnimationController;
    public PlayerMovement playerMovement; 
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimationController = GetComponent<PlayerAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
