using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace ZestNew
{
	partial class RecordsTableViewController : UITableViewController
	{
		IEnumerable<Record> records;

		public RecordsTableViewController(IntPtr handle)
			: base(handle)
		{
			Title = "My Diary";
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "RecordSegue") { // set in Storyboard
				var navctlr = segue.DestinationViewController as RecordViewController;
				if (navctlr != null) {
					var source = TableView.Source as RootTableSource;
					var rowPath = TableView.IndexPathForSelectedRow;
					var item = source.GetItem(rowPath.Row);
					navctlr.SetRecord(this, item);
				}
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			btnAddRecord.Clicked += (sender, e) => {
				CreateRecord();
			};
		}


		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			//get items from db
			records = AppDelegate.Database.GetAll();

			// bind every time, to reflect deletion in the Detail view
			TableView.Source = new RootTableSource(records.ToArray());

			TableView.ReloadData();
		}

		public void CreateRecord()
		{
			var detail = Storyboard.InstantiateViewController("recordViewController") as RecordViewController;
			detail.Delegate = this;
			NavigationController.PushViewController(detail, true);
		}

		public void SaveRecord(Record record)
		{
			AppDelegate.Database.Save(record);
			NavigationController.PopViewController(true);
		}

		public void DeleteTask(Record record)
		{
			AppDelegate.Database.Delete(record.Id);
			NavigationController.PopViewController(true);
		}
	}
}
