using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinNotifier : MonoBehaviour
{
    public static int LoserId;
    public Image Image;
    public float FlashTime;

    private float _elapsedTime;

    void Start()
    {
        switch (LoserId)
        {
            case 0:
                return;
            case 1:
                Image.color = Color.red;
                return;
            case 2:
                Image.color = Color.blue;
                return;
        }
    }

    void Update()
    {
        if (Image.color.a <= 0f)
            return;

        Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, 1 - _elapsedTime / FlashTime);

        _elapsedTime += Time.deltaTime;

    }
}
