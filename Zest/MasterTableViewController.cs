using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Zest
{
	partial class MasterTableViewController : UITableViewController
	{
		public MasterTableViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			var table = new UITableView(View.Bounds);
			var mockDiaryEntries = new List<DiaryEntryModel> {
				new DiaryEntryModel {
					CreatedDate = new DateTime(),
					Title = "Test foo bar"
				},
				new DiaryEntryModel {
					CreatedDate = new DateTime(),
					Title = "Test Something"
				}
			};
			table.Source = new TableSource (mockDiaryEntries);
			Add (table);
		}
	}
}
