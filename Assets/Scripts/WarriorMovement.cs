using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMovement : MonoBehaviour
{
    public float movementSpeed = 1;
    public float jumpForce = 20;
    public float horizontalMove = 0f;
    public Animator _animator = new Animator();
    private Rigidbody2D _rigidbody;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
       
        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            _animator.SetBool("isJumping", true);
        }
        _animator.SetFloat("speed", Mathf.Abs(horizontalMove));
          if(Input.GetKey(KeyCode.A))
           {
               _spriteRenderer.flipX = true;
           }
           else if(Input.GetKey(KeyCode.D))
           {
               _spriteRenderer.flipX = false;
           }
     
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zemin")
        {
            _animator.SetBool("isJumping", false);
        }
    }
   
}
