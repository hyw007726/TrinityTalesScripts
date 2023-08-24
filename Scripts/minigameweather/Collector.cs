using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    // 当进入触发器时调用
    void OnTriggerEnter2D(Collider2D target)
    {
        // 如果进入触发器的物体的 tag 是 "bomb" 或 "items"
        if (target.tag == "boom" || target.tag == "items") {
            // 关闭进入触发器的物体，使其不再活动
            target.gameObject.SetActive(false);
            // Destroy(target);
        }
    }
}
