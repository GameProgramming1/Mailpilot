using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    //private instance variable
    private AudioSource[] _audioSources; //array of audio sources
    private AudioSource _CloudAudioSource;
    private AudioSource _IslandAudioSource;


	// Use this for initialization
	void Start () {
        this._audioSources = this.GetComponents<AudioSource> ();
        this._CloudAudioSource = this._audioSources[1];//reference cloud sound
	this._IslandAudioSource = this._audioSources[2];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D otherGameObject) 
    {
        if (otherGameObject.tag == "Island")
        {
            this._IslandAudioSource.Play();
        }
        else
        {
            this._CloudAudioSource.Play();
        }
    }
}
