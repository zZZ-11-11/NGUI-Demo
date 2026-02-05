using System.Collections.Generic;
using UnityEngine;

public class LoginManager
{
    public static LoginManager instance { get; } = new LoginManager();

    public LoginData loginData { get; }

    public RegisterData registerData { get; }

    public List<ServerData> serverDatas { get; }

    private LoginManager()
    {
        loginData = JsonMgr.Instance.LoadData<LoginData>("LoginData");
        registerData = JsonMgr.Instance.LoadData<RegisterData>("RegisterData");
        serverDatas = JsonMgr.Instance.LoadData<List<ServerData>>("ServerInfo");
    }

    public void SaveLoginData()
    {
        JsonMgr.Instance.SaveData(loginData, "LoginData");
    }

    public void ClearLoginData()
    {
        loginData.frontSeverID = 0;
        loginData.autoLogin = false;
        loginData.rememberPw = false;
    }

    public void SaveRegisterData()
    {
        JsonMgr.Instance.SaveData(registerData, "RegisterData");
    }

    public bool Register(string userName, string password)
    {
        if (!registerData.registerInfo.TryAdd(userName, password))
        {
            return false;
        }
        SaveRegisterData();
        return true;
    }

    public bool CheckInfo(string userName, string password) =>
        registerData.registerInfo.ContainsKey(userName) && registerData.registerInfo[userName] == password;
}