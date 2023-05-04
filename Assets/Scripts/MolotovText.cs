using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MolotovText : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Text textPlace;
    public string explain;
    public GameObject textBox;
    public GameObject ItemText;

    private void Start()
    {
        textPlace.text = explain;
        ItemText.SetActive(false);
        textBox.SetActive(false);

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        textBox.SetActive(true);
        ItemText.SetActive(true);
    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textBox.SetActive(false);
        ItemText.SetActive(false);
    }
}
