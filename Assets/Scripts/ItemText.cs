using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemText : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    PlayerController player;
    public int current;
    public GameObject itemText;
    public GameObject textBox;
    public Text text;
    private void Start()
    {
        textBox.SetActive(false);
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        text.text = player.weapons[current].explanation.ToString();
        itemText.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        textBox.SetActive(true);
        itemText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textBox.SetActive(false);
        itemText.SetActive(false);
    }
}
