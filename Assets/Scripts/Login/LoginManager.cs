using UnityEngine;

public class LoginManager
{
    public static LoginManager instance { get; } = new LoginManager();

    public LoginData loginData { get; }

    public RegisterData registerData { get; }

    private LoginManager()
    {
        loginData = JsonMgr.Instance.LoadData<LoginData>("LoginData");
        registerData = JsonMgr.Instance.LoadData<RegisterData>("RegisterData");
    }

    public void SaveLoginData()
    {
        JsonMgr.Instance.SaveData(loginData, "LoginData");
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