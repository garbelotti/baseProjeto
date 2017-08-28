using UnityEngine;
public class saveManager : MonoBehaviour
{

    public float version;
    public bool _restore;
    public bool saveTemp;
    public bool muteAudio;
    public AudioSource music;
    public playerData player;
    public achievementManager achievs;

    void Awake()
    {
        music = GetComponent<AudioSource>();
        achievs = GetComponent<achievementManager>();
        if (_restore)
        {
            float tver = PlayerPrefs.GetFloat("version", 0);
            if (tver > version)
            {
                Debug.Log("version do save mais nova q o apk");
            }
            if (version > tver)
            {
                Debug.Log("atualizacao d save");
            }
            if (version == tver)
            {
                Debug.Log("mesma versao save");
            }

            string data = PlayerPrefs.GetString("player_data", "");
            if (data == "")
            {
                player = new playerData();
                player.todosAchievments = achievs.inicia();
            }
            else
            {
                player = playerData.restauraDados(data);
                
                if (player.todosAchievments == null) player.todosAchievments = achievs.inicia();
                else
                {
                    //carregar achievments
                }
            }
        }
        else
        {
            player = new playerData();
            player.todosAchievments = achievs.inicia();
        }
        achievs.todosAchievments = player.todosAchievments;
    }
    void Start()
    {
                Singleton.Instance.savedLang=player.language;
                Singleton.Instance.linguaSaved();   
                backgroundMusic();
    }

    public void backgroundMusic(){
        if (!muteAudio) {
            music.Play();
        }
    }
    public void setNoads()
    {
        player.noAds = true;
    }
    void OnApplicationPause(bool pauseStatus)
    {
        gravaLocal();
    }
    void OnApplicationQuit()
    {
        gravaLocal();
    }
    public void gravaLocal()
    {
        float tver = PlayerPrefs.GetFloat("version", 0);

        Debug.Log("ver save: " + tver);
        if (tver < version)
        {
            //atualização save
        }

        PlayerPrefs.SetFloat("version", version);
        PlayerPrefs.SetInt("mute_audio", player.muteMusic ? 1 : 0);
        PlayerPrefs.SetString("player_data", player.salvaDados());
        PlayerPrefs.Save();
    }

    void Update()
    {
        if (saveTemp)
        {
            saveTemp = false;
            player.setNewValor((int)(UnityEngine.Random.value * 80));
            gravaLocal();
        }
    }
}