using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Abyss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetPlayerAffinity() == 0)
            return;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
