using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHandler : MonoBehaviour
{

    public Transform firePoint;
    public GameObject projectilePrefab;
    public Animator weaponAnimator;
    public float fireRate = 0.0f;
    public float throwForce = 5.0f;

    private float throwTimer = 0.0f;
    private WeaponHolderController weaponHolderController;

    void Start()
    {
        weaponHolderController = GameObject.Find("Player").GetComponent<WeaponHolderController>();
    }

    void Update()
    {
//        weaponAnimator.SetBool("isThrowing", false);
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > throwTimer)
            {
                //weaponAnimator.SetBool("isThrowing", true);
                Throw();                
                throwTimer = Time.time + fireRate;
            }
        }
    }


    void Throw()
    {
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0,0,transform.eulerAngles.z));
        
        Vector3 velocity = bullet.transform.rotation * Vector3.right;
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
		rigidbody2D.AddForce(velocity * throwForce);

        weaponHolderController.DecreaseGrenadeCount();
    }
}
