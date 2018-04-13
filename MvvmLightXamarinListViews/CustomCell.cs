using System;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightXamarinListViews.Core;
using PureLayout.Net;
using UIKit;

namespace MvvmLightXamarinListViews
{
    public class CustomCell : UITableViewCell
    {
        CountdownViewItem _countdownViewItem;
        UILabel RemainingTimeLabel;

        public CustomCell(IntPtr handler) : base(handler)
        {

        }
        public CustomCell()
        {
            RemainingTimeLabel = new UILabel();
            AddSubview(RemainingTimeLabel);

            RemainingTimeLabel.AutoAlignAxisToSuperviewAxis(ALAxis.Horizontal);
            RemainingTimeLabel.AutoPinEdgeToSuperviewEdge(ALEdge.Left, 8);
            //RemainingTimeLabel.CenterYAnchor.ConstraintEqualTo(LayoutMarginsGuide.CenterYAnchor).Active = true;
            //RemainingTimeLabel.LeftAnchor.ConstraintEqualTo(LayoutMarginsGuide.LeftAnchor, 8).Active = true;
        }

        public Binding<string, string> _timerBinding;

        public override void PrepareForReuse()
        {
            base.PrepareForReuse();
            _timerBinding?.Detach();
        }

        internal void Configure(CountdownViewItem countdownViewItem)
        {
            _countdownViewItem = countdownViewItem;
            _timerBinding = this.SetBinding(() => _countdownViewItem.RemainingTimeString, () => RemainingTimeLabel.Text);
        }
    }
}