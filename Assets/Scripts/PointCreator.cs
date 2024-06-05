using System.Collections.Generic;
using UnityEngine;

public class PointCreator : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    private SpriteRenderer _spriteRenderer;
    private List<GameObject> _sprites = new();
    [SerializeField] private float _size = 1f;
    public void CreatePoints(List<Vector3> list)
    {
        GameObject sprite = new($"Point{list.Count}");
        _spriteRenderer = sprite.AddComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.red;
        _spriteRenderer.sprite = _sprite;
        _spriteRenderer.sortingOrder = 1;
        sprite.transform.localScale = new Vector3(_size, _size, 1f);
        sprite.transform.position = list[^1];
        _sprites.Add(sprite);
    }
    public void DestroyPoint(int index)
    {
        GameObject.Destroy(_sprites[index]);
        _sprites.RemoveAt(index);
    }
}
