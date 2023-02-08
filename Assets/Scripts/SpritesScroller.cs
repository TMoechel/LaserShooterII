using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    Vector2 offSet;
    Material material;
    // Start is called before the first frame update
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offSet = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offSet;
    }
}
