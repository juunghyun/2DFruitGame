using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Apple : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textNumber;
    private Image image;
    private RectTransform rect;

    private int number = 0;
    public int Number
    {
        set
        {
            number = value;
            textNumber.text = number.ToString();
        }
        get => number;

    }
    
    public Vector3 position => rect.position;
    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void OnSelected()
    {
        image.color = Color. blue;
    }
    public void OnDeselected()
    {
        image.color = Color.red;
    }
}
