using UnityEngine;

public class Controllable : MonoBehaviour
{
    public int ControlledByPlayer;
    public bool IsControllable => ControlledByPlayer != 0;
}   