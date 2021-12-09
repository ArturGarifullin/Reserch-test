using UnityEngine;
using UnityEngine.UI;


public class Test1 : Test {
    public void AlloGarraje() {
        Debug.Log("I will never run!");
    }

    public async void InvenoryTest() {
        Debug.Log("I am run!");
        await driver.Wait(4000);
        Debug.Log("wait 4 sec");
        driver.WaitForSceneLoaded("Assets/Scenes/Scene2.unity");
        GameObject btnGameobject = driver.FindGameObject("By.Name", "Start");

        var startButton = new ButtonElement(btnGameobject.GetComponent<Button>());
        startButton.Click();
        Debug.Log("Test finish");
    }
}