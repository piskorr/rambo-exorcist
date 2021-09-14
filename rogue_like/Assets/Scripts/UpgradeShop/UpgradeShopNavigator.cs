using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeShopNavigator : MonoBehaviour
{
    [SerializeField]
    private GameObject UpgradeShopPanel;
    private bool interactionAllowed = false;


    private void Awake()
    {
        if (UpgradeShopPanel == null)
        {
            UpgradeShopPanel = FindObjectOfType<UpgradeShopController>().gameObject;
        }

    }

    void Update()
    {
        if (interactionAllowed && Input.GetKeyDown(KeyCode.F))
            OpenUpgradePanel();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            interactionAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            interactionAllowed = false;
        }
    }


    private void OpenUpgradePanel()
    {
        Time.timeScale = 0f;

   
        UpgradeShopPanel.GetComponent<UpgradeShopController>().SetOtherUIActiveStatus(false);
        UpgradeShopPanel.SetActive(true);
    }
}
