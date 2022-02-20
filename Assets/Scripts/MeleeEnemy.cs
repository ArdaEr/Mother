using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{   
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float attackRange;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private LayerMask _mask;
    private float cooldownTimer = Mathf.Infinity;
    private Animator _anima;

    private void Start() 
    {
        _collider = GetComponent<BoxCollider2D>();
        _anima = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
    
        //Attack only when play in sight?
        if (PlayerInsight())
        {
            if(cooldownTimer >= attackCoolDown)
            {
            //attack
            cooldownTimer = 0;
            _anima.SetTrigger("meleeAttack");
            }
        }
    }
    private bool PlayerInsight()
    {
        RaycastHit2D hit = 
        Physics2D.BoxCast(_collider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance, 
        new Vector3(_collider.bounds.size.x * attackRange, _collider.bounds.size.y, _collider.bounds.size.z), 
        0, Vector2.left, 0,_mask);
        return hit.collider != null;

    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_collider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance
        ,new Vector3(_collider.bounds.size.x * attackRange, _collider.bounds.size.y, _collider.bounds.size.z));
    }
}