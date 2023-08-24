using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // 用于存储不同物体的数组
    [SerializeField]
    private GameObject[] items;
    // 用于存储碰撞器的引用
    private BoxCollider2D col;
    // 用于存储x坐标的边界
    float x1, x2;

    // 在游戏对象唤醒时调用
    void Awake()
    {
        // 获取该游戏对象上的 BoxCollider2D 组件
        col = GetComponent<BoxCollider2D>();

        // 计算x坐标的边界

        x1 = transform.position.x - col.bounds.size.x / 2f;
        x2 = transform.position.x + col.bounds.size.x / 2f;
    }

    // 在游戏开始时调用
    void Start()
    {
        //Debug.Log(x1);
        //Debug.Log(x2);
        // 开始协程 SpawnItems，设置初始等待时间为 1 秒
        StartCoroutine(SpawnItems(0.5f));
    }
    public Transform Root;
    // 生成物体的协程
    IEnumerator SpawnItems(float time)
    {
        // 等待一定的时间
        yield return new WaitForSecondsRealtime(time);

        // 获取当前位置，并修改x坐标以随机范围内的值生成物体
        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2);

        // 从物体数组中随机选择一个物体，并在随机位置生成它
        Instantiate(items[Random.Range(0, items.Length)], temp, Quaternion.identity,Root);
       

        // 开始下一次 SpawnItems 协程，等待时间在 0.5 到 0.9 秒之间
        StartCoroutine(SpawnItems(Random.Range(0.6f, 1f)));
    }
    void Update()
    {
        
    }
}

