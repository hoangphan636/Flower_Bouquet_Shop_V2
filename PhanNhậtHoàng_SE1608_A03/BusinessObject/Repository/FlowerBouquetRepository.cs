using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class FlowerBouquetRepository:IFlowerBouquet
    {

        public List<FlowerBouquet> GetFlowerBouquet()
        {
            var list = new List<FlowerBouquet>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.FlowerBouquets.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        //public FlowerBouquet FindFlowerBouquetById(string Email, string password)
        //{
        //    var list = new FlowerBouquet();
        //    try
        //    {
        //        using (var context = new FUFlowerBouquetManagementContext())
        //        {
        //            list = context.FlowerBouquets.FirstOrDefault(x => x.Email == Email && x.Password == password);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return list;
        //}
        //public int FindFlowerBouquetMaxId()
        //{
        //    try
        //    {
        //        using (var context = new FUFlowerBouquetManagementContext())
        //        {
        //            int maxId = context.FlowerBouquets.Max(FlowerBouquet => FlowerBouquet.FlowerBouquetId.Value);
        //            return maxId;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}


        public void SaveFlowerBouquet(FlowerBouquet FlowerBouquet)
        {

            try
            {
                using var context = new FUFlowerBouquetManagementContext();

                context.FlowerBouquets.Add(FlowerBouquet);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //public FlowerBouquet checkAdminLogin(string email, string password)
        //{
        //    var c = new FUFlowerBouquetManagementContext();
        //    FlowerBouquet admin = c.getDefaultAccounts();
        //    if (email == admin.Email && password == admin.Password)
        //    {
        //        return admin;
        //    }
        //    return null;
        //}

        public FlowerBouquet FindFlowerBouquetById(int id)
        {
            var list = new FlowerBouquet();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.FlowerBouquets.FirstOrDefault(x => x.FlowerBouquetId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        //public FlowerBouquet FindFlowerBouquetByEmail(string email)
        //{
        //    var list = new FlowerBouquet();
        //    try
        //    {
        //        using (var context = new FUFlowerBouquetManagementContext())
        //        {
        //            list = context.FlowerBouquets.FirstOrDefault(x => x.Email == email);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return list;
        //}

        public void UpdateFlowerBouquet(FlowerBouquet FlowerBouquet)
        {

            try
            {
                using var context = new FUFlowerBouquetManagementContext();

                context.FlowerBouquets.Update(FlowerBouquet);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void DeleteFlowerBouquet(FlowerBouquet FlowerBouquet)
        {

            try
            {
                using var context = new FUFlowerBouquetManagementContext();

                context.FlowerBouquets.Remove(FlowerBouquet);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
