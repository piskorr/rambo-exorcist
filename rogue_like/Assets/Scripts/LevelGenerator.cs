using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject T, TR, TL, TBR, TBL, TBRL, TRL, TB, BLR, BL, BR, B, L, LR, R;
    public GameObject corridorHorizontal, corridorVertical;
    public GameObject EmptyR, EmptyT, EmptyB, EmptyL, bossStuff, shopStuff;
    public int gridX, gridY, numberOfRooms;
    public GameObject shop;
    public GameObject boss;

    GameObject[,] RoomMap;
    int[,] map;


    float randomCompare = 0.2f, randomCompareStart = 0.2f, randomCompareEnd = 0.01f;

    int numOfNeighbours(int row, int column)
    {
        int num = 0;
        if (row == 0)
        {
            if (column == 0)
            {
                num = num + map[row + 1, column] + map[row, column + 1];
            }
            else if (column == gridX - 1)
            {
                num = num + map[row + 1, column] + map[row, column - 1];
            }
            else
            {
                num = num + map[row + 1, column] + map[row, column - 1] + map[row, column + 1];
            }
        }
        else if (row == gridY - 1)
        {
            if (column == 0)
            {
                num = num + map[row - 1, column] + map[row, column + 1];
            }
            else if (column == gridX - 1)
            {
                num = num + map[row - 1, column] + map[row, column - 1];
            }
            else
            {
                num = num + map[row - 1, column] + map[row, column - 1] + map[row, column + 1];
            }
        }
        else
        {
            if (column == 0)
            {
                num = num + map[row - 1, column] + map[row, column + 1] + map[row + 1, column];
            }
            else if (column == gridX - 1)
            {
                num = num + map[row - 1, column] + map[row, column - 1] + map[row + 1, column];
            }
            else
            {
                num = num + map[row - 1, column] + map[row, column - 1] + map[row, column + 1] + map[row + 1, column];
            }
        }
        return num;
    }

    void spawnShop()
    {
        int roomDistanceX = 27;
        int roomDistanceY = 25;
        int centerX = gridX / 2;
        int centerY = gridY / 2;
        RoomEnemySpawner roomSpawner;
        (int, int) index;
        do
        {
            index = selectiveRoomIndex();
            roomSpawner = RoomMap[index.Item1, index.Item2].GetComponent(typeof(RoomEnemySpawner)) as RoomEnemySpawner;
        } while (roomSpawner.boss != null);

        int row = index.Item1;
        int column = index.Item2;

        if(row!= gridY-1)
        if (map[row + 1, column] == 1)
        {
            Destroy(RoomMap[index.Item1, index.Item2]);
            RoomMap[index.Item1, index.Item2] = Instantiate(EmptyT, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
        }
        if (column != 0)
            if (map[row, column - 1] == 1)
        {
            Destroy(RoomMap[index.Item1, index.Item2]);
            RoomMap[index.Item1, index.Item2] = Instantiate(EmptyL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
        }
        if (column != gridX-1)
            if (map[row, column + 1] == 1)
        {
            Destroy(RoomMap[index.Item1, index.Item2]);
            RoomMap[index.Item1, index.Item2] = Instantiate(EmptyR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
        }
        if (row != 0)
            if (map[row - 1, column] == 1)
        {
            Destroy(RoomMap[index.Item1, index.Item2]);
            RoomMap[index.Item1, index.Item2] = Instantiate(EmptyB, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
        }
        roomSpawner = RoomMap[index.Item1, index.Item2].GetComponent(typeof(RoomEnemySpawner)) as RoomEnemySpawner;
        roomSpawner.shop = shop;
    }
    void spawnBoss()
    {
        int roomDistanceX = 27;
        int roomDistanceY = 25;
        int centerX = gridX / 2;
        int centerY = gridY / 2;
        RoomEnemySpawner roomSpawner;
        (int, int) index;
        do
        {
            index = selectiveRoomIndex();
            roomSpawner = RoomMap[index.Item1, index.Item2].GetComponent(typeof(RoomEnemySpawner)) as RoomEnemySpawner;
        } while (roomSpawner.shop != null);
        int row = index.Item1;
        int column = index.Item2;

        if (row != gridY - 1)
            if (map[row+1, column] == 1)
        {
            Destroy(RoomMap[index.Item1, index.Item2]);
            RoomMap[index.Item1, index.Item2] = Instantiate(EmptyT, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
        }
        if (column != 0)
            if (map[row, column-1] == 1)
        {
            Destroy(RoomMap[index.Item1, index.Item2]);
            RoomMap[index.Item1, index.Item2] = Instantiate(EmptyL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
        }
        if (column != gridX - 1)
            if (map[row, column+1] == 1)
        {
            Destroy(RoomMap[index.Item1, index.Item2]);
            RoomMap[index.Item1, index.Item2] = Instantiate(EmptyR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
        }
        if (row != 0)
            if (map[row-1, column] == 1)
        {
            Destroy(RoomMap[index.Item1, index.Item2]);
            RoomMap[index.Item1, index.Item2] = Instantiate(EmptyB, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
        }
        roomSpawner = RoomMap[index.Item1, index.Item2].GetComponent(typeof(RoomEnemySpawner)) as RoomEnemySpawner;
        roomSpawner.boss = boss;

    }
    void spawnCorridor(int row, int column)
    {
        int centerX = gridX / 2;
        int centerY = gridY / 2;

        int roomDistanceX = 27;
        int roomDistanceY = 25;
        GameObject corridor = null;
        if (column < gridX - 1 && map[row, column + 1] == 1)
        {
            corridor = Instantiate(corridorHorizontal, new Vector3(transform.position.x + (column - centerX) * roomDistanceX + roomDistanceX/2 + 2, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
            corridor.transform.parent = gameObject.transform;
        }
        if (row < gridY - 1 && map[row + 1, column] == 1)
        {
            corridor = Instantiate(corridorVertical, new Vector3(transform.position.x + (column - centerX) * roomDistanceX + 6, transform.position.y + (row - centerY) * roomDistanceY +roomDistanceY/2 + 3, transform.position.z), Quaternion.identity);
            corridor.transform.parent = gameObject.transform;
        }

            
    }
    void spawnRoom(int row, int column)
    {
        int centerX = gridX / 2;
        int centerY = gridY / 2;
        int roomDistanceX = 27;
        int roomDistanceY = 25;

        if (row == 0)
        {
            if (column == 0)// lewy dolny rog
            {
                if (map[row + 1, column] == 1)
                {
                    if (map[row, column + 1] == 1)
                        RoomMap[row, column] = Instantiate(TR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    else
                        RoomMap[row, column] = Instantiate(T, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                }
                else
                    RoomMap[row, column] = Instantiate(R, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
            }
            else if (column == gridX - 1)// prawy dolny rog
            {
                if (map[row + 1, column] == 1)
                {
                    if (map[row, column - 1] == 1)
                        RoomMap[row, column] = Instantiate(TL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    else
                        RoomMap[row, column] = Instantiate(T, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                }
                else
                    RoomMap[row, column] = Instantiate(L, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
            }
            else // dolna krawedz
            {
                if (map[row + 1, column] == 1)
                {
                    if (map[row, column + 1] == 1)
                    {
                        if (map[row, column - 1] == 1)
                            RoomMap[row, column] = Instantiate(TRL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                        else
                            RoomMap[row, column] = Instantiate(TR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                    else if (map[row, column - 1] == 1)
                    {
                        RoomMap[row, column] = Instantiate(TL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        RoomMap[row, column] = Instantiate(T, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                }
                else if (map[row, column + 1] == 1)
                {
                    if (map[row, column - 1] == 1)
                        RoomMap[row, column] = Instantiate(LR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    else
                        RoomMap[row, column] = Instantiate(R, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                }
                else
                {
                    RoomMap[row, column] = Instantiate(L, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                }
            }
        }


        else if (row == gridY - 1)
        {
            if (column == 0)// lewy górny rog
            {
                if (map[row - 1, column] == 1)
                {
                    if (map[row, column + 1] == 1)
                        RoomMap[row, column] = Instantiate(BR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    else
                        RoomMap[row, column] = Instantiate(B, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                }
                else
                    RoomMap[row, column] = Instantiate(R, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
            }
            else if (column == gridX - 1)// prawy górny rog
            {
                if (map[row - 1, column] == 1)
                {
                    if (map[row, column - 1] == 1)
                        RoomMap[row, column] = Instantiate(BL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    else
                        RoomMap[row, column] = Instantiate(B, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                }
                else
                    RoomMap[row, column] = Instantiate(L, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
            }
            else // górna krawedz
            {
                if (map[row - 1, column] == 1)
                {
                    if (map[row, column + 1] == 1)
                    {
                        if (map[row, column - 1] == 1)
                            RoomMap[row, column] = Instantiate(BLR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                        else
                            RoomMap[row, column] = Instantiate(BR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                    else if (map[row, column - 1] == 1)
                    {
                        RoomMap[row, column] = Instantiate(BL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        RoomMap[row, column] = Instantiate(B, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                }
                else if (map[row, column + 1] == 1)
                {
                    if (map[row, column - 1] == 1)
                        RoomMap[row, column] = Instantiate(LR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    else
                        RoomMap[row, column] = Instantiate(R, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                }
                else
                {
                    RoomMap[row, column] = Instantiate(L, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                }
            }
        }
        else
        {
            if (column == 0)
            {
                if (map[row + 1, column] == 1)
                {
                    if (map[row - 1, column] == 1)
                    {
                        if (map[row, column + 1] == 1)
                            RoomMap[row, column] = Instantiate(TBR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                        else
                            RoomMap[row, column] = Instantiate(TB, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                    else if (map[row, column + 1] == 1)
                    {
                        RoomMap[row, column] = Instantiate(TR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        RoomMap[row, column] = Instantiate(T, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                }
                else if (map[row - 1, column] == 1)
                {
                    if (map[row, column + 1] == 1)
                        RoomMap[row, column] = Instantiate(BR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    else
                        RoomMap[row, column] = Instantiate(B, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                }
                else
                    RoomMap[row, column] = Instantiate(R, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);

            }
            else if (column == gridX - 1)
            {
                if (map[row + 1, column] == 1)
                {
                    if (map[row - 1, column] == 1)
                    {
                        if (map[row, column - 1] == 1)
                            RoomMap[row, column] = Instantiate(TBL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                        else
                            RoomMap[row, column] = Instantiate(TB, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                    else if (map[row, column - 1] == 1)
                    {
                        RoomMap[row, column] = Instantiate(TL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        RoomMap[row, column] = Instantiate(T, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                }
                else if (map[row - 1, column] == 1)
                {
                    if (map[row, column - 1] == 1)
                        RoomMap[row, column] = Instantiate(BL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    else
                        RoomMap[row, column] = Instantiate(B, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                }
                else
                    RoomMap[row, column] = Instantiate(L, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
            }
            ////////////////////////////////////
            else
            {

                if (map[row + 1, column] == 1)
                {
                    if (map[row - 1, column] == 1)
                    {
                        if (map[row, column + 1] == 1)
                        {
                            if (map[row, column - 1] == 1)
                                RoomMap[row, column] = Instantiate(TBRL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                            else
                                RoomMap[row, column] = Instantiate(TBR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                        }
                        else if (map[row, column - 1] == 1)
                        {
                            RoomMap[row, column] = Instantiate(TBL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                        }
                        else
                            RoomMap[row, column] = Instantiate(TB, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        if (map[row, column + 1] == 1)
                        {
                            if (map[row, column - 1] == 1)
                                RoomMap[row, column] = Instantiate(TRL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                            else
                                RoomMap[row, column] = Instantiate(TR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                        }
                        else if (map[row, column - 1] == 1)
                        {
                            RoomMap[row, column] = Instantiate(TL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                        }
                        else
                            RoomMap[row, column] = Instantiate(T, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                }

                /////////////////////////
                else if (map[row - 1, column] == 1)
                {
                    if (map[row, column + 1] == 1)
                    {
                        if (map[row, column - 1] == 1)
                            RoomMap[row, column] = Instantiate(BLR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                        else
                            RoomMap[row, column] = Instantiate(BR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                    else if (map[row, column - 1] == 1)
                    {
                        RoomMap[row, column] = Instantiate(BL, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                    else
                        RoomMap[row, column] = Instantiate(B, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                }
                else
                {
                    if (map[row, column + 1] == 1)
                    {
                        if (map[row, column - 1] == 1)
                            RoomMap[row, column] = Instantiate(LR, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                        else
                            RoomMap[row, column] = Instantiate(R, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        RoomMap[row, column] = Instantiate(L, new Vector3(transform.position.x + (column - centerX) * roomDistanceX, transform.position.y + (row - centerY) * roomDistanceY, transform.position.z), Quaternion.identity);
                    }
                }
            }
        }
    }

    (int, int) randomIndex()
    {
        int row, column;
        int centerY = gridY / 2;
        int centerX = gridX / 2;
        row = Mathf.RoundToInt(Random.value * (gridY - 1));
        column = Mathf.RoundToInt(Random.value * (gridX - 1));

        if (numOfNeighbours(row, column) == 0 || map[row, column] == 1)
            return (-1, -1);
        else
            return (row, column);
    }

    (int, int) randomRoomIndex()
    {
        int row, column;
        int centerY = gridY / 2;
        int centerX = gridX / 2;
        do
        {
            row = Mathf.RoundToInt(Random.value * (gridY - 1));
            column = Mathf.RoundToInt(Random.value * (gridX - 1));
        } while (map[row, column] == 0);

        if ((row, column) == (centerY, centerX))
            return randomRoomIndex();

        return (row, column);
    }

    (int, int) selectiveRoomIndex()
    {
        (int, int) index;

        int iterations = 0;

        do
        {
            index = randomRoomIndex();
            iterations++;
        } while (numOfNeighbours(index.Item1, index.Item2) > 1);

        if (index != (-1, -1))
            return index;

        iterations = 0;
        do
        {
            index = randomRoomIndex();
            iterations++;
        } while ((index == (-1, -1) || numOfNeighbours(index.Item1, index.Item2) > 2) && iterations < gridY * gridX / 6);

        if (index != (-1, -1))
            return index;

        iterations = 0;
        do
        {
            index = randomRoomIndex();
            iterations++;
        } while ((index == (-1, -1) || numOfNeighbours(index.Item1, index.Item2) > 3) && iterations < gridY * gridX / 3);

        if (index != (-1, -1))
            return index;

        iterations = 0;
        do
        {
            index = randomRoomIndex();
            iterations++;
        } while (index == (-1, -1) && iterations < gridY * gridX);

        if (index != (-1, -1))
            return index;
        else
            return randomRoomIndex();

    }

    (int, int) selectiveIndex()
    {
        (int, int) index;

        int iterations = 0;

        do
        {
            index = randomIndex();
            iterations++;
        } while ((index == (-1, -1) || numOfNeighbours(index.Item1, index.Item2) > 1) && iterations < gridY * gridX / 8);

        if (index != (-1, -1))
            return index;

        iterations = 0;
        do
        {
            index = randomIndex();
            iterations++;
        } while ((index == (-1, -1) || numOfNeighbours(index.Item1, index.Item2) > 2) && iterations < gridY * gridX / 6);

        if (index != (-1, -1))
            return index;

        iterations = 0;
        do
        {
            index = randomIndex();
            iterations++;
        } while ((index == (-1, -1) || numOfNeighbours(index.Item1, index.Item2) > 3) && iterations < gridY * gridX / 3);

        if (index != (-1, -1))
            return index;

        iterations = 0;
        do
        {
            index = randomIndex();
            iterations++;
        } while (index == (-1, -1) && iterations < gridY * gridX);

        if (index != (-1, -1))
            return index;

        return (-1, -1);

    }


    (int, int) nextFreeIndex()
    {
        for (int i = 0; i < gridY; i++)
            for (int j = 0; j < gridY; j++)
                if (map[i, j] == 0)
                    if (numOfNeighbours(i, j) != 0)
                        return (i, j);
        return (-1, -1);
    }

    void generate()
    {
        if (gridX * gridY < numberOfRooms)
            numberOfRooms = gridX * gridY;

        RoomMap = new GameObject[gridY, gridX];
        map = new int[gridY, gridX];
        for (int i = 0; i < gridY; i++)
            for (int j = 0; j < gridX; j++)
                map[i, j] = 0;

        map[gridY / 2, gridX / 2] = 1;

        for (int i = 0; i < numberOfRooms; i++)
        {
            float randomPerc = ((float)i) / (((float)numberOfRooms - 1));
            randomCompare = Mathf.Lerp(randomCompareStart, randomCompareEnd, randomPerc);



            (int, int) index = randomIndex();

            if (index == (-1, -1) || numOfNeighbours(index.Item1, index.Item2) > 1 && Random.value > randomCompare)
                index = selectiveIndex();

            if (index == (-1, -1))
            {
                index = nextFreeIndex();
            }
            if (index == (-1, -1))
            {
                Debug.Log("Can't find suitable room");
                numberOfRooms--;
            }
            else
            {
                map[index.Item1, index.Item2] = 1;
            }
        }

        for (int i = 0; i < gridY; i++)
        {
            for (int j = 0; j < gridX; j++)
            {
                if (map[i, j] != 0)
                {
                    spawnRoom(i, j);
                    spawnCorridor(i, j);
                }
            }
        }
        spawnBoss();
        spawnShop();

        for (int i = 0; i < gridY; i++)
        {
            for (int j = 0; j < gridX; j++)
            {
                if (map[i, j] != 0)
                {
                    RoomMap[i, j].transform.parent = gameObject.transform;
                }
            }
        }
    }
    void destroyChildrensMovePlayer()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }
    void Start()
    {
        generate();
    }


    // Update is called once per frame
    void Update()
    {

    }
}
