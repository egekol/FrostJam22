using System;
using UnityEngine;

namespace UnityTemplateProjects.GamePlay
{
    public class Bullet : MonoBehaviour
    {
        public Vector3 projectile;
        private Vector3 rbSpeed;

        private void Start()
        {
            // rbSpeed = PlayerManager.instance.playerMovement.rb.velocity* Time.deltaTime;
        }

        private void Update()
        {
            var speed = PlayerManager.instance.bulletSpeed * Time.deltaTime;
            
            transform.Translate(projectile.normalized*speed);
        }
    }
}