using UnityEngine;
using System.Collections.Generic;

namespace oddments
{
    [System.Serializable]
    public class RunesData
    {
        [SerializeField]
		private int _idx;
		public int idx
		{
			get { return _idx;}
			set { _idx = value;}
		}
		[SerializeField]
		private int _order;
		public int order
		{
			get { return _order;}
			set { _order = value;}
		}
		[SerializeField]
		private string _name;
		public string name
		{
			get { return _name;}
			set { _name = value;}
		}
		[SerializeField]
		private string _short_desc;
		public string short_desc
		{
			get { return _short_desc;}
			set { _short_desc = value;}
		}
		[SerializeField]
		private string _long_desc;
		public string long_desc
		{
			get { return _long_desc;}
			set { _long_desc = value;}
		}
		[SerializeField]
		private int _value_base;
		public int value_base
		{
			get { return _value_base;}
			set { _value_base = value;}
		}
		[SerializeField]
		private int _value_time;
		public int value_time
		{
			get { return _value_time;}
			set { _value_time = value;}
		}
		[SerializeField]
		private int _cooltime;
		public int cooltime
		{
			get { return _cooltime;}
			set { _cooltime = value;}
		}
		[SerializeField]
		private int _point;
		public int point
		{
			get { return _point;}
			set { _point = value;}
		}

    }

    [System.Serializable]
    public class Runes : Table<RunesData, int>
    {
    }
}

