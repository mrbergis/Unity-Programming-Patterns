using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] float fullHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;
    float currentHealth = 0;

    public event Action OnHealthChange;

    private void Awake() {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }
    
    private void OnEnable() {
        GetComponent<Level>().OnLevelUpAction += ResetHealth;
    }

    private void OnDisable() {
        GetComponent<Level>().OnLevelUpAction -= ResetHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public float GetFullHealth()
    {
        return fullHealth;
    }

    void ResetHealth()
    {
        currentHealth = fullHealth;
        if (OnHealthChange != null)
        {
            OnHealthChange();
        }
    }

    private IEnumerator HealthDrain()
    {
        while (currentHealth > 0)
        {
            currentHealth -= drainPerSecond;
            if (OnHealthChange != null)
            {
                OnHealthChange();
            }
            yield return new WaitForSeconds(1);
        }
    }
}