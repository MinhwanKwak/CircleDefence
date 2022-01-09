using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using oddments;

public class UserDataSystem
{
    public UserData userdata { get; private set; }


    public void Create()
    {
        if (userdata == null)
        {
            userdata = new UserData();
        }
        userdata.Create();
    }

    public void SaveUserData()
    {
        GameRoot.Instance.UserDataSystem.SaveData();
    }

    public void LoadUserData()
    {
        UserData data = GameRoot.Instance.UserDataSystem.LoadData();

        if (data != null)
        {
            userdata.CurStageIdx = data.CurStageIdx;
        }
    }

    private void SaveData()
    {
        if (GameRoot.Instance.UserDataSystem.userdata != null)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/UserData.json";
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, GameRoot.Instance.UserDataSystem.userdata);
            stream.Close();
        }
    }

    private UserData LoadData()
    {
        string path = Application.persistentDataPath + "/UserData.json";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UserData data = formatter.Deserialize(stream) as UserData;

            stream.Close();
            return data;

        }
        else
        {
            Debug.Log("not found file" + path);
            return null;
        }
    }
}
