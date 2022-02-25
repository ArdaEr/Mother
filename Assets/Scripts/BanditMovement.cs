using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditMovement : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;
    [SerializeField] private float idleDuration;
    private float idleTimer;
    [SerializeField] private Animator anim;
    public Dialogue dialogue;
    public float sure = 0;
    public int Isopen = 0;

    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void OnDisable()
    {
        anim.SetBool("Move", false);
    }

    private void Start()
    {

    }
    DialogueUI di = new DialogueUI();
    public void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
                
            else
                DirectionChange();
            
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
                   
    }
    public void Hareket()
    {
        Isopen = 1;
        Debug.Log(Isopen);
    }
    private void DirectionChange()
    {
        
        anim.SetBool("Move", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("Move", true);

        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }

}
