using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Hoax : MonoBehaviour
{
    public State state;
    [SerializeField] private GameObject canvas;
    [SerializeField] private ToggleGroup[] key;
    [SerializeField] private Text[] statement;
    [SerializeField] private GameObject coin;

    [SerializeField] private GameObject btnInteract;
    [SerializeField] private GameObject btnSubmit;

    [SerializeField] private GameObject[] books;
    [SerializeField] private GameObject next;
    [SerializeField] private GameObject prev;

    [SerializeField] private int indexBooks = 0;

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

    private void Update()
    {
        // ReSharper disable once PossibleNullReferenceException
        // var i = key.Count(t => !t.ActiveToggles().FirstOrDefault().isOn && !(t.ActiveToggles().FirstOrDefault() is null));
        //
        // if (i == key.Length)
        // {
        if (btnSubmit != null)
            btnSubmit.SetActive(true);
        // }

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
        var i = 0;
        for (var j = 0; j < key.Length; j++)
        {
            var toggle = key[j].ActiveToggles().FirstOrDefault();
            if (!(toggle is null) && toggle.name == GetKey(j))
                i += 1;
        }

        if (i == 2)
        {
            DataPlayer.HoaxConfirm += 1;

            Instantiate(coin,
                new Vector3(transform.position.x + 2, gameObject.transform.position.y, transform.position.z),
                quaternion.identity);
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

    public void Close() => canvas.SetActive(false);

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
            if(books[i] != null)
                books[i].SetActive(i == indexBooks);
        }
    }

    public void NextBook() => indexBooks++;
    public void PrevBook() => indexBooks--;
}