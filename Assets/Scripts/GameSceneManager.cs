using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void  ReloadScene()
    {
        StartCoroutine(WaitForReload());

        


    }

    public IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(3f);

        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }
}
