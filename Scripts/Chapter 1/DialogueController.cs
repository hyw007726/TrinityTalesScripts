using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    private string DialogueScene = "DialogueScene";
    private string playerName = "Default Player";
    private string country = "Default Country";
    private string page0;
    private string page1;
    private string page2;
    private string page3;
    public int currentDialogue = 0;
    private float duration = 2.0f; // Duration of the animation in seconds


    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI prevButtonText;
    public TextMeshProUGUI nextButtonText;

    private List<string> pages = new List<string>();
    public Button prevButton;
    public GameObject container;
    void Awake()
    {
        gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerName = DataManager.Instance.ReadData().playerName;
        country = DataManager.Instance.ReadData().country;
        page0 = $"Hello {playerName}! I’m Sam, Trinity’s resident fox, congratulations on getting admitted. There’s quite a bit of preparation you’ll need to do before your big move to Dublin, But don’t worry! I’m going to guide you along the way.{System.Environment.NewLine + System.Environment.NewLine}You should start by applying for a visa, as this part usually takes the longest!";
        page1 = $"You’re from {country}, so you’ll need minimum 2-4 weeks to get your Stamp 2 Visa, a Visa for non-EU and non-EEA students who are pursuing a course of study at a recognized Irish educational institution. You also need buy proper insurance to get the visa!";
        page2 = $"In this game, we'll show you how tough it is to find accommodation if you did't apply for campus dormitory early enough. Be careful of the evil scams!{System.Environment.NewLine + System.Environment.NewLine}We'll also give you some ideas on how different the weahter, cost of living and transportation is from your country.";
        page3 = $"You can move cursor to <color=blue>MyTodos</color> in the top left corner to see what you've done so far in this game! If you click on the <color=blue>Info icon</color> in the bottom right corner you'll find some very useful links as well.{System.Environment.NewLine + System.Environment.NewLine} Now let's begin! Work with your <color=red>PC</color> to help these incoming students find the right fit, and maybe along the way you’ll find yours!";
        pages.Add(page0);
        pages.Add(page1);
        pages.Add(page2);
        pages.Add(page3);
        dialogueText.text = pages[currentDialogue];
        prevButtonText.color = Color.gray;
        //prevButton = transform.Find("PrevButton").GetComponent<Button>();
        prevButton.interactable = false;
        prevButton.transition = Selectable.Transition.None;
        GameObject fox = GameObject.Find("fox");

        if (fox != null)
        {
            Vector3 moveVector = new Vector3(550f, 0f, 0f); // Move 500 units to the right relative to the fox
            Animator foxAnimator = fox.GetComponent<Animator>();

            if (foxAnimator != null)
            {
                foxAnimator.SetBool("StartAnimation", true);
            
                StartCoroutine(MoveFromTo(fox, moveVector, duration));

            }
            else
            {
                Debug.LogError("No Animator component found on the fox GameObject");
            }
        }
        else
        {
            //Debug.LogError("Fox object not found");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickPrev()
    {
        if (currentDialogue == 0)
        {
            return;
        }
        if (currentDialogue == 1)
        {
            
            prevButton.interactable = false;
            prevButton.transition = Selectable.Transition.None;
            prevButtonText.color = Color.gray;

        }
        else
        {
            prevButton.interactable = true;
            prevButton.transition = Selectable.Transition.ColorTint;

        }
        currentDialogue--;
        dialogueText.text = pages[currentDialogue];
    }
    public void clickNext()
    {
        if (pages.Count == currentDialogue + 1)
        {
            ////Can't get object directly from an added scene
            //GameObject[] rootObjects = SceneManager.GetSceneByName("OverlayScene").GetRootGameObjects();
            //foreach (GameObject obj in rootObjects)
            //{
            //    if (obj.name == "Overlays")
            //    {
            //        //Debug.Log(obj);
            //        obj.SetActive(true);
            //    }
            //}

            //Canvas overLayCanvas = GameObject.Find("Overlays").GetComponent<Canvas>();
            //overLayCanvas.enabled = true;
            SpriteRenderer fox = Camera.main.GetComponentInChildren<SpriteRenderer>();
            fox.enabled = false;
            //fox.gameObject.SetActive(false);
            SceneManager.UnloadSceneAsync(DialogueScene);
            GameObject pc = GameObject.Find("PC 1");
            if (pc.GetComponent<CursorChanger>() != null)
            {
                pc.GetComponent<CursorChanger>().EnableCursorChange();
                PlayerPrefs.SetInt("FinishedDialogue", 1);
            }
            return;
        }
        currentDialogue++;
        prevButtonText.color = Color.black;
        prevButton.interactable = true;
        prevButton.transition = Selectable.Transition.ColorTint;
        if (pages.Count== currentDialogue + 1)
        {
            nextButtonText.text = "Okay";
            //open overlay
            Canvas overLayCanvas = GameObject.Find("Overlays").GetComponent<Canvas>();
            overLayCanvas.enabled = true;
        
        }
        dialogueText.text = pages[currentDialogue];
    }


    IEnumerator MoveFromTo(GameObject objectToMove, Vector3 target, float time)
    {
        float i = 0.0f;
        float rate = 1.5f / time;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            objectToMove.transform.Translate(target * Time.deltaTime * rate, Space.Self);
            yield return null;
        }
        SpriteRenderer foxIdle = Camera.main.GetComponentInChildren<SpriteRenderer>();
        foxIdle.enabled = true;
        container.SetActive(true);
    }


}
