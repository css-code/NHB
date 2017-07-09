using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateWeb1.Models
{
    public class Customer
    {
        public virtual int ID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}