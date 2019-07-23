using UnityEngine;
using OnBoard.Services;

namespace OnBoard.Controller
{
    public class SplashController : MonoBehaviour
    {
        public LoadingIndicator LoadingIndicator;

        string version = "0.0";
        AsyncOperation loadingOps;

        private void Awake()
        {
            version = Application.version;
        }
        // Start is called before the first frame update
        void Start()
        {
            APIService.RequestCheckVersion("https://api.qmedia.com.br/api/", CheckDeviceOS(), version, (res) =>
            {
                if (CheckUserLoggedOn())
                {
                    loadingOps = ControllerBase.LoadScene("mainScene");
                    //Debug.Log("Logado");
                }
                else
                {
                    loadingOps = ControllerBase.LoadScene("loginScene");
                }
            });
        }

        // Update is called once per frame
        void Update()
        {
            if (loadingOps != null)
            {
                LoadingIndicator.gameObject.SetActive(true);
                LoadingIndicator.progress = loadingOps.progress;
            }
        }

        public string CheckDeviceOS()
        {
            var platform = Application.platform;

            if (platform.Equals(RuntimePlatform.WindowsEditor) || platform.Equals(RuntimePlatform.Android))
            {
                return "android";
            }

            return "ios";
        }

        bool CheckUserLoggedOn()
        {
            string QToken = Persistance.Persistance.BinaryLoad<string>("q-token");
            if(QToken == null)
            {
                return false;
            }
            return true;
        }

    }
}