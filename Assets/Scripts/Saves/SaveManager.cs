using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Ebac.core.Singleton;


public class SaveManager : Singleton<SaveManager>

{
	[SerializeField] private SaveSetup _saveSetup;
	private string _path = Application.streamingAssetsPath + "/save.txt";

	public int lastLevel;

	//public Action<SaveSetup> FileLoaded;


	public SaveSetup Setup
	{
		get { return _saveSetup; }
	}


	protected override void Awake()
	{
		base.Awake();
		DontDestroyOnLoad(gameObject);
		_saveSetup = new SaveSetup();
		_saveSetup.lastLevel = 2;
		_saveSetup.playerName = "Paola";
	}


	private void Start()
	{
		//Invoke(nameof(Load(), .1f);
	}


	private void CreateNewSave()
	{
		base.Awake();
		DontDestroyOnLoad(gameObject);
	}



	[NaughtyAttributes.Button]
	private void Save()
	{

		Load();
	}


	public void SaveItems()
	{
		_saveSetup.coins = Items.ItemManager.Instance.GetItemByType(Items.ItemType.LIFE_PACK).soInt.value;
		_saveSetup.coins = Items.ItemManager.Instance.GetItemByType(Items.ItemType.COIN).soInt.value;
		Save();


	}

	public void SaveName(string text)
	{
		_saveSetup.playerName = text;
		Save();
	}

	public void SaveLastLevel(int level)
	{
		_saveSetup.lastLevel = level;
		//SaveItems()
		//Save();
	}

	private void SaveFile(string json)
	{
		string path = Application.streamingAssetsPath + "/save.txt";
		Debug.Log(path);
		File.WriteAllText(path, json);
	}


	private void Load()
	{
		string fileLoaded = "";

		if (File.Exists(_path))
		{
			fileLoaded = fileLoaded = File.ReadAllText(_path);
			_saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);
			lastLevel = _saveSetup.lastLevel;
		}

		else
		{
			CreateNewSave();
			Save();
		}


		//fileLoaded.Invoke(_saveSetup);
	}

	[NaughtyAttributes.Button]
	private void SaveLevelOne()
	{
		SaveLastLevel(1);
	}

	[NaughtyAttributes.Button]
	private void SaveLevelFive()
	{
		SaveLastLevel(5);
	}
}


[System.Serializable]

public class SaveSetup
{
	public int lastLevel;
	public int coins;
	public int health;
	public string playerName;
	public string qualquer;
}




