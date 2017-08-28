using System.Collections.Generic;
using UnityEngine;

public class achievementManager : MonoBehaviour {
	public List<singleAchiev> todosAchievments;
	public gServices google;
	void Start () {
		google=GetComponent<gServices>();
		Invoke("enviaAtrasado",2);
	}
	public void completaAchiev(string nome){
		foreach (singleAchiev s in todosAchievments)
		{
			if (s.nome == nome) {
				s.sendMe();
				
				return;
			}
		}
	}

	public void enviaLeader(long score, string leaderboardID){
		#if UNITY_EDITOR
       
        //Debug.Log(leaderboardID + " completed");
    	#elif UNITY_ANDROID
		 Social.ReportScore(score, leaderboardID, success => {
                //Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            });
		#endif
	}

	public void enviaAtrasado(){
		if (Social.localUser.authenticated)
		foreach (singleAchiev s in todosAchievments)
		{
			if (s.estado == singleAchiev.achievState.completed) {
				s.sendMe();
				//Debug.Log("enviando achiev "+s.nome);
				return;
			}
		}
	}

	public List<singleAchiev> inicia(){	//cria o vetor inicial 

		List<singleAchiev>
		todosAchievment = new List <singleAchiev>();
		singleAchiev n = new singleAchiev();
		n.nome = "A";//GPGSIds.achievement_stack_master;
		todosAchievment.Add(n);
		/*
		n = new singleAchiev();
		n.nome = GPGSIds.achievement_this_one_knows_what_to_do;
		todosAchievment.Add(n);
		*/
		return todosAchievment;

	}
}
