﻿using Foundation;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightXamarinListViews.Core;
using PureLayout.Net;
using UIKit;

namespace MvvmLightXamarinListViews
{
    class ViewController : UIViewController
    {
        private ObservableTableViewController<CountdownViewItem> _tableViewController;
        private UITableView CountdownsTableView;
        private UIButton AddTimerButton;
        private MainViewModel Vm => Application.ViewModelLocator.MainViewModel;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            CountdownsTableView = new UITableView();
            CountdownsTableView.RegisterClassForCellReuse(typeof(CustomCell), nameof(CustomCell));

            AddTimerButton = new UIButton(UIButtonType.System);
            AddTimerButton.SetTitle("Add Countdown", UIControlState.Normal);

            View.AddSubview(CountdownsTableView);
            View.AddSubview(AddTimerButton);

            var parentMargins = View.LayoutMarginsGuide;
            CountdownsTableView.AutoPinEdgesToSuperviewEdgesExcludingEdge(ALEdge.Bottom);
            CountdownsTableView.AutoPinEdge(ALEdge.Bottom, ALEdge.Top, AddTimerButton, 16);

            AddTimerButton.AutoPinEdgesToSuperviewMarginsExcludingEdge(ALEdge.Top);

            //CountdownsTableView.TopAnchor.ConstraintEqualTo(parentMargins.TopAnchor).Active = true;
            //CountdownsTableView.LeftAnchor.ConstraintEqualTo(parentMargins.LeftAnchor).Active = true;
            //CountdownsTableView.RightAnchor.ConstraintEqualTo(parentMargins.RightAnchor).Active = true;
            //CountdownsTableView.BottomAnchor.ConstraintEqualTo(parentMargins.BottomAnchor).Active = true;

            //AddTimerButton.CenterXAnchor.ConstraintEqualTo(parentMargins.CenterXAnchor).Active = true;
            //AddTimerButton.BottomAnchor.ConstraintEqualTo(parentMargins.BottomAnchor, 8).Active = true;

            // Setup bindings
            _tableViewController = Vm.Countdowns.GetController(CreatePersonCell, BindCellDelegate);
            _tableViewController.TableView = CountdownsTableView;

            AddTimerButton.SetCommand("TouchUpInside", Vm.AddCountdownCommand);
        }

        private void BindCellDelegate(UITableViewCell cell, CountdownViewItem countdownViewItem, NSIndexPath path)
        {
            var bindableCell = (CustomCell) cell;
            bindableCell.Configure(countdownViewItem);
        }

        private UITableViewCell CreatePersonCell(NSString cellIdentifier)
        {
            return CountdownsTableView.DequeueReusableCell(nameof(CustomCell));
        }
    }
}
