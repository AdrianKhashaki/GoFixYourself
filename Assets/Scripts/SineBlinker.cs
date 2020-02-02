using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineBlinker : MonoBehaviour
{
    public SpriteRenderer Renderer;

    private void Update()
    {
        var color = Renderer.material.color;

        Renderer.material.color = new Color(color.r, color.g, color.b, SineSquared());
    }

    private static float SineSquared()
    {
        var sine = Mathf.Sin(Time.time);

        return sine * sine;
    }
}
