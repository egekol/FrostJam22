using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityTemplateProjects.GamePlay;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtTartget();
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
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
