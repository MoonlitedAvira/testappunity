using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedManipulator : MonoBehaviour
{
    [SerializeField] private GameObject _slider, _text;
    void Update()
    {
        _text.GetComponent<Text>().text = $"Скорость: {Math.Round(_slider.GetComponent<Slider>().value,2)}";
    }
}
