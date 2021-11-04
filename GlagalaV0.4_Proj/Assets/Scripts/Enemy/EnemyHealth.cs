using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float protectionTime;
    float Timer;
    public bool damageable = true;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (damageable == false && Timer > 0f)
        {
            Timer -= Time.deltaTime;
        }
        else if (damageable == false && Timer <= 0f)
        {
            damageable = true;
        }
    }

    public void Damage(float amount)
    {
        if (damageable)
        {
        damageable = false;
        currentHealth -= amount;
        Timer = protectionTime;
        }
    }


}
