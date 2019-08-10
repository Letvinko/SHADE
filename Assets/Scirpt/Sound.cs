using UnityEngine.Audio;
using System;
using UnityEngine;

public class Sound : MonoBehaviour {
    public Sound1[] sound;

	// Use this for initialization
	void Awake () {
        foreach (Sound1 s in sound){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    void Start()
    {
        play("Theme");
    }

    public void play(string name) {
        Sound1 s = Array.Find(sound,Sound1 => Sound1.name == name);
        if ( s == null ){
            Debug.Log("Musik Ilang");
            return;
        }
        s.source.Play();
    }
}
