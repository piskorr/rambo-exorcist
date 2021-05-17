using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject T, TR, TL, TBR, TBL, TBRL, TRL, TB, BLR, BL, BR, B, L, LR, R;
    public int gridX, gridY, numberOfRooms;
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
    void spawnRoom(int row, int column)
    {
        if (row == 0)
        {
            if (column == 0)// lewy dolny rog
            {
                if (map[row + 1, column] == 1)
                {
                    if (map[row, column + 1] == 1)
                        Instantiate(TR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    else
                        Instantiate(T, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                }
                else
                    Instantiate(R, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
            }
            else if (column == gridX - 1)// prawy dolny rog
            {
                if (map[row + 1, column] == 1)
                {
                    if (map[row, column - 1] == 1)
                        Instantiate(TL, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    else
                        Instantiate(T, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                }
                else
                    Instantiate(L, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
            }
            else // dolna krawedz
            {
                if (map[row + 1, column] == 1)
                {
                    if (map[row, column + 1] == 1)
                    {
                        if (map[row, column - 1] == 1)
                            Instantiate(TRL, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                        else
                            Instantiate(TR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                    else if (map[row, column - 1] == 1)
                    {
                        Instantiate(TL, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(T, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                }
                else if (map[row, column + 1] == 1)
                {
                    if (map[row, column - 1] == 1)
                        Instantiate(LR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    else
                        Instantiate(R, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                }
                else
                {
                    Instantiate(L, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
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
                        Instantiate(BR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    else
                        Instantiate(B, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                }
                else
                    Instantiate(R, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
            }
            else if (column == gridX - 1)// prawy górny rog
            {
                if (map[row - 1, column] == 1)
                {
                    if (map[row, column - 1] == 1)
                        Instantiate(BL, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    else
                        Instantiate(B, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                }
                else
                    Instantiate(L, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
            }
            else // górna krawedz
            {
                if (map[row - 1, column] == 1)
                {
                    if (map[row, column + 1] == 1)
                    {
                        if (map[row, column - 1] == 1)
                            Instantiate(BLR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                        else
                            Instantiate(BR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                    else if (map[row, column - 1] == 1)
                    {
                        Instantiate(BL, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(B, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                }
                else if (map[row, column + 1] == 1)
                {
                    if (map[row, column - 1] == 1)
                        Instantiate(LR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    else
                        Instantiate(R, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                }
                else
                {
                    Instantiate(L, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
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
                            Instantiate(TBR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                        else
                            Instantiate(TB, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                    else if (map[row, column + 1] == 1)
                    {
                        Instantiate(TR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(T, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                }
                else if (map[row - 1, column] == 1)
                {
                    if (map[row, column + 1] == 1)
                        Instantiate(BR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    else
                        Instantiate(B, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                }
                else
                    Instantiate(R, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);

            }
            else if (column == gridX - 1)
            {
                if (map[row + 1, column] == 1)
                {
                    if (map[row - 1, column] == 1)
                    {
                        if (map[row, column - 1] == 1)
                            Instantiate(TBL, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                        else
                            Instantiate(TB, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                    else if (map[row, column - 1] == 1)
                    {
                        Instantiate(TL, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(T, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                }
                else if (map[row - 1, column] == 1)
                {
                    if (map[row, column - 1] == 1)
                        Instantiate(BL, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    else
                        Instantiate(B, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                }
                else
                    Instantiate(L, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
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
                                Instantiate(TBRL, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                            else
                                Instantiate(TBR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                        }
                        else if (map[row, column - 1] == 1)
                        {
                            Instantiate(TBL, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                        }
                        else
                            Instantiate(TB, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        if (map[row, column + 1] == 1)
                        {
                            if (map[row, column - 1] == 1)
                                Instantiate(TRL, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                            else
                                Instantiate(TR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                        }
                        else if (map[row, column - 1] == 1)
                        {
                            Instantiate(TL, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                        }
                        else
                            Instantiate(T, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                }

                /////////////////////////
                else if (map[row - 1, column] == 1)
                {
                    if (map[row, column + 1] == 1)
                    {
                        if (map[row, column - 1] == 1)
                            Instantiate(BLR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                        else
                            Instantiate(BR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                    else if (map[row, column - 1] == 1)
                    {
                        Instantiate(BL, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                    else
                        Instantiate(B, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                }
                else
                {
                    if (map[row, column + 1] == 1)
                    {
                        if (map[row, column - 1] == 1)
                            Instantiate(LR, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                        else
                            Instantiate(R, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(L, new Vector3(transform.position.x + column * 20, transform.position.y + row * 20, transform.position.z), Quaternion.identity);
                    }
                }
            }
        }
    }
    //magic numbers

    (int, int) randomIndex()
    {
        int row, column;

        row = Mathf.RoundToInt(Random.value * (gridY - 1));
        column = Mathf.RoundToInt(Random.value * (gridX - 1));

        if (numOfNeighbours(row, column) == 0 || map[row, column] == 1)
            return (-1, -1);
        else
            return (row, column);
    }

    (int, int) selectiveIndex()
    {
        (int, int) index;

        int iterations = 0;

        do
        {
            index = randomIndex();
            iterations++;
        } while ((index == (-1, -1) || numOfNeighbours(index.Item1, index.Item2) > 1) && iterations < numberOfRooms * numberOfRooms);

        if (index != (-1, -1))
            return index;

        iterations = 0;
        do
        {
            index = randomIndex();
            iterations++;
        } while ((index == (-1, -1) || numOfNeighbours(index.Item1, index.Item2) > 2) && iterations < numberOfRooms * numberOfRooms);

        if (index != (-1, -1))
            return index;

        iterations = 0;
        do
        {
            index = randomIndex();
            iterations++;
        } while ((index == (-1, -1) || numOfNeighbours(index.Item1, index.Item2) > 3) && iterations < numberOfRooms * numberOfRooms);

        if (index != (-1, -1))
            return index;

        iterations = 0;
        do
        {
            index = randomIndex();
            iterations++;
        } while (index == (-1, -1)  && iterations < numberOfRooms * numberOfRooms);

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

    void Start()
    {

        if (gridX * gridY < numberOfRooms)
            numberOfRooms = gridX * gridY;

        map = new int[gridX, gridY];
        for (int i = 0; i < gridY; i++)
            for (int j = 0; j < gridY; j++)
                map[i, j] = 0;


        map[0, 0] = 1;

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
                    spawnRoom(i, j);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
