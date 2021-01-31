using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnippetList : MonoBehaviour
{
    public string[] storySnippets = new string[5];
    public List<Transform> shelfpositions;
    public GameObject nextBook;
    public int randomIndex;
    // Start is called before the first frame update
    void Start()
    {
        randomIndex = Random.Range(0, shelfpositions.Count);
        nextBook.transform.position = shelfpositions[randomIndex].position;
    }
}
