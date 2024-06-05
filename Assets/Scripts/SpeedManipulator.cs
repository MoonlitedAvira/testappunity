using System;
using UnityEngine;
using UnityEngine.UI;

public class SpeedManipulator : MonoBehaviour
{
    [SerializeField] private GameObject _slider, _text;
    void Update()
    {
        _text.GetComponent<Text>().text = $"Скорость: {_slider.GetComponent<Slider>().value}";
    }
}
