using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NatureHealth : MonoBehaviour, I_SmartwallInteractable
{
    public int maxHealth = 5;
    public int currentHealth;

    [SerializeField] public Renderer thisPlanet;

    
    [SerializeField] public Material geelKleur;
    [SerializeField] public Material oranjeKleur;
    [SerializeField] public Material roodKleur;

    public Slider staminaBar;

    private Coroutine regen;

    public float maxStamina = 1000f;
    public float currentStamina;
    public float startStamina;
    public float minStamina = 0;

    public static NatureHealth instance;

    public GameObject shieldObject;
    public bool shieldIsAan;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = 5;

        currentStamina = startStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = startStamina;

        shieldIsAan = false;
    }

    public void UseStamina(int amount)
    {
        if (currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;


            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(deployStamina());

        }
        else
        {
            Debug.Log("Not enough stamina");
        }
    }

    public void getStamina(int amount)
    {
        if (currentStamina - amount <= maxStamina)
        {
            currentStamina += amount;
            staminaBar.value = currentStamina;
        }
        else
        {
            Debug.Log("Not enough stamina");
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 4)
        {
            thisPlanet.material = geelKleur;
        }

        if (currentHealth <= 3)
        {
            thisPlanet.material = oranjeKleur;
        }

        if (currentHealth <= 2)
        {
            thisPlanet.material = roodKleur;
        }

    
    }

    public void heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Hit(Vector3 hitPosition)
    {
        Debug.Log("Hallo");
        shieldObject.SetActive(true);
        StartCoroutine(deployStamina());

    }

    // Update is called once per frame
    void Update()
    {
        if (currentStamina == 0 || currentStamina < 0)
        {
            shieldObject.SetActive(false);
        }

       
    }

    private IEnumerator deployStamina()
    {
        yield return new WaitForSeconds(0.1f);

        while (currentStamina > minStamina)
        {
            currentStamina -= maxStamina / 300f;
            staminaBar.value = currentStamina;
            yield return new WaitForSeconds(0.1f);
        }
        regen = null;
    }
}

