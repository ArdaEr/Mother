using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int maxHealth = 100;
    int currentHealth;
    public Animator _anim;
    [SerializeField] AudioClip withDeath;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        _anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Canım acıdı animasyonu
        _anim.SetTrigger("Hurt");
        
        
        if (currentHealth <= 0)
        {
            _anim.SetBool("isDeath", true);
            _anim.SetBool("Move", false);
            Invoke("Die",1.5f);
        }
    }
    void Die() {
        {   
            
            //Öldüm
            
            //Enemy Disable
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            SoundManager.instance.PlaySound(withDeath);
            //çocuk sahneye girsin diye animator de setbool yap ya da trigger
        }
    }

}
