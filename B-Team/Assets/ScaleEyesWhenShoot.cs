using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEyesWhenShoot : MonoBehaviour
{
    private Vector3 startScale;
    public AnimationCurve aC;
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;   
    }

    // Update is called once per frame
    void Update()
    {   

    }
    public void StartEyeScaleRoutine()
    {
        StartCoroutine(EyeScaler());
    }
    IEnumerator EyeScaler()
    {
        float t = 0;
        while (t < aC.keys[aC.length - 1].time)
        {
            transform.localScale = Vector3.Lerp(startScale, startScale * 2, aC.Evaluate(t));
            t += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
