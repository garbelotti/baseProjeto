using UnityEngine;
public class gServices : MonoBehaviour
{
    public bool forceLogin;
    void Start()
    {
#if UNITY_EDITOR
        ;
#elif UNITY_ANDROID
			PlayGamesPlatform.Activate();
#endif
        Invoke("verDelay", 1.5f);
    }
    void Update()
    {

    }
    public void verDelay()
    {
        if (!Social.localUser.authenticated)
        {
            verOnline();
        }
        else if (forceLogin)
            Invoke("verDelay", 10);
    }
    public void verOnline()
    {
        if (!Social.localUser.authenticated)
        {
            Social.localUser.Authenticate((bool success) =>
         {
             if (success)
             {
             }
             else
             {
             }
         });
        }
        else verDelay();
    }
}
