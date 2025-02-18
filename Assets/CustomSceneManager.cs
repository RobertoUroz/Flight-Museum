using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public static class CustomSceneManager
{
    public delegate void SceneChange(string sceneName);

    public static event SceneChange LoadScene;
    public static event SceneChange UnloadScene;

    private static async UniTask LoadLevelAsync(string sceneName)
    {
        await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }

    public static async UniTask OnLoadSceneAsync(string newSceneName)
    {
        OnUnloadScene(newSceneName);
        await LoadLevelAsync(newSceneName);
        LoadScene?.Invoke(newSceneName);
    }

    private static void OnUnloadScene(string newSceneName)
    {
        UnloadScene?.Invoke(newSceneName);
    }
}
