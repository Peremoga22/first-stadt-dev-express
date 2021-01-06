using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Solution_test.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Company : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Company(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string companyName;
        [RuleRequiredField]
        [RuleUniqueValue]
        public string CompanyName
        {
            get => companyName;
            set => SetPropertyValue(nameof(CompanyName), ref companyName, value);
        }
        private string webSite;
        public string WebSite
        {
            get => webSite;
            set => SetPropertyValue(nameof(WebSite), ref webSite, value);
        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetPropertyValue(nameof(PhoneNumber), ref phoneNumber, value);
        }
        private string billingAddress;
        public string BillingAddress
        {
            get => billingAddress;
            set => SetPropertyValue(nameof(BillingAddress), ref billingAddress, value);
        }
        private string shippingAddress;
        public string ShippingAddress
        {
            get => shippingAddress;
            set => SetPropertyValue(nameof(ShippingAddress), ref shippingAddress, value);
        }
        private bool shipToBilling;
        [ImmediatePostData]
        public bool ShipToBilling
        {
            get => shipToBilling;
            set => SetPropertyValue(nameof(ShipToBilling), ref shipToBilling, value);
        }
        
        [DevExpress.ExpressApp.DC.Aggregated, Association]
        public XPCollection<CompanyContact> Contacts
        {
            get => GetCollection<CompanyContact>(nameof(Contacts));
        }
    }
}