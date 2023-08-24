using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FlipSprite()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.flipX = true;
        gameObject.SetActive(false);
        //gameObject.transform.parent.Find("fox_idle").gameObject.SetActive(true);
    }
}
