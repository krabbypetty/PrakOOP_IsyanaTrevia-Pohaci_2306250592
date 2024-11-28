using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder; 
    private Weapon weapon;

    private void Awake()
    {
        if (weaponHolder != null)
        {
            weapon = Instantiate(weaponHolder);
            Debug.Log("Weapon instantiated successfully.");
        }
        else
        {
            Debug.LogError("WeaponHolder is not assigned in the Inspector!");
        }
    }

    private void Start()
    {
        if (weapon != null)
        {
            TurnVisual(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player picked up weapon");

            if (weapon != null)
            {
                weapon.transform.SetParent(collision.gameObject.transform, false);
                TurnVisual(true);
            }
            else
            {
                Debug.LogError("Weapon is null! Please check the weaponHolder assignment.");
            }
        }
    }

    private void TurnVisual(bool on)
    {
        if (weapon != null)
        {
            TurnVisual(on, weapon);
        }
    }

    private void TurnVisual(bool on, Weapon weapon)
    {
        if (weapon.GetComponent<SpriteRenderer>() != null)
            weapon.GetComponent<SpriteRenderer>().enabled = on;
        else
            Debug.LogWarning("SpriteRenderer not found on Weapon!");

        if (weapon.GetComponent<Weapon>() != null)
            weapon.GetComponent<Weapon>().enabled = on;
        else
            Debug.LogWarning("Weapon script not found on Weapon!");

        if (weapon.GetComponent<Animator>() != null)
            weapon.GetComponent<Animator>().enabled = on;
        else
            Debug.LogWarning("Animator not found on Weapon!");
    }
}
