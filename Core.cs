using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Remoting;
using System.Threading;
using System.Threading.Tasks;
using Object = System.Object;

public class Core : MonoBehaviour {
    public string CMD;

    Driver driver;

    void Awake() {
        //Инициализация
        Scene scene = SceneManager.GetActiveScene();
        driver = new Driver();
    }

    void Start() {
        
        //Какие тесты запустить (передаем -test run test1 из билда или из переменной публичной)
        string testName = "Test1";
        
        var oh = Activator.CreateInstance(Assembly.GetCallingAssembly().ToString(), testName);
        var test = (Test) oh.Unwrap();
        
        RunTestApp(test);
    }

    private async void RunTestApp(Test test) {
        test.Driver = driver;
        test.Before();
        await TestRun(test);
        test.After();
    }


    private Task<Test> TestRun(Test test) {
        Debug.LogWarning("Begin replay test ");
        RunAllTestMethods(test);
        var tcs = new TaskCompletionSource<Test>(test);
        return tcs.Task;
    }

    void RunAllTestMethods(Test test) {
        var methods = test.GetType()
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(item => item.Name.EndsWith("Test"));

        foreach (var method in methods) {
            method.Invoke(test, new Object[0]);
        }
    }
}