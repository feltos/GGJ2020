using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFx : MonoBehaviour
{
    public static SoundFx Instance;
    public AudioSource soundFx;
    public AudioClip hitFx;
    public AudioClip scoreFx;
    public AudioClip bonusStunFx;
    public AudioClip bonusSpeedUpFx;
    public AudioClip bonusSpeedDownFx;
    public AudioClip bonusOpacityFx;
    public AudioClip bonusToolFx;
    public AudioClip endGameFx;
    public AudioClip fallingBodyFx;


    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("Multiple Instances of sound effects");
        }
        Instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void MakeSound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    public void HitSound()
    {
        MakeSound(hitFx);
    }

    public void ScoreSound()
    {

        MakeSound(scoreFx);
    }

    public void StunSound()
    {

        MakeSound(bonusStunFx);
    }

    public void SpeedUpSound()
    {

        MakeSound(bonusSpeedUpFx);
    }

    public void SpeedDownSound()
    {

        MakeSound(bonusSpeedDownFx);
    }

    public void OpacitySound()
    {

        MakeSound(bonusOpacityFx);
    }

    public void EndGameSound()
    {

        MakeSound(endGameFx);
    }

    public void ToolSoundbonus()
    {

        MakeSound(bonusToolFx);
    }

    public void BodyFallSound()
    {

        MakeSound(fallingBodyFx);
    }


}



