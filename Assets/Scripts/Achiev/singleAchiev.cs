using System;
using GooglePlayGames;
using UnityEngine;
[Serializable]

public class singleAchiev  {
public string nome;
public enum achievState
    {   
        notCompleted, completed, sended
    }
public achievState estado;

public singleAchiev(){
	estado=achievState.notCompleted;
}

public void sendMe(){
    if (estado==achievState.completed) {
        //Debug.Log("achiev ja completado");
        return;
    }
    
    #if UNITY_EDITOR
        estado=achievState.completed;
        //Debug.Log(nome + " completed");
    #elif UNITY_ANDROID
        Social.ReportProgress(nome,100, (bool success) => {
            if (success) estado=achievState.sended;
            else estado=achievState.completed;
        });
	#endif
}
}