using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterBehaviour : EnemyBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float fireRate = 0.5f;
    public int damage = 10;

    protected float fireTimer = 0.0f;

    protected override void EnemyLogic()
    {
        animator.SetBool("isAttacking", false);
        distance = Vector2.Distance(transform.position, target.position);
        if (distance > attackDistance)
        {
            Move();
            attackMode = false;
        }
        else if (distance < attackDistance)
        {
            Flip();
            attackMode = true;
            if (Time.time > fireTimer)
            {
                animator.SetBool("isAttacking", true);
                ShootBullet();
                fireTimer = Time.time + fireRate;
            }
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x)));
        bullet.GetComponent<BulletHandler>().setDmg(damage);
        bullet.tag = "Attack";
        Vector3 velocity = target.position - transform.position;
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(velocity * bulletForce);
    }
}
