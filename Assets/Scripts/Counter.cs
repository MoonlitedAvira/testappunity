using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    public void UpdateCounter(int count)
    {
        _text.GetComponent<Text>().text = $"Кол-во точек: {count-1}";
    }
}
