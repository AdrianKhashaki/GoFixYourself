using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] private PartColor _color;
    
    public PartColor Color => _color;

    private void Start()
    {
        foreach (var renderers in GetComponentsInChildren<Renderer>())
        {
            renderers.material.color = Color.GetColor();
        }
    }
}