using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class languageShift : MonoBehaviour
{
    public string keyName;
    public bool startChange = false;
    public bool textHelp;
    public TMP_Text textH;
    void Start()
    {
       
        if (textHelp)
        {
            textH = GetComponent<TextMeshProUGUI>();
			
        }

		 if (startChange)
            changeLang();
    }
    public void changeLang()
    {
        if (!textHelp)
        {
            Sprite spriteLang = Singleton.Instance.getTexture(keyName);
            GetComponent<UnityEngine.UI.Image>().sprite = spriteLang;
        }
        else
        {
            textH.text = Singleton.Instance.getText(keyName);
        }
    }
}
