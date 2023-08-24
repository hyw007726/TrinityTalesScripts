using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private Text scoreText;  // 用于显示分数的 Text 组件
    private int score = 0;   // 玩家的分数
    public GameObject winUI; // 游戏通过界面
    public GameObject infoUI; // 游戏规则介绍
    public AudioSource audioBoomSource; // 播放炸弹音效
    public AudioSource audioOtherSource; // 播放其他物品音效
    public GameObject spawn2;

    // Start is called before the first frame update
    void Awake()
    {
        // 在游戏开始时找到场景中名为 "ScoreText" 的对象，并获取其 Text 组件
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        // 初始化分数为 0，将其显示在 UI 上
        scoreText.text = "0";
        //Time.timeScale=0;
    }
    void Update () {
        // 游戏通过条件
        if (score >= 15)
        {
        // 触发游戏通关界面
            // winUI.SetActive(true);
            //Time.timeScale=0;
            SceneManager.UnloadSceneAsync("weather");
            if (DataManager.Instance != null)
            {
                DataManager.Instance.UpdateProgress(4);
            }
            else
            {
                Debug.Log("Can't find data manager");
            }
            TCDDialogueController.Current.ActivateDialogue();
        }
    } 

    // 当物体进入触发器时调用
    void OnTriggerEnter2D(Collider2D target)
    {
        // 如果进入触发器的物体的 tag 是 "boom"
        if (target.tag == "boom")
        {
            // 播放爆炸音效
            audioBoomSource.Play();
            DontDestroyOnLoad(audioBoomSource);
            // 重置玩家位置到指定位置
            transform.position = new Vector2(0, 100);
            // 关闭触发器中的物体
            target.gameObject.SetActive(false);
            // 等待一段时间后重新加载当前场景，实现游戏重新开始
            StartCoroutine(RestartGame());
        }
        // 如果进入触发器的物体的 tag 是 "items"
        if (target.tag == "items")
        {
            // 播放items音效
            audioOtherSource.Play();
            // 关闭触发器中的物体
            target.gameObject.SetActive(false);
            // 分数加一，将新的分数显示在 UI 上
            score++;
            scoreText.text = score.ToString();
        }
    }

    // 协程：重新开始游戏
    IEnumerator RestartGame()
    {
        string sceneToReload = "weather";
        //yield return new WaitForSecondsRealtime(0.5f);

        // Unload the current scene
        //yield return SceneManager.UnloadSceneAsync(sceneToReload);
        SceneManager.UnloadSceneAsync(sceneToReload);
        // Load it again in additive mode
        yield return SceneManager.LoadSceneAsync(sceneToReload, LoadSceneMode.Additive);
    }

    public void startgame(Button playButton)
    {
        playButton.GetComponent<CursorChanger>().DisableCursorChange();
        // 触发游戏规则页面
        //Time.timeScale=1;
         infoUI.SetActive(false);
         spawn2.SetActive(true);
        
    }
}
