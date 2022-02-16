using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnimData
{
    public List<Sprite> Sprites;
    public float FrameRate = 8;
}

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class AnimatorLite : MonoBehaviour
{
    int actualFrame;
    float framePointer;
    int totalFrames;
    AnimData animData;
    SpriteRenderer spriteRenderer;
    bool playing;
    bool looping;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Play(AnimData animData, bool loop = false)
    {
        playing = true;
        looping = loop;
        actualFrame = 0;
        framePointer = 0;
        this.animData = animData;
        totalFrames = animData.Sprites.Count;
        spriteRenderer.sprite = animData.Sprites[0];
    }

    private void Update()
    {
        if (!playing) return;

        framePointer += Time.fixedDeltaTime * animData.FrameRate;

        if (framePointer >= totalFrames) // FINISHED PLAYING
        {
            if (!looping)
            {
                playing = false;
                return;
            }
            else
            {
                framePointer = 0;
                actualFrame = 0;
                spriteRenderer.sprite = animData.Sprites[0];
            }
        }
        if ((int)framePointer != actualFrame) //DRAW NEXT SPRITE
        {
            actualFrame = (int)framePointer;
            spriteRenderer.sprite = animData.Sprites[actualFrame];
        }
    }
}