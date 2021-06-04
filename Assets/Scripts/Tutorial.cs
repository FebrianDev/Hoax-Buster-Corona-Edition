using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private int currentIndex = 0;
    public GameObject prevButton, nextButton;

    [SerializeField] private List<GameObject> tutorials = new List<GameObject>();
    private List<Vector3> listPositions = new List<Vector3>();

    private List<Vector3> tempPositions = new List<Vector3>();

    [SerializeField]private GameObject tutorial;

    public static bool tutorialActive;

    private void Start()
    {
        Time.timeScale = 0f;
        tutorialActive = true;
        
        for (var index = 0; index < tutorials.Count; index++)
        {
            listPositions.Add( tutorials[index].transform.localPosition);
        }

        for (int i = 0; i < tutorials.Count; i++)
        {
            tempPositions.Add( new Vector3(i * 750, 0, 0));
        }
    }

    private void Update()
    {
        print(tutorials.Count);
        if (currentIndex == 0)
        {
            if (prevButton != null)
                prevButton.SetActive(false);
        }
        else if (currentIndex == tutorials.Count - 1)
        {
            if (nextButton != null)
                nextButton.SetActive(true);
        }
        else
        {
            prevButton.SetActive(true);
            nextButton.SetActive(true);
        }


        if (currentIndex == 0)
        {
            for (int i = 0; i < tutorials.Count; i++)
            {
                tutorials[i].transform.localPosition = Vector3.Lerp(tutorials[i].transform.localPosition,
                    listPositions[i] - tempPositions[currentIndex],
                    20 * Time.deltaTime);
            }
        }
        else if (currentIndex == 1)
        {
            for (int i = 0; i < tutorials.Count; i++)
            {
                tutorials[i].transform.localPosition = Vector3.Lerp(tutorials[i].transform.localPosition,
                    listPositions[i] - tempPositions[currentIndex],
                    20 * Time.deltaTime);
            }
        }
        else if (currentIndex == 2)
        {
            for (int i = 0; i < tutorials.Count; i++)
            {
                tutorials[i].transform.localPosition = Vector3.Lerp(tutorials[i].transform.localPosition,
                    listPositions[i] - tempPositions[currentIndex],
                    20 * Time.deltaTime);
            }
        }
        else if (currentIndex == 3)
        {
            for (int i = 0; i < tutorials.Count; i++)
            {
                tutorials[i].transform.localPosition = Vector3.Lerp(tutorials[i].transform.localPosition,
                    listPositions[i] - tempPositions[currentIndex],
                    20 * Time.deltaTime);
            }
        }
        else if (currentIndex == 4)
        {
            for (int i = 0; i < tutorials.Count; i++)
            {
                tutorials[i].transform.localPosition = Vector3.Lerp(tutorials[i].transform.localPosition,
                    listPositions[i] - tempPositions[currentIndex],
                    20 * Time.deltaTime);
            }
        }
        else if (currentIndex == 5)
        {
            for (int i = 0; i < tutorials.Count; i++)
            {
                tutorials[i].transform.localPosition = Vector3.Lerp(tutorials[i].transform.localPosition,
                    listPositions[i] - tempPositions[currentIndex],
                    20 * Time.deltaTime);
            }
        }
    }

    public void Next()
    {
        if (currentIndex == tutorials.Count - 1)
        {
            Time.timeScale = 1f;
            tutorialActive = false;
            tutorial.SetActive(false);
        }
        else
        {
            currentIndex++;
        }
    }

    public void Prev()
    {
        currentIndex--;
    }
}