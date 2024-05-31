using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCreator : MonoBehaviour
{
    private Sprite _sprite;
    private readonly List<GameObject> _sprites = new();
    private void Start()
    {
        _sprite = Resources.Load<Sprite>("Sprites/Circle");
    }

    public void CreatePoints(List<Vector3> list)
    {
        GameObject sprite = new GameObject($"Point{list.Count}");
        sprite.AddComponent<SpriteRenderer>();
        sprite.GetComponent<SpriteRenderer>().color = Color.red;
        sprite.GetComponent<SpriteRenderer>().sprite = _sprite;
        sprite.GetComponent<SpriteRenderer>().sortingOrder = 1;
        sprite.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        sprite.transform.position = list[list.Count-1];
        _sprites.Add(sprite);
    }
    public void DestroyPoint(int index)
    {
        GameObject.Destroy(_sprites[index]);
        _sprites.RemoveAt(index);
    }
}
