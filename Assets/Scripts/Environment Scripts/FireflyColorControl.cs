using UnityEngine;

public class FireflyColorControl : MonoBehaviour
{
    [SerializeField] private GameObject _fireflyBody;
    private Material _fireflyMat;

    [SerializeField] private Color fireflyColorRef;

    private bool doFireflyGlow = false;
    private bool reverseColor = false;
    private float startAlpha = 0f;

    private void Start()
    {
        if (_fireflyBody == null)
            Debug.LogError("Firefly body on " + gameObject.name + " is not set!");
        else
            doFireflyGlow = true;
            
        _fireflyMat = _fireflyBody.GetComponent<Renderer>().material;
        RandomizeStartAlpha();
    }
    private void Update()
    {
        if (doFireflyGlow)
        {
            if (_fireflyMat.color.a <= 0f)
                reverseColor = true;
            else if (_fireflyMat.color.a >= 1f)
                reverseColor = false;

            if (reverseColor)
            {
                fireflyColorRef = _fireflyMat.color;
                fireflyColorRef.a += .3f * Time.deltaTime;
                _fireflyMat.color = fireflyColorRef;
            }
            else if (!reverseColor)
            {
                fireflyColorRef = _fireflyMat.color;
                fireflyColorRef.a -= .3f * Time.deltaTime;
                _fireflyMat.color = fireflyColorRef;
            }
        }
    }

    private void RandomizeStartAlpha()
    {
        fireflyColorRef = _fireflyMat.color;
        startAlpha = Random.Range(0f, 1f);
        fireflyColorRef.a = startAlpha;
        _fireflyMat.color = fireflyColorRef;
    }
}
