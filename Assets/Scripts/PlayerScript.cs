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

    // Use this for initialization
    void Start () {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraControl.pause == false){

            // Movement
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.up * ms * Time.deltaTime);
            }   

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.down * ms * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.Translate(Vector3.left * (ms+20) * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.right * ms * Time.deltaTime);
            }
        }
    }

    // Update is called once after frame
    void LateUpdate(){
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        if((MainCamera.transform.position.y + screenBounds.y) >= transform.position.y)
        {
            //CameraControl.pause = true;
        }

        transform.position = viewPos;
    }

}
