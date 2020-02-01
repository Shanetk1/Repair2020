using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBlock : Block
{
    private SpriteRenderer Sprite;
    public ColourType color;
    // Start is called before the first frame update
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        if (color == ColourType.Red)
        {
            Sprite.color = Color.red;
        }
        else if (color == ColourType.Blue)
        {
            Sprite.color = Color.blue;
        }
    }

}
