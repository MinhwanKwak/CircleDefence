using UnityEngine;
using System.Collections.Generic;

namespace oddments
{
    [System.Serializable]
    public class LocallizeData
    {
        [SerializeField]
		private string _name;
		public string name
		{
			get { return _name;}
			set { _name = value;}
		}
		[SerializeField]
		private string _ko;
		public string ko
		{
			get { return _ko;}
			set { _ko = value;}
		}

    }

    [System.Serializable]
    public class Locallize : Table<LocallizeData, string>
    {
    }
}

