using System.Collections;
using System.Collections.Generic;
using _Main.Scripts.GamePlay;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public static PlayerManager instance;
    public PlayerAnimationController playerAnimationController;
    public PlayerMovement playerMovement; 
    public Vector3 positionToLook;
    public Gun gun;

    public float bulletSpeed = 5f; 
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        playerMovement = player.GetComponent<PlayerMovement>();
        playerAnimationController = player.GetComponent<PlayerAnimationController>();
        gun = player.GetComponentInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
