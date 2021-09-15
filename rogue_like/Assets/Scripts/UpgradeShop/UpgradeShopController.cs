using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeShopController : MonoBehaviour
{

    [SerializeField]
    private Text UpgradeText1;

    public int UpgradeValue1 = 1;

    [SerializeField]
    private Text UpgradeText2;

    public int UpgradeValue2 = 1;

    [SerializeField]
    private Text UpgradeText3;

    public int UpgradeValue3 = 10;

    [SerializeField]
    private Text CoinText;

    [SerializeField]
    private int UpgradeCost = 10;


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        UpgradeText1.text = PlayerStats.Damage.ToString();
        UpgradeText2.text = PlayerStats.MovementSpeed.ToString();
        UpgradeText3.text = PlayerStats.MaxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = ScoreTextScript.coinCount.ToString();
    }


    public void TryUpgradeDamage()
    {
        if (TryBuyUpgrade())
        {
            PlayerStats.Damage += UpgradeValue1;
            UpgradeText1.text = PlayerStats.Damage.ToString();
        }
    }


    public void TryUpgradeMovementSpeed()
    {
        if (TryBuyUpgrade())
        {
            PlayerStats.MovementSpeed += UpgradeValue2;
            UpgradeText2.text = PlayerStats.MovementSpeed.ToString();
        }
    }


    public void TryUpgradeMaxHealth()
    {
        if (TryBuyUpgrade())
        {
            PlayerStats.MaxHealth += UpgradeValue3;
            PlayerStats.CurrentHealth += UpgradeValue3;
            UpgradeText3.text = PlayerStats.MaxHealth.ToString();
        }
    }


    private bool TryBuyUpgrade()
    {
        if (ScoreTextScript.coinCount >= UpgradeCost)
        {
            ScoreTextScript.coinCount -= UpgradeCost;
            return true;
        }

        return false;
    }


    public void ExitUpgradeShop()
    {
        Time.timeScale = 1f;
        SetOtherUIActiveStatus(true);
        this.gameObject.SetActive(false);
    }


    public void SetOtherUIActiveStatus(bool status)
    {
        GameObject Parent = transform.parent.gameObject;
        int ChildCount = Parent.transform.childCount;

        for (int i = 0; i < ChildCount; i++)
        {
            Transform _child = Parent.transform.GetChild(i);
            if (_child != this.gameObject)
            {
                _child.gameObject.SetActive(status);
            }
        }
    }
}
