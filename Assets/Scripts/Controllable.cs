using UnityEngine;

public class Controllable : MonoBehaviour
{
    public int ControlledByPlayer;
    public bool IsControllable { get { return ControlledByPlayer != 0; } }
}   