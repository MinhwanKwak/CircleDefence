using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace oddments
{
    [System.Serializable]
    public class UserData
    {
        public int CurStageIdx;
        public bool IsCreate = false;



        public void Create()
        {
            var userdata = GameRoot.Instance.UserDataSystem.userdata;
       
            userdata.IsCreate = true;
        }
    }
}
