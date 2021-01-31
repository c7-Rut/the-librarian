using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SnippetList : MonoBehaviour
{
    public string[] storySnippets = new string[7];
    public List<Transform> shelfpositions;
    public GameObject nextBook;
    public int randomIndex;
    public GameObject blackout;
    public float duration = 5f;
    private float currentTime = 0f;
    public TextMeshProUGUI snippetText;
    public float bookDuration1 = 40f;
    public float bookDuration2 = 80f;
    public float bookDuration3 = 120f;
    public float bookDuration4 = 160f;
    public float bookDuration5 = 200f;
    public float bookDuration6 = 240f;
    public float bookDuration7 = 280f;


    // Start is called before the first frame update
    void Start()
    {
        //randomIndex = Random.Range(0, shelfpositions.Count);
        //nextBook.transform.position = shelfpositions[randomIndex].position;
        //snippetText.text = storySnippets[0];
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        Debug.Log(currentTime);
        if (currentTime > duration)
        {
            StartCoroutine(FadeToBlack());
        }
        if (currentTime > bookDuration1)
        {
            snippetText.text = storySnippets[0];
        }
        if (currentTime > bookDuration2)
        {
            snippetText.text = storySnippets[1];
        }
        if (currentTime > bookDuration3)
        {
            snippetText.text = storySnippets[2];
        }
        if (currentTime > bookDuration4)
        {
            snippetText.text = storySnippets[3];
        }
        if (currentTime > bookDuration5)
        {
            snippetText.text = storySnippets[4];
        }
        if (currentTime > bookDuration6)
        {
            snippetText.text = storySnippets[5];
        }
        if (currentTime > bookDuration7)
        {
            snippetText.text = storySnippets[6];
        }
    }
    public IEnumerator FadeToBlack(bool fadeToBlack = true, int fadeSpeed = 1)
    {
        Color objectColor = blackout.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackout.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackout.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (blackout.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackout.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }
}
