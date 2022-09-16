using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] PlayerController control;
    SpriteRenderer myRenderer;
    [SerializeField] List<Sprite> idleSprites;
    [SerializeField] List<Sprite> runSprites;
    [SerializeField] Sprite jumpSprite;
    [SerializeField] Sprite dashSprite;
    public float frameTime;
    float animRunningTime;
    int currentFrame = 0;

    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animRunningTime += Time.deltaTime;
        
        if (!control.jumping)
        {
            if (control.crouching)
            {
                AnimateDash();
            }
            else 
            {
                AnimateRun();
            }
            
        }
        else { AnimateJump(); }
        
        
    }
    void AnimateDash()
    {
        myRenderer.sprite = dashSprite;
    }
    void AnimateJump()
    {
        myRenderer.sprite = jumpSprite;
    }
    void AnimateRun()
    {
        if (animRunningTime > frameTime)
        {
            animRunningTime = 0;
            currentFrame++;
            if (currentFrame >= runSprites.Count)
            {
                currentFrame = 0;
            }
            myRenderer.sprite = runSprites[currentFrame];
        }
    }
   
}
