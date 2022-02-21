using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoyuAttack : MonoBehaviour
{   
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float attackRange;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D _collider;   
    [SerializeField] private LayerMask _mask;
    [SerializeField] private AudioClip swordS;
    private WarriorHealth playerHealth;

    private float cooldownTimer = Mathf.Infinity;
    private Animator _anima;
    private EnemyPatrol _patrol;
    private void Start() 
    {
        _collider = GetComponent<BoxCollider2D>();
        _anima = GetComponent<Animator>();
        _patrol = GetComponent<EnemyPatrol>();
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
            SoundManager.instance.PlaySound(swordS);
            }
        }
        if (_patrol != null)
            _patrol.enabled = !PlayerInsight();
    }
    public bool PlayerInsight()
    {
        RaycastHit2D hit = 
        Physics2D.BoxCast(_collider.bounds.center + transform.right * attackRange * -(transform.localScale.x) * colliderDistance, 
        new Vector3(_collider.bounds.size.x * attackRange, _collider.bounds.size.y, _collider.bounds.size.z), 
        0, Vector2.left, 0,_mask);
        if(hit.collider != null)
        playerHealth = hit.transform.GetComponent<WarriorHealth>();
      
        return hit.collider != null;

       

    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_collider.bounds.center + transform.right * attackRange * -(transform.localScale.x) * colliderDistance
        ,new Vector3(_collider.bounds.size.x * attackRange, _collider.bounds.size.y, _collider.bounds.size.z));
    }
    private void DamagePlayer()
    {
        if(PlayerInsight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
