using UnityEngine;
using System.Collections.Generic;

namespace oddments
{
    [System.Serializable]
    public class MissionData
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
		private int _m_1;
		public int m_1
		{
			get { return _m_1;}
			set { _m_1 = value;}
		}
		[SerializeField]
		private int _m_2;
		public int m_2
		{
			get { return _m_2;}
			set { _m_2 = value;}
		}
		[SerializeField]
		private int _m_3;
		public int m_3
		{
			get { return _m_3;}
			set { _m_3 = value;}
		}
		[SerializeField]
		private int _m_4;
		public int m_4
		{
			get { return _m_4;}
			set { _m_4 = value;}
		}
		[SerializeField]
		private int _m_5;
		public int m_5
		{
			get { return _m_5;}
			set { _m_5 = value;}
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
    public class Mission : Table<MissionData, int>
    {
    }
}

