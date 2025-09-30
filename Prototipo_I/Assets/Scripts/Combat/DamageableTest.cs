using UnityEngine;

public class DamageableTest : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    public int Health { get => health; set => health = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((this as IDamageable).IsDead()) Debug.Log("Ow!");
    }
}
