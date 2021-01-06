using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler.iCalendar.Components;
using Solution_test.Module.BusinessObjects;

namespace Solution_test.Module.Controllers
{
    public class WebLinkController : ViewController<DetailView>
    {
        private StringPropertyEditor webSite;
        public WebLinkController()
        {
            TargetObjectType = typeof(Company);
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            webSite = View.FindItem("WebSite") as StringPropertyEditor;
            if (webSite?.Control != null)
            {
                webSite.Control.Font =
                    new System.Drawing.Font(webSite.Control.Font, System.Drawing.FontStyle.Underline);
                webSite.Control.ForeColor = System.Drawing.Color.Blue;
                webSite.Control.DoubleClick += Control_DoubleClick;
            }
        }

        protected override void OnDeactivated()
        {
            if (webSite?.Control != null)
            {
                webSite.Control.DoubleClick -= Control_DoubleClick;
            }
            base.OnDeactivated();
        }
        private void Control_DoubleClick(object sender, EventArgs e)
        {
            TextEdit edit = (TextEdit) sender;
            System.Diagnostics.Process.Start(edit.Text);
        }
    }
}
