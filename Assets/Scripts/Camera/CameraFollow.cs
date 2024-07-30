using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    
    Vector3 Velocity = Vector3.zero;

    public float smoothTime = .15f;


    public bool YMaxEnabled = false;
    public float YMaxValue = 0;

    public bool Yminenabled = false;
    public float YminValue = 0;

    public bool XmaxEnabled = false;
    public float XmaxValue = 0;

     public bool Xminenabled = false;
    public float XminValue = 0;
    //public BoxCollider2D boundBox;
    //private Vector3 miniBounds;
    //private Vector3 maxBounds;

    //private Camera Thecamera;
    //private float halfHeight;
    //private float halfWidth;
    // Start is called before the first frame update
    void Start()
    {
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        //miniBounds = boundBox.bounds.min;
       // maxBounds = boundBox.bounds.max;

       // Thecamera = GetComponent<Camera>();
       // halfHeight = Thecamera.orthographicSize;
        //halfWidth = halfWidth * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        Vector3 targetPos = target.position;

        if (Yminenabled && YMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YminValue, YMaxValue);
        }
        else if (Yminenabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YminValue, target.position.y);

        }
        else if (YMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, YMaxValue);



        if (Xminenabled && XmaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XminValue, XmaxValue);
        }
        else if (Xminenabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XminValue, target.position.x);

        }
        else if (XmaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, XmaxValue);


        targetPos.z = transform.position.z;

       


        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref Velocity,smoothTime);

       // float clampedX = Mathf.Clamp(transform.position.x, miniBounds.x + halfWidth, maxBounds.x - halfWidth);
       // float clampedY = Mathf.Clamp(transform.position.y, miniBounds.y + halfHeight, maxBounds.y - halfHeight);
        //transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    // Update is called once per frame
    //void lateUpdate()
    //{
    //    Vector3 temp = transform.position;

    //    temp.x = playerTransform.position.x;
    //    temp.y = playerTransform.position.y;

    //    transform.position = temp;
    //}
}
