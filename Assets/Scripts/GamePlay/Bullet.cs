using System;
using UnityEngine;

namespace UnityTemplateProjects.GamePlay
{
    public class Bullet : MonoBehaviour
    {
        public Vector3 projectile;
        private void Start()
        {
        }

        private void Update()
        {
            var speed = PlayerManager.instance.bulletSpeed * Time.deltaTime;
            transform.Translate(projectile.normalized*speed);
        }
    }
}