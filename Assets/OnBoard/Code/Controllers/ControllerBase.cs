using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace OnBoard.Controller
{
    public class ControllerBase : MonoBehaviour
    {
        static AsyncOperation asyncOps;

       public static AsyncOperation LoadScene(string sceneName)
        {
            asyncOps = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            asyncOps.allowSceneActivation = true;

            return asyncOps;
        }
    }
}
