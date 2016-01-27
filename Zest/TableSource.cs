using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace Zest
{
	public class TableSource : UITableViewSource
	{
		readonly List<DiaryEntryModel> DiaryEntries;
		const string cellIndentifier = "Foo";

		public TableSource (List<DiaryEntryModel> DiaryEntries)
		{
			this.DiaryEntries = DiaryEntries;
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			
			var cell = tableView.DequeueReusableCell (cellIndentifier);
			var item = DiaryEntries.ElementAt (indexPath.Row);

			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIndentifier);
			}

			cell.TextLabel.Text = item.Title;

			return cell;
		}
		
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return DiaryEntries.Count;
		}
	}
}

