using System;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightXamarinListViews.Core;
using UIKit;

namespace MvvmLightXamarinListViews.Storyboard
{
    public partial class ViewController : UIViewController
    {
        private ObservableTableViewController<CountdownViewItem> _tableViewController;
        private MainViewModel Vm => Application.ViewModelLocator.MainViewModel;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Setup bindings

            _tableViewController = Vm.Countdowns.GetController(CreatePersonCell, BindCellDelegate);
            _tableViewController.TableView = CountdownsTableView;
            //CountdownsTableView.Source = new GenericTableViewSource<CountdownViewItem>(Vm.Countdowns, CreatePersonCell, BindCellDelegate);

            AddTimerButton.SetCommand("TouchUpInside", Vm.AddCountdownCommand);
        }

        private void BindCellDelegate(UITableViewCell cell, CountdownViewItem countdownViewItem, NSIndexPath path)
        {
            var bindableCell = (CustomCell)cell;
            bindableCell.Configure(countdownViewItem);
        }

        private UITableViewCell CreatePersonCell(NSString cellIdentifier)

            //private UITableViewCell CreatePersonCell(CountdownViewItem countdownViewItem)
        {
            return CountdownsTableView.DequeueReusableCell("TimerCell");
        }
    }
}