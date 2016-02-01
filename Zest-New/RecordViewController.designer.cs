// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ZestNew
{
	[Register ("RecordViewController")]
	partial class RecordViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnDeleteRecord { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSaveRecord { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblCreatedDate { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtFirstThing { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtSecondThing { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtThirdThing { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnDeleteRecord != null) {
				btnDeleteRecord.Dispose ();
				btnDeleteRecord = null;
			}
			if (btnSaveRecord != null) {
				btnSaveRecord.Dispose ();
				btnSaveRecord = null;
			}
			if (lblCreatedDate != null) {
				lblCreatedDate.Dispose ();
				lblCreatedDate = null;
			}
			if (txtFirstThing != null) {
				txtFirstThing.Dispose ();
				txtFirstThing = null;
			}
			if (txtSecondThing != null) {
				txtSecondThing.Dispose ();
				txtSecondThing = null;
			}
			if (txtThirdThing != null) {
				txtThirdThing.Dispose ();
				txtThirdThing = null;
			}
		}
	}
}
