using Data;
using System;
using System.Collections.Generic;
using System.Text;
// using System.Data.Linq;


namespace Service
{
    class Store


    {
        private LinqToSqlDataContext db;


        public Store()
        {
            this.db = new LinqToSqlDataContext();
        }
        #region add
        public void AddUser(Person p)
        {
            db.Persons.InsertOnSubmit(p);
            db.SubmitChanges();

        }
        public void AddProduct(Product p)
        {
            db.Products.InsertOnSubmit(p);
            db.SubmitChanges();

        }
        public void AddEvent(Event e)
        {
            db.Events.InsertOnSubmit(e);
            db.SubmitChanges();


        }
        public void AddToInventory(Product p, int amount)
        {

        }
        #endregion

        #region create
        public void CreateUser(string firstName, string lastName, int userId)
        {

        }
        public void CreateProduct(string productName, double productPrice, int productId)
        { }

        public void CreateEvent(Person user, Product catalog, DateTimeOffset date) { }
        #endregion

        #region delete
        public void DeleteUser(Person u)
        {
            //var deleteperson =
            //    from person in db.Persons
            //    where person.id == u.id
            //    select person;

            //if (deleteperson.count() > 0)
            //{
            //    db.persons.deleteonsubmit(deleteperson.first());
            //    db.submitchanges();

            //}
        }
        public void DeleteProduct(Product p)
        {
            //var deleteProduct =
            //    from product in db.Products
            //    where product.Id == p.Id
            //    select person;

            //if (deleteProduct.Count() > 0)
            //{
            //    db.Products.DeleteOnSubmit(deleteProduct.First());
            //    db.SubmitChanges();

            //}
        }
        public void DeleteEvent(Event e)
        {
            //var deleteEvent =
            //    from event in db.Events
            //    where event.Id == e.Id
            //    select event;

            //if (deleteEvent.Count() > 0)
            //{
            //    db.Events.DeleteOnSubmit(deleteEvent.First());
            //    db.SubmitChanges();

            //}
        }
        #endregion

        #region update
        public void UpdateInventory(Product p, int amount) { }
        #endregion

        #region exists
        public Boolean ProductExists(Product p) { return true; }
        public Boolean UserExists(Person u) { return true; }
        public Boolean ProductExistsinInventory(Product p) { return true; }
        #endregion

        #region shop actions
        // buy an item -> creates an invoice, updates inventory
        public void BuyItem(Person user, Product product, int amount)
        {

        }

        #endregion
    }
}