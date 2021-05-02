using System;
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

    void Awake()
    {
        if (canvas != null)
            canvas.SetActive(false);

        for (int i = 0; i < statement.Length; i++)
        {
            statement[i].text = state.states[i].statement;
        }
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
            Instantiate(coin,
                new Vector3(transform.position.x + 2, gameObject.transform.position.y, transform.position.z),
                quaternion.identity);
            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            Destroy(canvas);
        }
    }

    public void Close() => canvas.SetActive(false);

    public void Show() => canvas.SetActive(true);

    private string GetKey(int i) => (state.states[i].key == Key.TRUE) ? "True" : "False";
}