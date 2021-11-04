using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    public float MaxHealth = 20;
    public float currenthealth;
    public UIHealth UI;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = MaxHealth;
        UI.setMax(MaxHealth);
        UI.setHealth(currenthealth);

    }

    // Update is called once per frame
    void Update()
    {
        if (currenthealth <= 0)
        {
            Die();
        }
    }

    public void GiveDMG(float dmgAmount)
    {
        currenthealth -= dmgAmount;
        UI.setHealth(currenthealth);
    }

    public void Heal(float healtamount)
    {
        if ((currenthealth += healtamount) >= MaxHealth)
        {
            currenthealth = MaxHealth;
        }
        else
        {
            currenthealth += healtamount;
        }
        UI.setHealth(currenthealth);
    }
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
