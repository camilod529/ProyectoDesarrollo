using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject player;
    public Sprite spriteDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D otherObj)
    {
        if (otherObj.gameObject.name == "Player") {
            CameraControl.pause = true;
            player.GetComponent<SpriteRenderer>().sprite = spriteDead;
        }
    }
}
