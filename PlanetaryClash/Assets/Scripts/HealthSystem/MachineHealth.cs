using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineHealth : MonoBehaviour, I_SmartwallInteractable
{
    

    [SerializeField] public Renderer thisPlanet;

    [SerializeField] public Material geelKleur;
    [SerializeField] public Material oranjeKleur;
    [SerializeField] public Material roodKleur;

    public Slider staminaBar;
    public Slider healthBar;

    private Coroutine regen;

    public float maxStamina = 1000f;
    public float currentStamina;
    public float startStamina;
    public float minStamina = 0;

    public float maxHealth = 50f;
    public float currentHealth;
    public float startHealth;
    public float minHealth = 0;

    public static MachineHealth instance;

    public GameObject shieldObject;
    public bool shieldIsAan;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        

        currentStamina = startStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = startStamina;

        currentHealth = startHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = startHealth;

        shieldIsAan = false;
}

    public void UseStamina(int amount)
    {
        if(currentStamina - amount >= 0)
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
        healthBar.value = currentHealth;


        if (currentHealth <= 40f)
        {
            thisPlanet.material = geelKleur;
        }

        if (currentHealth <= 30f)
        {
            thisPlanet.material = oranjeKleur;
        }

        if (currentHealth <= 20f)
        {
            thisPlanet.material = roodKleur;
        }
    }

    public void heal(int amount)
    {
        currentHealth += amount;

        if( currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Hit(Vector3 hitPosition)
    {

        if (shieldObject.activeSelf)
        {
            shieldObject.SetActive(false);
        }
        else
        {
            Debug.Log("Hallo");
            shieldObject.SetActive(true);
            StartCoroutine(deployStamina());

        }

    }


    // Update is called once per frame
    void Update()
    {
        if(currentStamina == 0 || currentStamina < 0)
        {
            shieldObject.SetActive(false);
        }

       
    }

    private IEnumerator deployStamina()
    {
        yield return new WaitForSeconds(0.1f);

        while (currentStamina > minStamina && shieldObject.activeSelf)
        {
            currentStamina -= maxStamina / 300f;
            staminaBar.value = currentStamina;
            yield return new WaitForSeconds(0.1f);
        }
        regen = null;
    }
}
