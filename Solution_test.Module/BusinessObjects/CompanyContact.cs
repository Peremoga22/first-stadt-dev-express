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
using DevExpress.ExpressApp.ConditionalAppearance;

namespace Solution_test.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("Bo_Lead")]
    [DefaultProperty("FullName")]
    [Appearance("ActiveContact",Criteria = "Active = true",TargetItems ="*",FontStyle = System.Drawing.FontStyle.Bold)]
    public class CompanyContact : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CompanyContact(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           // Active = true;
            
        }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set => SetPropertyValue(nameof(FirstName), ref firstName, value);
        }
        private string lastName;
        public string LastName
        {
            get => lastName;
            set => SetPropertyValue(nameof(LastName), ref lastName, value);
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public string FullName
        {
            get => ObjectFormatter.Format($"{FirstName} {LastName}", this,
                EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty);
        }
        
        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetPropertyValue(nameof(PhoneNumber), ref phoneNumber, value);
        }
        private string emailAddress;
        public string EmailAddress
        {
            get => emailAddress;
            set => SetPropertyValue(nameof(EmailAddress), ref emailAddress, value);
        }

        private Company _Company;
        [Association]
        public Company Company
        {
            get => _Company;
            set => SetPropertyValue(nameof(Company), ref _Company, value);
        }
        private bool _Active;
        [ImmediatePostData]
        public bool Active
        {
            get => _Active;
            set => SetPropertyValue(nameof(Active), ref _Active, value);
        }
    }
}