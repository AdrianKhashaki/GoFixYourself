using UnityEngine;

public static class Extensions
{
    public static int GetPlayerAffinity(this Component component)
    {
        return component.gameObject.GetPlayerAffinity();
    }
    
    public static int GetPlayerAffinity(this GameObject gameObject)
    {
        var controllable = gameObject.transform.root.GetComponent<Controllable>();

        return controllable == null ? 0 : controllable.ControlledByPlayer;
    }

    public static void SetPlayerAffinity(this Component component, int playerNumber)
    {
        component.gameObject.SetPlayerAffinity(playerNumber);
    }

    public static void SetPlayerAffinity(this GameObject gameObject, int playerNumber)
    {
        var controllable = gameObject.transform.root.GetComponent<Controllable>();

        if (controllable == null)
            controllable = gameObject.transform.root.gameObject.AddComponent<Controllable>();

        controllable.ControlledByPlayer = playerNumber;
    }
}