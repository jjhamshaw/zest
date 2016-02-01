using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;

namespace ZestNew
{
	public class Record
	{

		public Record()
		{			
			ThreeThings = new List<string>();
		}

		public int Id { get; set; }

		public DateTime CreatedDate { get; set; }

		public string FormattedCreatedDate {
			get {
				return CreatedDate.ToString("dd MMMM, yyyy");
			}
		}

		public List<string> ThreeThings { get; private set; }

		public void SetThreeThings(string one, string two, string three)
		{
			ThreeThings.Add(one);
			ThreeThings.Add(two);
			ThreeThings.Add(three);
		}
	}
}
