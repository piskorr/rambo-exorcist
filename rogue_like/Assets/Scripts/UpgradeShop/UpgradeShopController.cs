using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeShopController : MonoBehaviour
{

    [SerializeField]
    private Text MaxOrbCountText;

    public int MaxOrbCountUpgrade = 1;

    [SerializeField]
    private Text OrbShootStrengthText;

    public float OrbShootStrengthMultiplierUpgrade = 1.5f;

    [SerializeField]
    private Text OrbRespawnCooldownText;

    public float OrbRespawnCooldownMultiplierUpgrade = 0.8f;

    [SerializeField]
    private Text CoinText;

    [SerializeField]
    private int UpgradeCost = 3;


    // // Start is called before the first frame update
    // void Start()
    // {

    //     this.gameObject.SetActive(false);
    //     MaxOrbCountText.text = OrbGun.MaxOrbCount.ToString();
    //     OrbShootStrengthText.text = OrbGun.OrbShootStrength.ToString();
    //     OrbRespawnCooldownText.text = OrbGun.OrbRespawnCooldown.ToString();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     CoinText.text = ScoreTextScript.coinCount.ToString();
    // }


    // public void TryUpgradeMaxOrbCount()
    // {
    //     if (TryBuyUpgrade())
    //         {
    //             OrbGun.MaxOrbCount += MaxOrbCountUpgrade;
    //             MaxOrbCountText.text = OrbGun.MaxOrbCount.ToString();
    //         }
    // }


    // public void TryUpgradeOrbShootStrength()
    // {
    //     if (TryBuyUpgrade())
    //         {
    //             OrbGun.OrbShootStrength *= OrbShootStrengthMultiplierUpgrade;
    //             OrbShootStrengthText.text = OrbGun.OrbShootStrength.ToString();
    //         }
    // }


    // public void TryUpgradeOrbRespawnCooldown()
    // {
    //     if (TryBuyUpgrade())
    //         {
    //             OrbGun.OrbRespawnCooldown *= OrbRespawnCooldownMultiplierUpgrade;
    //             OrbRespawnCooldownText.text = OrbGun.OrbRespawnCooldown.ToString();
    //         }
    // }


    // private bool TryBuyUpgrade()
    // {
    //     if (ScoreTextScript.coinCount >= UpgradeCost)
    //     {
    //         ScoreTextScript.coinCount -= UpgradeCost;
    //         return true;
    //     }

    //     return false;
    // }


    // public void ExitUpgradeShop()
    // {
    //     Time.timeScale = 1f;
    //     SetOtherUIActiveStatus(true);
    //     this.gameObject.SetActive(false);        
    // }


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
