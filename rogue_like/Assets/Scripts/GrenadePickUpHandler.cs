using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePickUpHandler : MonoBehaviour
{
    private WeaponHolderController weaponHolderController;
    private bool pickUpAllowed;


    void Start()
    {
        weaponHolderController = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponHolderController>();
    }


    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.F) && !weaponHolderController.isGrenadeFull())
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
        weaponHolderController.AddGrenade();
        gameObject.SetActive(false);
        Destroy(gameObject, 3f);
    }

}
