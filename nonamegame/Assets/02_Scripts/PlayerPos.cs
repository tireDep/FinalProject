using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private Game game;
    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        transform.position = game.lastCheckPointPos;
    }   //   Start()

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }   // Update

}   // PlyaerPos Class
