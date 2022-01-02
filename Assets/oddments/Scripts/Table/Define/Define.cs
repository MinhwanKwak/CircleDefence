using UnityEngine;
using System.Collections.Generic;

namespace oddments
{
    [System.Serializable]
    public class DefineData
    {
        [SerializeField]
		private string _name;
		public string name
		{
			get { return _name;}
			set { _name = value;}
		}
		[SerializeField]
		private int _value;
		public int value
		{
			get { return _value;}
			set { _value = value;}
		}

    }

    [System.Serializable]
    public class Define : Table<DefineData, string>
    {
    }
}

