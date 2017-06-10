using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    public class Contact : AuditableEntity<int>
    {
        private string name;
        private string lastName;
        private string email;
        private ContactStatus status;
        private Distributor distributor;

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public virtual string Email
        {
            get { return email; }
            set { email = value; }
        }

        public virtual ContactStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public virtual Distributor Distributor
        {
            get { return distributor; }
            set { distributor = value; }
        }

        public virtual string FullName
        {
            get { return name + " " + lastName; }
        }

        public virtual string InverseFullName
        {
            get { return lastName + ", " + name; }
        }

        public Contact() {}
        public Contact(string name, string lastName, string email)
        {
            this.name = name;
            this.lastName = lastName;
            this.email = email;
            this.status = ContactStatus.Active;
        }

        public virtual void ChangeStatus()
        {
            if (this.status == ContactStatus.Active)
                this.status = ContactStatus.Disable;
            else
                this.status = ContactStatus.Active;
        }

        public virtual void Activate()
        {
            this.status = ContactStatus.Active;
        }

        public virtual void Deactivate()
        {
            this.status = ContactStatus.Disable;
        }
    }
}
