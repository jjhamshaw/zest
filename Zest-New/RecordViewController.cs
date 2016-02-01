using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ZestNew
{
    partial class RecordViewController : UIViewController
    {
        Record currentRecord { get; set; }

        public RecordsTableViewController Delegate { get; set; }
        // will be used to Save, Delete later

        public RecordViewController(IntPtr handle)
            : base(handle)
        {

        }

        // when displaying, set-up the properties
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            btnSaveRecord.TouchUpInside += (sender, e) =>
            {
                // TODO: set currentRecord.ThreeThings
                currentRecord.SetThreeThings(txtFirstThing.Text, txtSecondThing.Text, txtThirdThing.Text);
                Delegate.SaveTask(currentRecord);
            };
            btnDeleteRecord.TouchUpInside += (sender, e) =>
            {
                Delegate.DeleteTask(currentRecord);
            };

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            lblCreatedDate.Text = currentRecord.FormattedCreatedDate;

            var threeThings = currentRecord.ThreeThings.ToArray();

            if (threeThings.Length > 0)
            {
                txtFirstThing.Text = threeThings[0];
                txtSecondThing.Text = threeThings[1];
                txtThirdThing.Text = threeThings[2];  
            }
        }

        // this will be called before the view is displayed
        public void SetRecord(RecordsTableViewController d, Record record)
        {
            Delegate = d;
            currentRecord = record;
        }
    }
}
