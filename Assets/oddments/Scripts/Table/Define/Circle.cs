using UnityEngine;
using System.Collections.Generic;

namespace oddments
{
    [System.Serializable]
    public class CircleData
    {
        [SerializeField]
		private int _idx;
		public int idx
		{
			get { return _idx;}
			set { _idx = value;}
		}
		[SerializeField]
		private string _name;
		public string name
		{
			get { return _name;}
			set { _name = value;}
		}
		[SerializeField]
		private int _element_type;
		public int element_type
		{
			get { return _element_type;}
			set { _element_type = value;}
		}
		[SerializeField]
		private int _grade;
		public int grade
		{
			get { return _grade;}
			set { _grade = value;}
		}
		[SerializeField]
		private int _power;
		public int power
		{
			get { return _power;}
			set { _power = value;}
		}
		[SerializeField]
		private int _a_speed;
		public int a_speed
		{
			get { return _a_speed;}
			set { _a_speed = value;}
		}
		[SerializeField]
		private int _range;
		public int range
		{
			get { return _range;}
			set { _range = value;}
		}
		[SerializeField]
		private int _ability;
		public int ability
		{
			get { return _ability;}
			set { _ability = value;}
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
    public class Circle : Table<CircleData, int>
    {
    }
}

