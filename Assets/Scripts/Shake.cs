using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float duration = 1f;
    public AnimationCurve curve;
    

    public void Shaker()
    {
        StartCoroutine(shaking());
    }

    public IEnumerator shaking()
    {
        Vector3 startpos = transform.position;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float strength = curve.Evaluate(time / duration);
            transform.position = startpos + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startpos;
    }
}
