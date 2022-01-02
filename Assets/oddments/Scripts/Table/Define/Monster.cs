using UnityEngine;
using System.Collections.Generic;

namespace oddments
{
    [System.Serializable]
    public class MonsterData
    {
        [SerializeField]
		private int _idx;
		public int idx
		{
			get { return _idx;}
			set { _idx = value;}
		}
		[SerializeField]
		private int _monster_layer;
		public int monster_layer
		{
			get { return _monster_layer;}
			set { _monster_layer = value;}
		}
		[SerializeField]
		private int _element_type;
		public int element_type
		{
			get { return _element_type;}
			set { _element_type = value;}
		}
		[SerializeField]
		private int _hp_rate;
		public int hp_rate
		{
			get { return _hp_rate;}
			set { _hp_rate = value;}
		}
		[SerializeField]
		private int _m_speed;
		public int m_speed
		{
			get { return _m_speed;}
			set { _m_speed = value;}
		}
		[SerializeField]
		private int _ability_immune;
		public int ability_immune
		{
			get { return _ability_immune;}
			set { _ability_immune = value;}
		}
		[SerializeField]
		private int _point;
		public int point
		{
			get { return _point;}
			set { _point = value;}
		}
		[SerializeField]
		private string _icon;
		public string icon
		{
			get { return _icon;}
			set { _icon = value;}
		}

    }

    [System.Serializable]
    public class Monster : Table<MonsterData, int>
    {
    }
}

