using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTrees : MonoBehaviour
{
    public GameObject tree;
    public int treeCount = 10;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    private void Start()
    {
        PlaceTrees();
    }

    void PlaceTrees()
    {
        for (int i = 0; i < treeCount; i++)
        {
            Vector2 randomPos = new Vector2(Random.Range(minBounds.x, maxBounds.x), -2.4f);
            Instantiate(tree, randomPos, Quaternion.identity);
        }
    }
}
