using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace oddments
{
    [System.Serializable]
    public class UserData
    {
        public int level;
        public int health;
        public int[] ExchangeDatas;
        public bool IsCreate = false;



        public void Create()
        {
            var userdata = GameRoot.Instance.UserDataSystem.userdata;
       
            userdata.level = 0;
            userdata.health = 0;
            userdata.ExchangeDatas = new int[10];
            userdata.IsCreate = false;
        }
    }
}
