using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;

namespace ZestNew
{
    partial class RecordsTableViewController : UITableViewController
    {
        List<Record> records;

        public RecordsTableViewController(IntPtr handle)
            : base(handle)
        {
            Title = "My Diary";

            // Custom initialization
            records = new List<Record>
            {
                //          new Record() {Name="Groceries", Notes="Buy bread, cheese, apples", Done=false},
                //          new Record() {Name="Devices", Notes="Buy Nexus, Galaxy, Droid", Done=false}
            };

        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "RecordSegue")
            { // set in Storyboard
                var navctlr = segue.DestinationViewController as RecordViewController;
                if (navctlr != null)
                {
                    var source = TableView.Source as RootTableSource;
                    var rowPath = TableView.IndexPathForSelectedRow;
                    var item = source.GetItem(rowPath.Row);
                    navctlr.SetRecord(this, item);
                }
            }
        }

        public void CreateTask()
        {
            // first, add the task to the underlying data
            var newId = records.Count + 1;
            var newChore = new Record(){ Id = newId };
            records.Add(newChore);

            // then open the detail view to edit it
            var detail = Storyboard.InstantiateViewController("recordViewController") as RecordViewController;
            detail.SetRecord(this, newChore);
            NavigationController.PushViewController(detail, true);
        }

        public void SaveTask(Record chore)
        {
            var oldTask = records.Find(t => t.Id == chore.Id);
            if (oldTask != null)
            {
                records.Remove(oldTask);
                records.Add(chore);
            }
            NavigationController.PopViewController(true);
        }

        public void DeleteTask(Record chore)
        {
            var oldTask = records.Find(t => t.Id == chore.Id);
            records.Remove(oldTask);
            NavigationController.PopViewController(true);
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            btnAddRecord.Clicked += (sender, e) =>
            {
                CreateTask();
            };
        }


        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            // bind every time, to reflect deletion in the Detail view
            TableView.Source = new RootTableSource(records.ToArray());
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion

    }
}
