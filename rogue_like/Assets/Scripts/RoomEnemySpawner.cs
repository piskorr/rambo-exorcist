using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;
    public Vector2 spawnArea;
    public int enemyMaxNumber = 5;
    public int enemyMinNumber = 1;
    public GameObject shop;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        spawnArea.x-=2;
        spawnArea.y-=2;
        if (shop)
        {
            var sh = Instantiate(shop, transform, false);
            var script = sh.GetComponent<UpgradeShopNavigator>();
            script.UpgradeShopPanel = GameObject.Find("UI");
        }
        else if (boss)
        {
            var bossC = Instantiate(boss, transform, true);
            //bossC.transform.Translate(new Vector3(Random.Range(-spawnArea.x - bossC.transform.position.x, spawnArea.x - bossC.transform.position.x), Random.Range(-spawnArea.y - bossC.transform.position.y, spawnArea.y - bossC.transform.position.y), 1));
        }
        else
        {
            for (int i = 0; i < (int)Random.Range(enemyMinNumber, enemyMaxNumber); i++)
            {
                int enemyID = (int)Random.Range(0, enemies.Length);
                var enemy = Instantiate(enemies[enemyID], transform, false);

                enemy.transform.Translate(new Vector3(Random.Range(-spawnArea.x - enemies[enemyID].transform.position.x, spawnArea.x - enemies[enemyID].transform.position.x), Random.Range(-spawnArea.y - enemies[enemyID].transform.position.y, spawnArea.y - enemies[enemyID].transform.position.y), 0));
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
