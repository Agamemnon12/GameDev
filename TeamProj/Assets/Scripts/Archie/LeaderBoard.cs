using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
 

public class LeaderBoard : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ILeaderboard leaderboard = Social.CreateLeaderboard();
        leaderboard.id = "Leaderboard012";
        leaderboard.LoadScores(result =>
        {
            Debug.Log("Recieved " + leaderboard.scores.Length + " scores");
            foreach (IScore score in leaderboard.scores)
                Debug.Log(score);
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
