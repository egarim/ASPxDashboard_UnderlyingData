using System;
using DevExpress.DashboardWeb;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Dashboards.Web;
using DevExpress.Persistent.Base;

namespace DrillDown.Module.Web
{
    // ...
    public class WebDashboardController : ObjectViewController<DetailView, IDashboardData>
    {
        private WebDashboardViewerViewItem dashboardViewerViewItem;
        protected override void OnActivated()
        {
            base.OnActivated();
            dashboardViewerViewItem = View.FindItem("DashboardViewer") as WebDashboardViewerViewItem;
            if (dashboardViewerViewItem != null)
            {
                if (dashboardViewerViewItem.DashboardControl != null)
                {
                    SetHeight(dashboardViewerViewItem.DashboardControl);
                }
                else
                {
                    dashboardViewerViewItem.ControlCreated += DashboardViewerViewItem_ControlCreated;
                }
            }
        }
        private void DashboardViewerViewItem_ControlCreated(object sender, EventArgs e)
        {
            SetHeight(((WebDashboardViewerViewItem)sender).DashboardControl);
        }
        private void SetHeight(ASPxDashboard dashboardControl)
        {
            dashboardControl.ClientSideEvents.BeforeRender = "onBeforeRender";
            dashboardControl.Height = 760;
        }
        protected override void OnDeactivated()
        {
            if (dashboardViewerViewItem != null)
            {
                dashboardViewerViewItem.ControlCreated -= DashboardViewerViewItem_ControlCreated;
                dashboardViewerViewItem = null;
            }
            base.OnDeactivated();
        }
    }
}