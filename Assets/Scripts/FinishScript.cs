using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    int zaman = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Animator anim = new Animator();
    // Update is called once per frame
    void Update()
    {
        zaman++;
        anim.SetInteger("zaman", zaman);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("velet"))
        {
            Debug.Log("DEÐDÝ");
            
        }
    }
}
