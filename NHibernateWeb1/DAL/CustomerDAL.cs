using NHibernate;
using NHibernate.Cfg;
using NHibernateWeb1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace NHibernateWeb1.DAL
{
    public class CustomerDAL
    {

        //Define the session factory, this is per database 
        ISessionFactory sessionFactory;
        /// <summary> 
        /// Method to create session and manage entities 
        /// </summary> 
        /// <returns></returns> 
        ISession OpenSession()
        {
            if (sessionFactory == null)
            {
                var cfg = new Configuration();
                var data = cfg.Configure(
                      HttpContext.Current.Server.MapPath(
                         @"nhibernate.cfg.xml"));
                cfg.AddDirectory(new System.IO.DirectoryInfo(
                      HttpContext.Current.Server.MapPath(@"Models\NHibernate\Mappings")));
                sessionFactory = data.BuildSessionFactory();
            }
            return sessionFactory.OpenSession();
        }
        public IList<Customer> GetCustomers()
        {
            IList<Customer> Customers;
            using (ISession session = OpenSession())
            {
                //NHibernate query 
                IQuery query = session.CreateQuery("from Customer");
                Customers = query.List<Customer>();
            }
            return Customers;
        }
        public Customer GetCustomerById(int Id)
        {
            Customer Cust = new Customer();
            using (ISession session = OpenSession())
            {
                Cust = session.Get<Customer>(Id);
            }
            return Cust;
        }
        public int CreateCustomer(Customer Cust)
        {
            int CustNo = 0;
            using (ISession session = OpenSession())
            {
                //Perform transaction 
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Save(Cust);
                    tran.Commit();
                }
            }
            return CustNo;
        }
        public void UpdateCustomer(Customer Cust)
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Update(Cust);
                    tran.Commit();
                }
            }
        }
        public void DeleteCustomer(Customer Cust)
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Delete(Cust);
                    tran.Commit();
                }
            }
        }
    }
}