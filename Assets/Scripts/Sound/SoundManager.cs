using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;

public class SoundManager : Singleton<SoundManager>

{
	public List<MusicSetup> musicSetups;
	//public List<SFXSetup<sfxSetups;

public AudioSource musicSource;

	public void PlayMusicByType(MusicSetup musicType)
	{
		//var music = musicSetups.Find(i => i.musicType == musicType);
		//musicSource.clip = music.audioClip;
		musicSource.Play();
	}


	public MusicSetup GetMusicByType(MusicType musicType)
	{
		return musicSetups.Find(i => i.musicType == musicType);
	}

	/*
	public SFXSetup GetSFXSetup(MusicType musicType)
	{
		//return musicSetups.Find(i => i.musicType == musicType);
	} */
}


public enum MusicType
{
	TYPE_01,
	TYPE_02,
	TYPE_03

}

[System.Serializable]
public class MusicSetup
{
	public MusicType musicType;
	public AudioClip audioClip;

}


public enum SFXType
{
	TYPE_01,
	TYPE_02,
	TYPE_03

}


public class SFXSetup
{
	public MusicType musicType;
	public AudioClip audioClip;

}


