using UnityEngine;
using System.Collections.Generic;

namespace oddments
{
    [System.Serializable]
    public class ChapterData
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
		private string _start_story_script_1;
		public string start_story_script_1
		{
			get { return _start_story_script_1;}
			set { _start_story_script_1 = value;}
		}
		[SerializeField]
		private string _end_story_script_2;
		public string end_story_script_2
		{
			get { return _end_story_script_2;}
			set { _end_story_script_2 = value;}
		}

    }

    [System.Serializable]
    public class Chapter : Table<ChapterData, int>
    {
    }
}

