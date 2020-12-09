using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale2Screen : MonoBehaviour
{
    public float offset_x, offset_y;
    void FixedUpdate()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x - offset_x;
        float height = sr.sprite.bounds.size.y - offset_y;

        transform.localScale = new Vector2(Screen.width / width, Screen.height / height);
    }
}
