using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam.Follow = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
