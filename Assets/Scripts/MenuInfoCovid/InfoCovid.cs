using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoCovid : MonoBehaviour
{
    [SerializeField] private GameObject[] infoCovids;

    [SerializeField] private GameObject prev, next;
    private int currentIndex = 1;
    
    
    private Vector3 mainPosition, NextOnePosition, NextTwoPosition, prevOnePosition, prevTwoPosition;
    void Start()
    {
        mainPosition = infoCovids[1].transform.localPosition;
        NextOnePosition = infoCovids[2].transform.localPosition;
        NextTwoPosition = infoCovids[2].transform.localPosition + new Vector3(848f, 0,0);
        prevOnePosition = infoCovids[0].transform.localPosition;
        prevTwoPosition = infoCovids[0].transform.localPosition + new Vector3(-848f, 0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentIndex == 0)
        {
            infoCovids[0].transform.localPosition = Vector3.Lerp(infoCovids[0].transform.localPosition,mainPosition, 4f * Time.deltaTime);
            infoCovids[1].transform.localPosition = Vector3.Lerp(infoCovids[1].transform.localPosition,NextOnePosition, 4f * Time.deltaTime);
            infoCovids[2].transform.localPosition = Vector3.Lerp(infoCovids[2].transform.localPosition,NextTwoPosition, 4f * Time.deltaTime);
        }
        else if (currentIndex == 1)
        {
            infoCovids[0].transform.localPosition = Vector3.Lerp(infoCovids[0].transform.localPosition,prevOnePosition, 4f * Time.deltaTime);
            infoCovids[1].transform.localPosition = Vector3.Lerp(infoCovids[1].transform.localPosition,mainPosition, 4f * Time.deltaTime);;
            infoCovids[2].transform.localPosition = Vector3.Lerp(infoCovids[2].transform.localPosition,NextOnePosition, 4f * Time.deltaTime);
        }else if (currentIndex == 2)
        {
            infoCovids[0].transform.localPosition = Vector3.Lerp(infoCovids[0].transform.localPosition,prevTwoPosition, 4f * Time.deltaTime);
            infoCovids[1].transform.localPosition = Vector3.Lerp(infoCovids[1].transform.localPosition,prevOnePosition, 4f * Time.deltaTime);
            infoCovids[2].transform.localPosition = Vector3.Lerp(infoCovids[2].transform.localPosition,mainPosition, 4f * Time.deltaTime);
        }

        if (currentIndex == 0)
        {
            prev.SetActive(false);
            next.SetActive(true);
        }else if (currentIndex == infoCovids.Length - 1)
        {
            prev.SetActive(true);
            next.SetActive(false);
        }
        else
        {
            prev.SetActive(true);
            next.SetActive(true);
        }
    }

    public void Next()
    {
        currentIndex++;
    }

    public void Prev()
    {
        currentIndex--;
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
