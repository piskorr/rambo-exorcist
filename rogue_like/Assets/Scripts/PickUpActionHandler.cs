using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpActionHandler : MonoBehaviour
{
    public GameObject weaponPrefab;

    private WeaponHolderController weaponHolderController;



    void Start()
    {
        weaponHolderController = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponHolderController>();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            if(weaponHolderController.AddWeapon(weaponPrefab))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
