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
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class Meeting : Event
    { 
        public Meeting(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
          
        }
        private Company _Company;
        [ImmediatePostData]
        public Company Company
        {
            get => _Company;
            set => SetPropertyValue(nameof(Company), ref _Company, value);
        }

        private CompanyContact _PrimaryContact;
        [DataSourceProperty("Company.Contacts")]
        public CompanyContact PrimaryContact
        {
            get => _PrimaryContact;
            set => SetPropertyValue(nameof(PrimaryContact), ref _PrimaryContact, value);
        }
    }
}