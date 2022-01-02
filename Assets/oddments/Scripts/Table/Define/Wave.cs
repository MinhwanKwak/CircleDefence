using UnityEngine;
using System.Collections.Generic;

namespace oddments
{
    [System.Serializable]
    public class WaveData
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
		private int _monster_idx;
		public int monster_idx
		{
			get { return _monster_idx;}
			set { _monster_idx = value;}
		}
		[SerializeField]
		private int _champ;
		public int champ
		{
			get { return _champ;}
			set { _champ = value;}
		}
		[SerializeField]
		private int _increment_hp;
		public int increment_hp
		{
			get { return _increment_hp;}
			set { _increment_hp = value;}
		}

    }

    [System.Serializable]
    public class Wave : Table<WaveData, int>
    {
    }
}

