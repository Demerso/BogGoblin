using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change : MonoBehaviour
{
    public Texture2D axe;
    public Texture2D bow;
    public RawImage current;
    private void Start()
    {
       
       
    }

    public void Swap()
    {
        Debug.Log("bruh");
        if(current == bow)
        {
            current.canvasRenderer.SetTexture(axe);
        }
        else
        {
            current.texture = bow;
        }
    }
}
