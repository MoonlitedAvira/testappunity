using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCreator : MonoBehaviour
{
    private Sprite _sprite = Resources.Load<Sprite>("Sprites/Circle");
    private readonly List<GameObject> _sprites = new();

    void Start()
    {
        
    }

    public void CreatePoint(Vector3 position)
    {
        GameObject sprite = new GameObject();
        sprite.name= $"Point {_sprites.Count}";
        sprite.AddComponent<SpriteRenderer>();
        sprite.GetComponent<SpriteRenderer>().sprite = _sprite;
        sprite.GetComponent<SpriteRenderer>().color = Color.red;
        sprite.transform.position = position;
        _sprites.Add(sprite);
    }
    public void RemovePoint(int index)
    {
        GameObject sprite = _sprites[index];
        _sprites.RemoveAt(index);
        GameObject.Destroy(sprite);
    }
}
