using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class Hoax : MonoBehaviour
{
    public State state;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Text[] statement;

    [SerializeField] private GameObject btnInteract;
    [SerializeField] private GameObject btnSubmit;

    [SerializeField] private GameObject[] books;
    [SerializeField] private GameObject next;
    [SerializeField] private GameObject prev;

    [SerializeField] private int indexBooks = 0;

    [SerializeField] private List<CheckData> list = new List<CheckData>();

    [SerializeField] private GameObject tandaSeru;

    private bool isDone;

    private void Awake()
    {
        if (canvas != null)
            canvas.SetActive(false);

        for (var i = 0; i < statement.Length; i++)
        {
            statement[i].text = state.states[i].statement;
        }

        btnSubmit.SetActive(false);

        for (var i = 0; i < list.Count; i++)
        {
            list[i].key[0].allowSwitchOff = true;

            for (var j = 0; j < list[i].check.Length; j++)
            {
                list[i].check[j].isOn = false;
            }
        }
    }

    private void Start()
    {
        isDone = false;
    }

    private void Update()
    {
        for (var i = 0; i < list.Count; i++)
        {
            for (var j = 0; j < list[i].check.Length; j++)
            {
                if (list[i].check[j].isOn)
                {
                    list[i].key[0].allowSwitchOff = false;
                }
            }
        }

        var index = 0;
        for (var i = 0; i < list.Count; i++)
        {
            if (list[i].check[0].isOn || list[i].check[1].isOn)
            {
                index++;
            }
        }

        if (index == list.Count && !isDone)
        {
            if (btnSubmit != null)
            {
                btnSubmit.SetActive(true);
                isDone = true;
            }
        }

        ReadBooks();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            btnInteract.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            btnInteract.SetActive(false);
        }
    }

    public void Submit()
    {
        btnInteract.SetActive(false);
        var i = 0;
        for (var k = 0; k < list.Count; k++)
        {
            var toggles = list[k].key[0].ActiveToggles().FirstOrDefault();
            if (!(toggles is null) && toggles.name == GetKey(k))
            {
                i++;
            }
        }


        if (i == list.Count)
        {
            DataPlayer.HoaxConfirm += 1;
            DataPlayer.Coin += 10;
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
            Destroy(tandaSeru);
            Destroy(canvas);
            gameObject.GetComponent<Hoax>().enabled = false;
        }
        else
        {
            if (DataPlayer.Credibilitas != 0)
                DataPlayer.Credibilitas -= 1;
            Destroy(tandaSeru);
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
            gameObject.GetComponent<Hoax>().enabled = false;
            Destroy(canvas);
        }
    }

    public void Close()
    {
        var i = 0;
        foreach (var kGroup in list)
        {
            kGroup.key[0].allowSwitchOff = true;
            kGroup.check[i].isOn = false;
            i++;
        }

        isDone = false;
        btnSubmit.SetActive(false);
        canvas.SetActive(false);
    }

    public void Show() => canvas.SetActive(true);

    private string GetKey(int i) => (state.states[i].key == Key.TRUE) ? "True" : "False";

    public void ReadBooks()
    {
        if (prev != null)
            prev.SetActive(indexBooks != 0);
        if (next != null)
            next.SetActive(indexBooks != books.Length - 1);

        for (var i = 0; i < books.Length; i++)
        {
            if (books[i] != null)
                books[i].SetActive(i == indexBooks);
        }
    }

    public void NextBook() => indexBooks++;
    public void PrevBook() => indexBooks--;
}

[System.Serializable]
public struct CheckData
{
    public ToggleGroup[] key;
    public Toggle[] check;
}