using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataManager : MonoBehaviour {
	
	public playerData play;
	public achievementManager achievs;
	
	void Start()
	{
		achievs=GetComponent<achievementManager>();
		play=GetComponent<saveManager>().player;
		//play.todosAchievments=achievs.todosAchievments;
	}
/*
	//comentarios deixados para utilizar como exemplo
	public void newGame(){
		play.totalJogos++;
		achievs.enviaLeader((long) play.totalJogos, GPGSIds.leaderboard_amount_of_towers);
	}

	public void newCube(){
		play.totalJogadas++;
		
		//achievments complete
		if (play.totalJogadas>999){
			achievs.completaAchiev(GPGSIds.achievement_stack_master);
		}else if (play.totalJogadas>499) {
			achievs.completaAchiev(GPGSIds.achievement_almost_there);
		}else if (play.totalJogadas>249) {
			achievs.completaAchiev(GPGSIds.achievement_here_i_come_chessus);
		}else if (play.totalJogadas>99) {
			achievs.completaAchiev(GPGSIds.achievement_are_we_there_yet);
		}else if (play.totalJogadas>49) {
			achievs.completaAchiev(GPGSIds.achievement_stacktastic);
		}else if (play.totalJogadas>24) {
			achievs.completaAchiev(GPGSIds.achievement_gettin_jiggy_wit_it);
		}else if (play.totalJogadas>9) {
			achievs.completaAchiev(GPGSIds.achievement_young_brother);
		}
	}



	public void perfectScore(){
		play.totalPerfect++;
		achievs.enviaLeader((long) play.totalPerfect, GPGSIds.leaderboard_perfect_fittings);
		if (play.totalPerfect>249){
			achievs.completaAchiev(GPGSIds.achievement_stairway_to_chessus);
		}else if (play.totalPerfect>99) {
			achievs.completaAchiev(GPGSIds.achievement_this_one_knows_what_to_do);
		}else if (play.totalPerfect>49) {
			achievs.completaAchiev(GPGSIds.achievement_holy_chessus);
		}else if (play.totalPerfect>24) {
			achievs.completaAchiev(GPGSIds.achievement_thats_the_way_chessus_likes_it);
		}else if (play.totalPerfect>9) {
			achievs.completaAchiev(GPGSIds.achievement_perfection);
		}
	}

	public void videoView(){
		play.totalVideos++;
		achievs.enviaLeader((long) play.totalVideos, GPGSIds.leaderboard_videos_watched);
		if (play.totalVideos>49){
			achievs.completaAchiev(GPGSIds.achievement_chessus_favorite);
		}else if (play.totalVideos>24) {
			achievs.completaAchiev(GPGSIds.achievement_this_one_knows_how_to_please_chessus);
		}else if (play.totalVideos>9) {
			achievs.completaAchiev(GPGSIds.achievement_can_i_do_it_chessus);
		}else if (play.totalVideos>0) {
			achievs.completaAchiev(GPGSIds.achievement_chickened_ut);
		}
	}

	public void moneyPaid(){
		//p.BuyLife();
		play.totalCompras++;
		achievs.enviaLeader((long) play.totalCompras, GPGSIds.leaderboard_power_ups_purchased);
	}

	public void bestScore(int score){
		achievs.enviaLeader((long) score, GPGSIds.leaderboard_tallest);
	}
	*/
}
