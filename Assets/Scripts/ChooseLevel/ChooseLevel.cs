using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ChooseLevel : MonoBehaviour
{
    public List<GameObject> levels = new List<GameObject>();

    private int currentIndex;
    public GameObject prevButton, nextButton;

    private int size;

    private Vector3 mainPosition, NextOnePosition, NextTwoPosition, prevOnePosition, prevTwoPosition;

    private string levelTwoOpen;
    private void Awake()
    {
        levelTwoOpen = PlayerPrefs.GetString("Level2", "");
    }

    private void Start()
    {
        mainPosition = levels[0].transform.localPosition;
        NextOnePosition = levels[1].transform.localPosition;
        NextTwoPosition = levels[2].transform.localPosition;
        prevOnePosition = new Vector3(-1020, levels[0].transform.localPosition.y, levels[0].transform.localPosition.z);
        prevTwoPosition = new Vector3(-1830, levels[0].transform.localPosition.y, levels[0].transform.localPosition.z);
        currentIndex = 0;

        Time.timeScale = 1f;

        if (levelTwoOpen == "Level2")
        {
            levels[0].transform.localPosition = Vector3.Lerp(levels[0].transform.localPosition,prevOnePosition, 4f * Time.deltaTime);
            levels[1].transform.localPosition = Vector3.Lerp(levels[1].transform.localPosition,mainPosition, 4f * Time.deltaTime);;
            levels[2].transform.localPosition = Vector3.Lerp(levels[2].transform.localPosition,NextOnePosition, 4f * Time.deltaTime);
            currentIndex++;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentIndex == 0)
        {
            if(prevButton != null)
                prevButton.SetActive(false);
        }
        else if (currentIndex == levels.Count - 1)
        {
            if(nextButton != null)
                nextButton.SetActive(false);
        }
        else
        {
            prevButton.SetActive(true);
            nextButton.SetActive(true);
        }

        if (currentIndex == 0)
        {
            levels[0].transform.localPosition = Vector3.Lerp(levels[0].transform.localPosition,mainPosition, 4f * Time.deltaTime);
            levels[1].transform.localPosition = Vector3.Lerp(levels[1].transform.localPosition,NextOnePosition, 4f * Time.deltaTime);
            levels[2].transform.localPosition = Vector3.Lerp(levels[2].transform.localPosition,NextTwoPosition, 4f * Time.deltaTime);
        }
        else if (currentIndex == 1)
        {
            levels[0].transform.localPosition = Vector3.Lerp(levels[0].transform.localPosition,prevOnePosition, 4f * Time.deltaTime);
            levels[1].transform.localPosition = Vector3.Lerp(levels[1].transform.localPosition,mainPosition, 4f * Time.deltaTime);;
            levels[2].transform.localPosition = Vector3.Lerp(levels[2].transform.localPosition,NextOnePosition, 4f * Time.deltaTime);
        }else if (currentIndex == 2)
        {
            levels[0].transform.localPosition = Vector3.Lerp(levels[0].transform.localPosition,prevTwoPosition, 4f * Time.deltaTime);
            levels[1].transform.localPosition = Vector3.Lerp(levels[1].transform.localPosition,prevOnePosition, 4f * Time.deltaTime);
            levels[2].transform.localPosition = Vector3.Lerp(levels[2].transform.localPosition,mainPosition, 4f * Time.deltaTime);
        }

    }

    public void NextLevel()
    {
        currentIndex++;
    }

    public void PrevLevel()
    {
        currentIndex--;

        for (int i = 1; i < levels.Count; i++)
        {
            levels[i].transform.position = Vector3.Lerp(levels[i].transform.position,
                new Vector3(levels[i].transform.position.x + 810, levels[i].transform.position.y, levels[i].transform.position.z),
                0.1f * Time.deltaTime);
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void PlayLevelOne()
    {
        SceneManager.LoadScene("Level 1-1");
    }

    public void PlayLevelTwo()
    {
        if (levelTwoOpen == "Level2")
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}