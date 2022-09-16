using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SQT.FRAMEWORK.DAL.Linq;
using SQT.FRAMEWORK.DAL.Validation;
using SQT.Symphony.BusinessLogic.Configuration.DAL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.DAL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;

namespace SQT.Symphony.BusinessLogic.Configuration.BLL
{
    public class ExpenseBLL
    {
        static ExpenseBLL()
        {

        }
        public static List<Expense> GetAll(Expense objExpense)
        {
            ExpenseDAL _dataObject = new ExpenseDAL();
            return _dataObject.SelectAll(objExpense);
        }

        public static List<Expense> GetAllPropertyName(Expense objExpense)
        {
            ExpenseDAL _dataObject = new ExpenseDAL();
            return _dataObject.SelectAllPropertyName(objExpense);
        }

        public static List<Expense> GetAllVendorName(Expense objExpense)
        {
            ExpenseDAL _dataObject = new ExpenseDAL();
            return _dataObject.SelectAllVendorName(objExpense);
        }

        public static bool Save(Expense objExpense, List<Documents> expenseModificationDocuments, List<Expense> expenseDetail)
        {
            bool flag = false;
            ExpenseDAL _objExpense = null;
            DocumentsDAL _objDocuments = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objExpense = new ExpenseDAL(lt.Transaction);
                _objDocuments = new DocumentsDAL(lt.Transaction);
                if (objExpense != null)
                {
                    objExpense.ExpenseID = Guid.NewGuid();

                    if (!objExpense.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objExpense.BrokenRulesList.ToString());
                    }
                    flag = _objExpense.Insert(objExpense);

                    if (expenseDetail != null && expenseDetail.Count != 0)
                    {

                        foreach (Expense ExDetail in expenseDetail)
                        {
                            //ExDetail.PropertyExpenseDetailID = Guid.NewGuid();
                            ExDetail.PropertyExpenseDetailID = ExDetail.PropertyExpenseDetailID;
                            ExDetail.ExpenseID = objExpense.ExpenseID;
                            ExDetail.PropertyID = objExpense.PropertyID;
                            ExDetail.VendorID = ExDetail.VendorID;
                            ExDetail.PurchaseNote = ExDetail.PurchaseNote;
                            ExDetail.TotalAmount = ExDetail.TotalAmount;
                            ExDetail.PurchaseTypeTerm = ExDetail.PurchaseTypeTerm;
                            ExDetail.ItemTypeTerm = ExDetail.ItemTypeTerm;
                            if (!ExDetail.IsValid)
                            {
                                throw new InvalidBusinessObjectException(ExDetail.BrokenRulesList.ToString());
                            }
                            flag = _objExpense.MultiPleExpense_Insert(ExDetail);

                        }
                    }
                    if (expenseModificationDocuments != null && expenseModificationDocuments.Count != 0)
                    {
                        foreach (Documents item in expenseModificationDocuments)
                        {

                            item.DocumentID = Guid.NewGuid();
                            item.PropertyID = objExpense.PropertyID;
                            item.AssociationID = item.AssociationID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objDocuments.Insert(item);

                        }
                    }

                    if (flag)
                    {
                        lt.Commit();
                        return flag;
                    }
                    else
                    {
                        lt.Rollback();
                    }

                }
                else
                {
                    lt.Rollback();
                    throw new InvalidBusinessObjectException("Object Is NULL");
                }
            }
            catch
            {
                lt.Rollback();
                throw;
            }
            return flag;
        }

        public static DataSet GetExpenseData(string PropertyName)
        {
            ExpenseDAL _dataObject = new ExpenseDAL();
            DataSet ds = _dataObject.GetExpenseData(PropertyName);
            return ds;
        }

        public static DataSet GetByIdWise_ExpenseData(Guid ExpenseID)
        {
            ExpenseDAL _dataObject = new ExpenseDAL();
            DataSet ds = _dataObject.IdWiseExpenseData(ExpenseID);
            return ds;
        }

        public static bool Update(Expense objExpense, List<Documents> expenseModificationDocuments, List<Expense> expenseDetail)
        {
            bool flag = false;
            ExpenseDAL _objExpense = null;
            DocumentsDAL _objDocuments = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objExpense = new ExpenseDAL(lt.Transaction);
                if (objExpense != null)
                {
                    //objExpense.ExpenseID = Guid.NewGuid();

                    if (!objExpense.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objExpense.BrokenRulesList.ToString());
                    }
                    flag = _objExpense.Update(objExpense);

                    if (expenseDetail != null && expenseDetail.Count != 0)
                    {

                        foreach (Expense ExDetail in expenseDetail)
                        {
                            ExpenseDAL _dataObject = new ExpenseDAL();
                            DataSet ds = _dataObject.GetPropertyExpenseID(ExDetail.PropertyExpenseDetailID);
                            
                            if (ds.Tables[0].Rows.Count != 0)
                            {
                                ExDetail.PropertyExpenseDetailID = ExDetail.PropertyExpenseDetailID;
                                ExDetail.ExpenseID = objExpense.ExpenseID;
                                ExDetail.PropertyID = ExDetail.PropertyID;
                                ExDetail.VendorID = ExDetail.VendorID;
                                ExDetail.PurchaseNote = ExDetail.PurchaseNote;
                                ExDetail.TotalAmount = ExDetail.TotalAmount;
                                ExDetail.PurchaseTypeTerm = ExDetail.PurchaseTypeTerm;
                                ExDetail.ItemTypeTerm = ExDetail.ItemTypeTerm;
                                if (!ExDetail.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(ExDetail.BrokenRulesList.ToString());
                                }
                                flag = _objExpense.MultiPleExpense_Update(ExDetail);
                                _objDocuments = new DocumentsDAL(lt.Transaction);
                                _objDocuments.DeleteByAssociationID(ExDetail.PropertyExpenseDetailID);
                            }
                            else
                            {
                                ExDetail.PropertyExpenseDetailID = ExDetail.PropertyExpenseDetailID;
                                ExDetail.ExpenseID = objExpense.ExpenseID;
                                ExDetail.PropertyID = objExpense.PropertyID;
                                ExDetail.VendorID = ExDetail.VendorID;
                                ExDetail.PurchaseNote = ExDetail.PurchaseNote;
                                ExDetail.TotalAmount = ExDetail.TotalAmount;
                                ExDetail.PurchaseTypeTerm = ExDetail.PurchaseTypeTerm;
                                ExDetail.ItemTypeTerm = ExDetail.ItemTypeTerm;
                                if (!ExDetail.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(ExDetail.BrokenRulesList.ToString());
                                }
                                flag = _objExpense.MultiPleExpense_Insert(ExDetail);
                            }
                        }
                    }

                    if (expenseModificationDocuments != null && expenseModificationDocuments.Count != 0)
                    {
                        foreach (Documents item in expenseModificationDocuments)
                        {

                            item.DocumentID = Guid.NewGuid();
                            item.PropertyID = objExpense.ExpenseID;
                            item.AssociationID = item.AssociationID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objDocuments.Insert(item);
                        }
                    }
                   
                    if (flag)
                    {
                        lt.Commit();
                        return flag;
                    }
                    else
                    {
                        lt.Rollback();
                    }

                }
                else
                {
                    lt.Rollback();
                    throw new InvalidBusinessObjectException("Object Is NULL");
                }
            }
            catch
            {
                lt.Rollback();
                throw;
            }
            return flag;
        }

        public static bool Delete(Guid keys)
        {
            ExpenseDAL _dataObject = new ExpenseDAL();
            return _dataObject.Delete(keys);
        }
    }
}
