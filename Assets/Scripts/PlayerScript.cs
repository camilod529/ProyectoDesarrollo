using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float ms = 6;
    public Camera MainCamera;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private SpriteRenderer mySpriteRenderer;
    public Sprite spriteDead;

    // Use this for initialization
    void Start () {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;

        mySpriteRenderer = GetComponent<SpriteRenderer>();
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraControl.pause == false){

            // Movement
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * ms * Time.deltaTime);
            }   
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * ms * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * ms * Time.deltaTime);
                mySpriteRenderer.flipX = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * ms * Time.deltaTime);
                mySpriteRenderer.flipX = true;
            }
        }
    }

    // Update is called once after frame
    void LateUpdate(){
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        if((MainCamera.transform.position.y + screenBounds.y) >= transform.position.y)
        {
            CameraControl.pause = true;
            mySpriteRenderer.sprite = spriteDead;
        }

        transform.position = viewPos;
    }

}
