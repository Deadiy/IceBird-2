using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale2Screen : MonoBehaviour
{
    [SerializeField] private GameHandler handler;
    public Vector2 modifier;
    public float offset;

    Vector3 CameraPosition;
    Vector3 LastPosition;
    float textureUnitSize;

    void Start()
    {
        CameraPosition = Camera.main.transform.position;
        LastPosition = CameraPosition;

        Sprite sprt = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprt.texture;
        textureUnitSize = texture.width / sprt.pixelsPerUnit;
    }
    void FixedUpdate()
    {
        transform.position += new Vector3(handler.spawner.move_speed * (-modifier.x), modifier.y);
        LastPosition = CameraPosition;
        Endless();
    }

    private void Endless()
    {
        if(CameraPosition.x - transform.position.x >= textureUnitSize)
        {
            float offsetPosition = (CameraPosition.x - transform.position.x) % textureUnitSize;
            transform.position = new Vector3(CameraPosition.x + offsetPosition + offset, transform.position.y);
        }
    }
}
