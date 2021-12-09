using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Driver {
    public Driver() {
    }


    public async void WaitForSceneLoaded(string scenePath) {
        Scene scene = SceneManager.GetSceneByPath(scenePath);
        while (!scene.isLoaded) {
            await Task.Delay(1000);
        }
    }

    public async void Close() {
        Debug.Log("Shut down the running application. The Application.Quit call is ignored in the Editor.");
        Application.Quit();
    }

    public GameObject FindGameObject(object by, string name) {
        return GameObject.Find(name); //"/Monster/Arm/Hand"
    }

    public async Task Wait(int milliseconds) {
        await Task.Delay(milliseconds);
    }
}