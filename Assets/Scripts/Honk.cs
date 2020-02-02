using UniRx;
using UnityEngine;

[RequireComponent(typeof(CustomPlayerInput))]
[RequireComponent(typeof(AudioSource))]
public class Honk : MonoBehaviour
{
    public CustomPlayerInput CustomPlayerInput;
    public AudioSource AudioSource;
    
    private void Start()
    {
        CustomPlayerInput.ButtonDown
            .Where(down => down)
            .Subscribe(_ => HonkHorn())
            .AddTo(gameObject);
    }

    private void HonkHorn()
    {
        if (AudioSource.isPlaying)
            return;

        AudioSource.Play();
    }
}
