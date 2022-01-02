using UnityEngine;
using System.Collections.Generic;

namespace oddments
{
    [System.Serializable]
    public class ElementData
    {
        [SerializeField]
		private int _idx;
		public int idx
		{
			get { return _idx;}
			set { _idx = value;}
		}
		[SerializeField]
		private int _correlation;
		public int correlation
		{
			get { return _correlation;}
			set { _correlation = value;}
		}

    }

    [System.Serializable]
    public class Element : Table<ElementData, int>
    {
    }
}

