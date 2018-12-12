using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The purpose of this script is trying to make it so that the music for the menu and leaderboard continues for one another
public class Music : MonoBehaviour {

    private static Music instance = null;
    public static Music Instance
    {
        get { return instance; }
    }

	void Awake ()
    {
		if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
	}
	
}

