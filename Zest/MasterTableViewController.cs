using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace Zest
{
	partial class MasterTableViewController : UITableViewController
	{
		TableSource dataSource;

//		List<DiaryEntryModel> tableData;

		public MasterTableViewController (IntPtr handle) : base (handle)
		{
//			tableData = new List<DiaryEntryModel> {
//				new DiaryEntryModel {
//					CreatedDate = new DateTime(),
//					Title = "Test foo bar"
//				},
//				new DiaryEntryModel {
//					CreatedDate = new DateTime(),
//					Title = "Test Something"
//				}
//			};
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// set title
			NavigationItem.Title = "My Diary";

			NavigationItem.RightBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Add, AddNewItem);

			TableView.Source = dataSource = new TableSource ();
		}


		void AddNewItem (object sender, EventArgs args){
			dataSource.InsertNew ();
			// TODO: why?

			using (var indexPath = NSIndexPath.FromRowSection (0, 0)) {
				TableView.InsertRows (new [] { indexPath}, UITableViewRowAnimation.Automatic);
			}
		}

	}
}
