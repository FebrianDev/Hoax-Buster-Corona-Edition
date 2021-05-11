using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Hoax : MonoBehaviour
{
    public State state;
    [SerializeField] private GameObject canvas;
    [SerializeField] private ToggleGroup[] key;
    [SerializeField] private Text[] statement;

    [SerializeField] private GameObject btnInteract;
    [SerializeField] private GameObject btnSubmit;

    [SerializeField] private GameObject[] books;
    [SerializeField] private GameObject next;
    [SerializeField] private GameObject prev;

    [SerializeField] private int indexBooks = 0;

    [SerializeField] private GameObject[] gameObjectToogle;
    private Toggle[] toggle;

    private void Awake()
    {
        if (canvas != null)
            canvas.SetActive(false);

        for (var i = 0; i < statement.Length; i++)
        {
            statement[i].text = state.states[i].statement;
        }

        btnSubmit.SetActive(false);
    }

    private void Start()
    {
        foreach (var g in gameObjectToogle)
        {
            toggle = g.GetComponentsInChildren<Toggle>();
        }
    }

    private void Update()
    {
        foreach (var kGroup in key)
        {
            foreach (var t1 in toggle)
            {
                t1.onValueChanged.AddListener((t) =>
                {
                    if (!t) return;
                    kGroup.allowSwitchOff = false;
                    btnSubmit.SetActive(btnSubmit != null);
                });
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
        var i = key.Select(t => t.ActiveToggles().FirstOrDefault())
            .Where((toggle, j) => !(toggle is null) && toggle.name == GetKey(j))
            .Count();

        if (i == 2)
        {
            DataPlayer.HoaxConfirm += 1;
            DataPlayer.Coin += 10;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            Destroy(canvas);
        }
        else
        {
            if (DataPlayer.Credibilitas != 0)
                DataPlayer.Credibilitas -= 1;

            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            Destroy(canvas);
        }
    }

    public void Close()
    {
        foreach (var kGroup in key)
        {
            kGroup.allowSwitchOff = true;
            kGroup.ActiveToggles().FirstOrDefault().isOn = false;
        }
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