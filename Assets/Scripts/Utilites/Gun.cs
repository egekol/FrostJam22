using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityTemplateProjects.GamePlay;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    public float fireDelay = .5f;
    private float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtTartget();
        fireTimer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (fireTimer>fireDelay)
            {
                Fire();
                fireTimer = 0;
            }
        }
        
        
    }

    private void LookAtTartget()
    {
        transform.LookAt(PlayerManager.instance.positionToLook);
    }

    public void Fire()
    {
        var position = transform.position;
        var bullet =Instantiate(bulletPrefab, position+transform.forward.normalized, quaternion.identity);
        bullet.projectile = PlayerManager.instance.positionToLook - position;
    }
}
