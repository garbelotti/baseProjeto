using UnityEngine;
public class saveManager : MonoBehaviour
{
    /*classe responsavel pelos controle dos dados armazenados, ela tambem e responsavel por dar o play (ou nao)
    na musica de background
    Funcionamento basico:
    no Awake, ela verifica se teve atualizacao de save, caso necessite de atualizacao de achievments e outras variaveis
    restaura tambem a classe serializable playerData, contendo as variaveis protegidas* do usuario
    a gravacao dos dados é feita no applicationpause e quit
    *a protecao dos dados é apenas para nao ser facil localizar as variaveis via editores de memoria (cheat engine)
    os gets e sets das variaveis funcionam da seguinte maneira: o dado gravado é sempre multiplicado por um valor (**rn),
    e quando eh pedido (lido), ele divide por esse valor, e a cada alteracao do dado, os valores d multiplicacao sao
    trocados.
    **ex: variavel money = 20 e rn = 10,
    qdo eu ler a variavel money ele retorna 20/10 = 2
    porem quando eu fizer um money+=10 ele vai gravar money+ = (10*20)
    e após esse processo é chamado a funcao newrandom, que faz os ajustes para "trocar" o valor d rn
    */
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