using UnityEngine;
using System.Collections.Generic;

namespace oddments
{
    [System.Serializable]
    public class StageData
    {
        [SerializeField]
		private int _stage;
		public int stage
		{
			get { return _stage;}
			set { _stage = value;}
		}
		[SerializeField]
		private int _wave_idx;
		public int wave_idx
		{
			get { return _wave_idx;}
			set { _wave_idx = value;}
		}
		[SerializeField]
		private int _max_monster;
		public int max_monster
		{
			get { return _max_monster;}
			set { _max_monster = value;}
		}
		[SerializeField]
		private int _reward_type;
		public int reward_type
		{
			get { return _reward_type;}
			set { _reward_type = value;}
		}
		[SerializeField]
		private int _reward_value;
		public int reward_value
		{
			get { return _reward_value;}
			set { _reward_value = value;}
		}
		[SerializeField]
		private int _stage_increment_hp;
		public int stage_increment_hp
		{
			get { return _stage_increment_hp;}
			set { _stage_increment_hp = value;}
		}
		[SerializeField]
		private int _misson_idx;
		public int misson_idx
		{
			get { return _misson_idx;}
			set { _misson_idx = value;}
		}

    }

    [System.Serializable]
    public class Stage : Table<StageData, int>
    {
    }
}

