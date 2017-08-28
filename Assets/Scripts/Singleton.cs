using UnityEngine;
using SmartLocalization;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
public class Singleton : MonoBehaviour
{

    private static Singleton _instance = null;
    public bool carregaDados, muteSound, noAds;
    public achievementManager achievs;
    public saveManager jogador;
    public int savedLang;
    private AsyncOperation async = null;
    public String SceneDestName = "gamePlay";
    
    public static Singleton Instance
    {
        get
        {
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            achievs = GetComponent<achievementManager>();
            DontDestroyOnLoad(gameObject);
            Screen.SetResolution(1280, 720, true);
            Application.targetFrameRate = 60;
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
            Screen.orientation = ScreenOrientation.AutoRotation;
            jogador = GetComponent<saveManager>();
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
            /*if (LanguageManager.HasInstance) {
				LanguageManager.Instance.OnChangeLanguage -= OnLanguageChanged;
			}*/
        }
    }
    private LanguageManager languageManager;
    private SmartCultureInfo atual;
    private List<string> currentLanguageKeys;
    private List<SmartCultureInfo> availableLanguages;
    void setBR()
    {
        languageManager.ChangeLanguage(availableLanguages[1]);
    }
    void setEN()
    {
        languageManager.ChangeLanguage(availableLanguages[0]);
    }
    void OnLanguageChanged(LanguageManager languageManager)
    {
        currentLanguageKeys = languageManager.GetAllKeys();
    }
    void Start()
    {

        languageManager = LanguageManager.Instance;
        SmartCultureInfo deviceCulture = languageManager.GetDeviceCultureIfSupported();
        if (deviceCulture != null)
        {
            languageManager.ChangeLanguage(deviceCulture);
        }
        else
        {
            Debug.Log("The device language is not available in the current application. Loading default.");
        }

        if (languageManager.NumberOfSupportedLanguages > 0)
        {
            currentLanguageKeys = languageManager.GetAllKeys();
            availableLanguages = languageManager.GetSupportedLanguages();
        }
        else
        {
            Debug.LogError("No languages are created!, Open the Smart Localization plugin at Window->Smart Localization and create your language!");
        }
        LanguageManager.Instance.OnChangeLanguage += OnLanguageChanged;
        //savedLang = 0;
        if (SceneManager.GetActiveScene().name=="introScene") {
            Invoke("loadScene",1);
        }

    }
    void Update()
    {

    }
    public string getText(string key)
    {
        return languageManager.GetTextValue(key);
    }
	
    public Sprite getTexture(string key)
    {
        Texture2D tempText = languageManager.GetTexture(key) as Texture2D;
        Rect rec = new Rect(0, 0, tempText.width, tempText.height);
        Sprite tempSpr = Sprite.Create(tempText, rec, new Vector2(0.5f, 0.5f), 100);
        return tempSpr;
    }

	public void linguaSaved(){
		languageManager.ChangeLanguage(availableLanguages[savedLang]);
		atualizaLingua();
	}
    public void atualizaLingua()
    {
        languageShift[] l = GameObject.FindObjectsOfType<languageShift>();
        foreach (languageShift lang in l)
        {
            lang.changeLang();
        }
    }
    public void loadScene()
    {

        /*loadP = (GameObject) Instantiate(loadPrefab);
		Canvas cn = loadP.GetComponent < Canvas > ();
		cn.worldCamera = GameObject.Find("Main Camera").GetComponent < Camera > ();
		loadP.transform.SetParent(gameObject.transform);*/
        sceneAsync();
    }
    public void sceneAsync()
    {
        async = SceneManager.LoadSceneAsync(SceneDestName);
        async.allowSceneActivation = false;
        StartCoroutine(LoadSceneCoroutine());
    }
    void OnApplicationQuit()
    {
        if (_instance == this)
        {

        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (_instance == this)
        {

        }
    }

    IEnumerator LoadSceneCoroutine()
    {
        while (!async.isDone)
        {
            if (async.progress < 0.90f)
            {

            }
            else
            {
                if (!async.allowSceneActivation)
                {
                    if (SceneManager.GetActiveScene().name != "Menu")
                    {

                    }
                }
                async.allowSceneActivation = true;

            }
            yield
            return null;
        }
        yield
        break;
    }

    public string converteK(int Value)
    {

        if (Value >= 1000000000)
        {
            return (Value / 1000000000D).ToString("0.##B");
        }

        if (Value >= 100000000)
        {
            return (Value / 1000000D).ToString("0.#M");
        }
        if (Value >= 1000000)
        {
            return (Value / 1000000D).ToString("0.##M");
        }
        if (Value >= 100000)
        {
            return (Value / 1000D).ToString("0.#K");
        }
        if (Value >= 1000)
        {
            return (Value / 1000D).ToString("0.##K");
        }

        return Value.ToString("#,0");
    }

}