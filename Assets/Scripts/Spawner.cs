using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject slime;
    public Transform spawnPoint;
    public float cooldown = 3f;

    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            Instantiate(slime, transform.position, Quaternion.identity);
            cooldown = 3f;
        }
    }
}
