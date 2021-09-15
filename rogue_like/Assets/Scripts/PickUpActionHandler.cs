using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpActionHandler : MonoBehaviour
{
    public GameObject weaponPrefab;

    private WeaponHolderController weaponHolderController;
    private bool pickUpAllowed;


    void Start()
    {
        weaponHolderController = GameObject.Find("Player").GetComponent<WeaponHolderController>();
    }


    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.F))
            PickUp();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpAllowed = false;
        }
    }


    private void PickUp()
    {
        weaponHolderController.PickUpWeapon(weaponPrefab);
        gameObject.SetActive(false);
        Destroy(gameObject, 3f);
    }

}
