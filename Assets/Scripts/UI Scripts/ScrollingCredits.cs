using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCredits : MonoBehaviour
{
    [SerializeField] private bool repeat;
    [SerializeField] private int scrollSpeed;
    [SerializeField] private GameObject textToScroll;

    [SerializeField] private Canvas menuCanvas = null;

    private Rect screen;

    private void Start()
    {
        //Canvas menuCanvas = gameObject.GetComponentInParent<Canvas>();

        Vector3 canvasWorldPointZero = menuCanvas.worldCamera.ScreenToWorldPoint(Vector3.zero);
        Vector3 canvasWorldPointWH = menuCanvas.worldCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        screen = new Rect(canvasWorldPointZero, new Vector2(canvasWorldPointWH.x - canvasWorldPointZero.x, canvasWorldPointWH.y - canvasWorldPointZero.y));
    }

    private void Update()
    {
        Vector3[] wc = new Vector3[4];

        textToScroll.GetComponent<RectTransform>().GetWorldCorners(wc);

        Rect rect = new Rect(wc[0].x, wc[0].y, wc[2].x - wc[0].x, wc[2].y - wc[0].y);
        
        if (rect.Overlaps(screen))
        {
            textToScroll.transform.Translate(Vector3.up * (scrollSpeed * Time.deltaTime));
        }
    }
}
