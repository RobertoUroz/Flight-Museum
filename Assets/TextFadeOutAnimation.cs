using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeOutAnimation : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    }

    // Update is called once per frame
    void Update()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 10));
    }
}
