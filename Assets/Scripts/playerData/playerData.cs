﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
[Serializable]
public class playerData{
public int valor0;
public int _totalVideos,_totalCompras,language=1;

public float tempoTotal,ultimoLogin;
public bool muteMusic,muteSFX,noAds;
public List<singleAchiev> todosAchievments;
Random rand = new Random();

public string salvaDados(){
        setNewValor(rand.Next(50,100));
		BinaryFormatter bf = new BinaryFormatter();
        MemoryStream str = new MemoryStream();
        bf.Serialize(str, this);
        string dadosT = Convert.ToBase64String(str.ToArray());	
		return dadosT;
}

public static playerData restauraDados(string S){	
	byte[] bytes = Convert.FromBase64String(S);
                MemoryStream str = new MemoryStream(bytes);
                BinaryFormatter bf = new BinaryFormatter();
                playerData dadosTemp = bf.Deserialize(str) as playerData;
                return dadosTemp;
}

public playerData(){
    valor0=rand.Next(50,100);
}

public playerData(int ran){
    valor0=ran;
}

public void setNewValor(int valor){
    int videosTemp=totalVideos;
    int comprasTemp=totalCompras;
    
    valor0=valor;
    totalVideos=videosTemp;
    totalCompras=comprasTemp;
}


public int totalVideos{
get	{ 	return _totalVideos/valor0;	}
set {   _totalVideos = value * valor0;  }
}

public int totalCompras{
get	{ 	return _totalCompras/valor0;	}
set {   _totalCompras = value * valor0;  }
}

}
