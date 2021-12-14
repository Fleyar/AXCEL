using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer musicMixer, effectsMixer;

    public AudioSource main, rifle, blowup, bomb,boss_main, boss_fire, boss_laser, boss_intro, hurt, jmp;

    public static AudioManager instance;

    [Range (-80,10)]
    public float masterVol, effectsVol;
    public Slider masterSldr, effectsSldr;

    private void Awake() {
        if (instance == null){
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        masterSldr.value = masterVol;
        effectsSldr.value = effectsVol;

        masterSldr.minValue = -80;
        masterSldr.maxValue = 10;

        effectsSldr.minValue = -80;
        effectsSldr.maxValue = 10;
       // PlayAudio(main);
    }

    // Update is called once per frame
    void Update()
    {
        MasterVolume();
        EffectsVolume();
    }
    
    public void MasterVolume (){
        musicMixer.SetFloat("masterVolume", masterSldr.value);
    }
    public void EffectsVolume (){
        effectsMixer.SetFloat("effectsVolume", effectsSldr.value);
    }
    public void PlayAudio(AudioSource audio){
        audio.Play();
    }
    
}