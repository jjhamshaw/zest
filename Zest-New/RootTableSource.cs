using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;

namespace ZestNew
{
    public class RootTableSource : UITableViewSource
    {

        // there is NO database or storage of Tasks in this example, just an in-memory List<>
        Record[] tableItems;
        string cellIdentifier = "recordcell";
        // set in the Storyboard

        public RootTableSource(Record[] items)
        {
            tableItems = items; 
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            // in a Storyboard, Dequeue will ALWAYS return a cell, 
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            // now set the properties as normal
            cell.TextLabel.Text = tableItems[indexPath.Row].FormattedCreatedDate;

            return cell;
        }

        public Record GetItem(nint id)
        {
            return tableItems[id];
        }
    }

}
