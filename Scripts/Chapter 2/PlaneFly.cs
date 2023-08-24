using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlaneFly : MonoBehaviour
{
    public Transform point0; // Starting point
    public Transform point1; // Control point
    public Transform point2; // End point
    public float speed = 0.5f;

    private float t = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowCurve());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FollowCurve()
    {
        AudioSource jet = GetComponent<AudioSource>();
        while (t < 1)
        {
        if (t > 0.9)
            {
                transform.localScale = transform.localScale * 0.9995f;
                jet.volume *= 0.98f;
            }
            t += Time.deltaTime * speed;
            transform.position = CalculateBezierPoint(t, point0.position, point1.position, point2.position);
            yield return null;
        }
        //Do sth after animation
        jet.Stop();
        AsyncOperation loadChapter2 = SceneManager.LoadSceneAsync("Chapter 2");
        //while (!loadChapter2.isDone)
        //{
        //    yield return null;  // wait until Chapter 2 is loaded
        //}
        //if (SceneManager.GetSceneByName("TCDDialogue") == null)
        //{
        //    Debug.LogError("TCDDialogue scene not found!");
        //}
       
    }
   private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0; // (1-t)^2 * P0
        p += 2 * u * t * p1; // 2 * (1-t) * t * P1
        p += tt * p2; // t^2 * P2

        return p;
    }
}
