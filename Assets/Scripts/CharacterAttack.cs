using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public float attackRate = 2f; 
    float nextAttackTime = 0f;
    public Animator _animator;
    private Rigidbody2D _rigidbody;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
         if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
             Attack();
             nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }
     void Attack()
    {
        //Attack Animasyonu
        _animator.SetTrigger("Attack");
        //Saldıracak Düşman
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Damage
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected() {
        if(attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        
    }

    
}
