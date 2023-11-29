using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public TextMeshProUGUI healthText;


    public void Start()
    {
        health = maxHealth;
        healthText.text = health.ToString();
    }

    public void Update()
    {
        healthText.text = health.ToString();
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }

    }
}
