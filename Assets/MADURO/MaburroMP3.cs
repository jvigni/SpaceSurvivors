using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MaburroMP3 : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public UnityEngine.UIElements.Button muteBtn;
    bool isMuted;

    void Start()
    {
        muteBtn.clicked += SwapMusic;
    }

    void SwapMusic()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;
        Debug.Log("Music " + (isMuted ? "muted" : "unmuted"));
    }
}
