using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarriorHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    [SerializeField] private Behaviour[] components;
     private Scene _scene;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        _scene = SceneManager.GetActiveScene();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
        }
        else
        {
            anim.SetTrigger("isDeath");
            SceneManager.LoadScene(_scene.name);
            
        }

    }
}