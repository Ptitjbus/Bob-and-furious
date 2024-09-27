using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEndColliderEvent : OnEventStruct
{
    public override void OnEvent() {
        SceneManager.LoadSceneAsync(2);
    }
}
