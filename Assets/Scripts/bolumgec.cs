using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bolumgec : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private Scene _scene;
    // Update is called once per frame
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Karakter"))
        {
            SceneManager.LoadScene(_scene.buildIndex + 1);
        }
    }
}
