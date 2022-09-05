using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Personals;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Personals.DAL
{
    public static class PhotosDAL
    {
        public static String Insert(Photo item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModuleCode))
                return String.Format("ModuleCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ImageTypeCode))
                return String.Format("ImageTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ByteThumb.ToString()))
                return String.Format("ByteThumb {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.BytePoster.ToString()))
                return String.Format("BytePoster {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ByteFull.ToString()))
                return String.Format("ByteFull {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ByteOriginal.ToString()))
                return String.Format("ByteOriginal {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Notes))
                return String.Format("Notes {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    context.Photos.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Photo item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModuleCode))
                return String.Format("ModuleCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ImageTypeCode))
                return String.Format("ImageTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ByteThumb.ToString()))
                return String.Format("ByteThumb {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.BytePoster.ToString()))
                return String.Format("BytePoster {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ByteFull.ToString()))
                return String.Format("ByteFull {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ByteOriginal.ToString()))
                return String.Format("ByteOriginal {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Notes))
                return String.Format("Notes {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    context.Photos.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String DeletePermanently(Int32 Code)
        {
            if (String.IsNullOrEmpty(Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    var del = (from item in context.Photos where (item.Code == Code) select item).FirstOrDefault();
                    context.Photos.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Photo item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Personals].[SPPhotosDelete]" })
                    {
                        cmd.Parameters.AddWithValue("@Code", item.Code);
                        cmd.Parameters.AddWithValue("@Deleted", item.Deleted);
                        cmd.Parameters.AddWithValue("@DeletedOn", item.DeletedOn);
                        cmd.Parameters.AddWithValue("@DeletedBy", item.DeletedBy);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        return Messages.Deleted;
                    }
                }
            }
            catch (Exception ex)
            {
                return String.Format("{0}:\n{1}", ex.Message, Messages.Warning);
            }
        }
        public static List<Photo> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            List<Photo> objs = new List<Photo>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(AccountCode) & !String.IsNullOrEmpty(ScreenCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (PersonalEntities context = new PersonalEntities())
                    {
                        var item = context.SPPhotosSelect(Code, AccountCode, ScreenCode, Deleted).FirstOrDefault();
                        Photo items = new Photo
                        {
                            Code = item.Code,
                            AccountCode = item.AccountCode,
                            ScreenCode = item.ScreenCode,
                            ModuleCode = item.ModuleCode,
                            ImageTypeCode = item.ImageTypeCode,
                            ByteThumb = item.ByteThumb,
                            BytePoster = item.BytePoster,
                            ByteFull = item.ByteFull,
                            ByteOriginal = item.ByteOriginal,
                            Notes = item.Notes,
                            CreatedOn = item.CreatedOn,
                            CreatedBy = item.CreatedBy,
                            ModifiedOn = item.ModifiedOn,
                            ModifiedBy = item.ModifiedBy,
                            Deleted = item.Deleted,
                            DeletedOn = item.DeletedOn,
                            DeletedBy = item.DeletedBy
                        };
                        objs.Add(items);
                    }
                }
                else
                {
                    using (PersonalEntities context = new PersonalEntities())
                    {
                        var items = context.SPPhotosSelect(Code, AccountCode, ScreenCode, Deleted);
                        foreach (Photo item in items)
                        {
                            Photo x = new Photo
                            {
                                Code = item.Code,
                                AccountCode = item.AccountCode,
                                ScreenCode = item.ScreenCode,
                                ModuleCode = item.ModuleCode,
                                ImageTypeCode = item.ImageTypeCode,
                                ByteThumb = item.ByteThumb,
                                BytePoster = item.BytePoster,
                                ByteFull = item.ByteFull,
                                ByteOriginal = item.ByteOriginal,
                                Notes = item.Notes,
                                CreatedOn = item.CreatedOn,
                                CreatedBy = item.CreatedBy,
                                ModifiedOn = item.ModifiedOn,
                                ModifiedBy = item.ModifiedBy,
                                Deleted = item.Deleted,
                                DeletedOn = item.DeletedOn,
                                DeletedBy = item.DeletedBy
                            };
                            objs.Add(x);
                        }
                    }
                }
                return objs;
            }
            catch
            {
                return new List<Photo>();
            }
        }
    }
}
