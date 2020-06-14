using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config parameters
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameObject particleVfx;
    [SerializeField] Sprite[] hitSprites;

    //Cached Reference
    Level level;

    //state variable
    [SerializeField] int timesHit;  //TODO only serialized for debug purpose
    public void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.updateBreakableBlocks();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
       
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)    
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.Log("Block sprite is missing from array!"+name);

        }
        
        
    }

    private void DestroyBlock()
    {
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
            Destroy(gameObject);
            level.BlockDestroyed();
            FindObjectOfType<GameSession>().updatePoints();
            triggerParticleEffect();
 
    }
    private void triggerParticleEffect()
    {
       GameObject sparkles= UnityEngine.Object.Instantiate(particleVfx,transform.position,transform.rotation);
        Destroy(sparkles,1f);
    }
  }
