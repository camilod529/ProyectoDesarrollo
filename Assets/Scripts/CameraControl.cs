using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private float speed = 0.04f;
    public Transform bg1;
    public Transform bg2;
    private float bgSize;
    public static bool pause = false;
    private int startInt = 0;


    // Start is called before the first frame update
    void Start()
    {
        bgSize = 40.96f;
    }

    // Update is called once per frame
    void Update()
    {
        if(startInt > 1500)
        {
            if (pause == false)
            {
                // Camera
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPos, 0.2f);

                // Background
                if(transform.position.y >= bg2.position.y)
                {
                    bg1.position = new Vector3(bg1.position.x, bg2.position.y+ bgSize, bg1.position.z);
                    SwitchBg();
                }
            }
        }
        else
        {
            startInt = startInt + 1;
        }
    }

    private void SwitchBg()
    {
        Transform aux = bg1;
        bg1 = bg2;
        bg2 = aux;
    }
}
