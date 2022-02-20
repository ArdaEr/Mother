using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public Transform ledgeCheck;
    private bool istouching;
    public Transform wallcheck;


    private Rigidbody2D _rigidbody;
    public Animator _animator = new Animator();

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Checksurroundings()
    {
        
    }
    // Update is called once per frame
    void Update()
    {


    }
    private void OnDrawGizmoSelected()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zemin")
        {
            _animator.SetBool("isJumping", false);
        }
    }

}
