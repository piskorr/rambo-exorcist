using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;
    public Vector2 spawnArea;
<<<<<<< HEAD
    public int enemyMaxNumber;
    public int enemyMinNumber;
=======
    public int enemyMaxNumber = 0;
    public int enemyMinNumber = 0;
>>>>>>> Piskor

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < (int)Random.Range(enemyMinNumber, enemyMaxNumber+1); i++)
        {
            
            int enemyID = (int)Random.Range(0, enemies.Length);
            var enemy = Instantiate(enemies[enemyID], transform, false);

           enemy.transform.Translate(new Vector3(Random.Range(-spawnArea.x - enemies[enemyID].transform.position.x, spawnArea.x - enemies[enemyID].transform.position.x), Random.Range(-spawnArea.y - enemies[enemyID].transform.position.y, spawnArea.y - enemies[enemyID].transform.position.y), 0));
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
