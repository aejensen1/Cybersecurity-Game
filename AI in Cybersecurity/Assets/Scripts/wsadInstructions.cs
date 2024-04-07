using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wsadInstructions : MonoBehaviour
{
    public Image arrowKeys;
    public Image wsadKeys;
    public GameObject Instructions;
    private Color arrowsNewColor;

    int i;
    [SerializeField]
    private float m_fadeDuration;
    [SerializeField]
    private bool m_ignoreTimeScale;
    //Start is called before the first frame update
    void Start()
    {
        i = 0;
        m_fadeDuration = 15f;
        m_ignoreTimeScale = false;
        Instructions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("StartFade");

        if (i == 0)
        {
            arrowsNewColor = arrowKeys.color;
            arrowsNewColor.a -= 1 * Time.deltaTime;
            arrowKeys.color = arrowsNewColor;
            if (arrowsNewColor.a == 0)
                i = 1;
        }
        
        if (i == 1)
        {
            Color arrowsNewColor = arrowKeys.color;
            arrowsNewColor.a += 1 * Time.deltaTime;
            arrowKeys.color = arrowsNewColor;
            if (arrowsNewColor.a == 255)
                i = 0;
        }
        

        Color wsadNewColor = wsadKeys.color;
        arrowsNewColor.a = 255f;
        wsadNewColor.a -= 1 * Time.deltaTime;
        wsadKeys.color = wsadNewColor;




        arrowKeys.GetComponent<CanvasRenderer>().SetAlpha(255f);
        arrowKeys.CrossFadeAlpha(0f, m_fadeDuration, m_ignoreTimeScale);
        wsadKeys.GetComponent<CanvasRenderer>().SetAlpha(255f);
        wsadKeys.CrossFadeAlpha(0f, m_fadeDuration, m_ignoreTimeScale);


        arrowKeys.CrossFadeAlpha(0f, m_fadeDuration, m_ignoreTimeScale);
    }

    //public void StartFade()
    //{
    //    Instructions.SetActive(true);
    //}
}
