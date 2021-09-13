using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : EnemyShooterBehaviour
{
    public GameObject ghostPrefab;
    public GameObject devilPrefab;
    public Transform spawnPoint;
    public Canvas healthImg;
    public HealthBar healthBar;

    protected override void Awake()
    {
        health = maxHealth;
        healthBar.SetMaxhealth(maxHealth);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>().transform;
        healthImg.enabled = true;
    }

    protected override void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
        healthBar.SetHealth(health);
        if (distance > attackDistance)
        {
            attackMode = false;
            Move();
        }
        else if (distance < attackDistance)
        {
            Flip();
            attackMode = true;
            animator.SetBool("isAttacking", false);
            if (Time.time > fireTimer)
            {
                animator.SetBool("isAttacking", true);
                switch (Random.Range(1, 4))
                {
                    case 1:

                        ShootBullet(0.2f);
                        ShootBullet(0.1f);
                        ShootBullet(0);
                        ShootBullet(-0.1f);
                        ShootBullet(-0.2f);
                        break;

                    case 2:
                        SpawnDevil();
                        break;

                    case 3:
                        SpawnGhost();
                        break;
                }
                fireTimer = Time.time + fireRate;
            }
        }
    }

    void ShootBullet(float angleModifier)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 1));
        bullet.GetComponent<BulletHandler>().setDmg(damage);
        bullet.tag = "Attack";
        Vector3 velocity = target.position - firePoint.position;
        velocity.x = velocity.x * Mathf.Cos(angleModifier) - velocity.y * Mathf.Sin(angleModifier);
        velocity.y = velocity.x * Mathf.Sin(angleModifier) + velocity.y * Mathf.Cos(angleModifier);
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();

        rigidbody2D.AddForce(velocity * bulletForce);
    }

    void SpawnGhost()
    {
        GameObject enemy = Instantiate(ghostPrefab, spawnPoint.position, Quaternion.Euler(0, 0, 1));
    }

    void SpawnDevil()
    {
        GameObject enemy = Instantiate(devilPrefab, spawnPoint.position, Quaternion.Euler(0, 0, 1));
    }
}
