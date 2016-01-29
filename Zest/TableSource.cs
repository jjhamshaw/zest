using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using CoreText;

namespace Zest
{
	public class TableSource : UITableViewSource
	{
		readonly List<DiaryEntryModel> DiaryEntries;
		const string cellIndentifier = "Foo";

		public TableSource () : this(new List<DiaryEntryModel>()) {
		}

		public TableSource (List<DiaryEntryModel> diaryEntries)
		{
			DiaryEntries = diaryEntries;
		}

		public void InsertNew ()
		{
			DiaryEntries.Insert (0, new DiaryEntryModel (){
				CreatedDate = DateTime.Now
			});
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			
			var cell = tableView.DequeueReusableCell (cellIndentifier);
			var item = DiaryEntries.ElementAt (indexPath.Row);

			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIndentifier);
			}

			cell.TextLabel.Text = item.CreatedDate.ToString();

			return cell;
		}
		
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return DiaryEntries.Count;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var selected = DiaryEntries.Where<DiaryEntryModel> ((item, index) => index == indexPath.Row).First();
			var alertController = UIAlertController.Create ("Row selected", selected.Title, UIAlertControllerStyle.Alert);
			alertController.AddAction (UIAlertAction.Create ("OK", UIAlertActionStyle.Default, null));

			tableView.DeselectRow (indexPath, true);
		}
	}
}

