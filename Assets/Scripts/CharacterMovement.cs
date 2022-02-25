using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public bool move;
    private Rigidbody2D rb;
    private Transform ball;
    [SerializeField] private DialogueUI dialogueUI;
    private SpriteRenderer _spriteRenderer;

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x,speed);
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x * 3,rb.velocity.y);
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "dusman")
        {
            if (Interactable != null)
            {
                Interactable.Interact(this);
            }           
        }
    }
}
