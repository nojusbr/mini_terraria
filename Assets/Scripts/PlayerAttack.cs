using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool canAttack;
    public GameObject sword;
    SpriteRenderer swordSprite;
    public float cooldown = 2f;
    private float cooldownTimer;

    public float destroyRadius = 2f;
    public GameObject smallerSlime;
    public AudioSource swordSound;

    private void Start()
    {
        canAttack = true;
        swordSprite = GetComponent<SpriteRenderer>();
        cooldownTimer = cooldown;
    }

    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (canAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                sword.SetActive(true);
                canAttack = false;
                cooldownTimer = cooldown;
                DestroyNearby();
                swordSound.Play();
            }
        }
        else
        {
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0)
            {
                sword.SetActive(false);
                canAttack = true;
            }
        }

        var h = Input.GetAxisRaw("Horizontal");
        if (h != 0)
        {
            swordSprite.flipX = h < 0;

            float angle = (h < 0) ? 180f : 0f;
            sword.transform.rotation = Quaternion.Euler(angle, 0, 0);
        }

        void DestroyNearby()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, destroyRadius);

            foreach (Collider2D collider in hitColliders)
            {
                if (collider.CompareTag("Slime"))
                {
                    Vector3 spawnPosition = collider.transform.position;

                    SpawnSlime(spawnPosition);

                    Destroy(collider.gameObject);
                }

                if (collider.CompareTag("SmallerSlime"))
                {
                    Destroy(collider.gameObject);
                }
            }
        }

        void SpawnSlime(Vector3 spawnPosition)
        {
            GameObject smallerSlime1 = Instantiate(smallerSlime, spawnPosition + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
            GameObject smallerSlime2 = Instantiate(smallerSlime, spawnPosition + new Vector3(-0.5f, -0.5f, 0), Quaternion.identity);
        }
    }
}
