using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHandler : MonoBehaviour
{
    enum type{shotgun, rifle};
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float fireRate = 0.5f;    
    public float minimumShootAngle = 0;
    public float maximumShootAngle = 0;
    public int weaponDamage = 0;
    [SerializeField]type gunType;
    public Animator weaponAnimator;
    
    private float fireTimer = 0.0f;

    void Update()
    {
        weaponAnimator.SetBool("isShooting", false);
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > fireTimer)
            {
                weaponAnimator.SetBool("isShooting", true);
                if(gunType == type.shotgun)
                {
                    ShootBullet();ShootBullet();ShootBullet();ShootBullet();ShootBullet();
                }
                ShootBullet();
                
                fireTimer = Time.time + fireRate;
            }
        }
    }


    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0,0,transform.eulerAngles.z + Random.Range(minimumShootAngle,maximumShootAngle)));
        bullet.GetComponent<BulletHandler>().setDmg(weaponDamage * PlayerStats.Damage);

        Vector3 velocity = bullet.transform.rotation * Vector3.right;
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
		rigidbody2D.AddForce(velocity * bulletForce);
    }
}
