﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Service.ServiceImpl
{
    internal class OperationServiceImpl : IOperationService
    {
        //SqlConnection con = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=BankingDataBase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");

        public List<Operation> GetAllData(string procedure)
        {
            using (var myDb = new Model1())
            {
                var operationsProperties = myDb.Operations.Select(operation => new
                {
                    operation.OperationId,
                    operation.OperationTypeId,
                    operation.userId,
                    operation.OperationDate,
                    operation.Amount,
                    operation.CurrencyFrom,
                    operation.CurrencyTo,
                    operation.t_money
                }).ToList();

                List<Operation> myOperations = operationsProperties.Select(operationProp => new Operation
                {
                    OperationId = operationProp.OperationId,
                    OperationTypeId = operationProp.OperationTypeId,
                    userId = operationProp.userId,
                    OperationDate = operationProp.OperationDate,
                    Amount = operationProp.Amount,
                    CurrencyFrom = operationProp.CurrencyFrom,
                    CurrencyTo = operationProp.CurrencyTo,
                    t_money = operationProp.t_money
                }).ToList();

                return myOperations;
            }
        }

        public void AddNewDataInOperationsTable(object toSave)
        {
            //Operation operation = toSave as Operation;

            //try
            //{
            //    con.Open();

            //    SqlCommand sqlCommand = new SqlCommand("Operations_Insert", con);
            //    sqlCommand.CommandType = CommandType.StoredProcedure;
            //    sqlCommand.Parameters.AddWithValue("OperationTypeId", operation.OperationTypeId);
            //    sqlCommand.Parameters.AddWithValue("UserId", operation.userId);
            //    sqlCommand.Parameters.AddWithValue("OperationDate", operation.OperationDate);
            //    sqlCommand.Parameters.AddWithValue("Amount", operation.Amount);
            //    sqlCommand.Parameters.AddWithValue("CurrencyFrom", operation.CurrencyFrom);
            //    sqlCommand.Parameters.AddWithValue("CurrencyTo", operation.CurrencyTo);
            //    sqlCommand.ExecuteNonQuery();

            //    MessageBox.Show("Data saved Successfull");
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

            Operation operation = toSave as Operation;

            try
            {
                using (var myDb = new Model1())
                {
                    Operation newOperation = new Operation
                    {
                        OperationTypeId = operation.OperationTypeId,
                        userId = operation.userId,
                        OperationDate = operation.OperationDate,
                        Amount = operation.Amount,
                        CurrencyFrom = operation.CurrencyFrom,
                        CurrencyTo = operation.CurrencyTo,
                        t_money = operation.t_money
                    };

                    // Add the new Operation
                    myDb.Operations.Add(newOperation);

                    // Save changes to the database
                    myDb.SaveChanges();
                }

                MessageBox.Show("Data saved successfully");
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                MessageBox.Show("Data saved unsuccessfully " + ex.Message);
            }
        }

        public void UpdateDataInOperationsTable(object toSave)
        {
        //    Operation operation = toSave as Operation;

        //    try
        //    {
        //        con.Open();

        //        SqlCommand sqlCommand = new SqlCommand("Operations_Update", con);
        //        sqlCommand.CommandType = CommandType.StoredProcedure;
        //        sqlCommand.Parameters.AddWithValue("OperationId", operation.OperationId);
        //        sqlCommand.Parameters.AddWithValue("OperationTypeId", operation.OperationTypeId);
        //        sqlCommand.Parameters.AddWithValue("UserId", operation.userId);
        //        sqlCommand.Parameters.AddWithValue("OperationDate", operation.OperationDate);
        //        sqlCommand.Parameters.AddWithValue("Amount", operation.Amount);
        //        sqlCommand.Parameters.AddWithValue("CurrencyFrom", operation.CurrencyFrom);
        //        sqlCommand.Parameters.AddWithValue("CurrencyTo", operation.CurrencyTo);
        //        sqlCommand.ExecuteNonQuery();

        //        MessageBox.Show("Data updated Successfull");
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

            Operation operation = toSave as Operation;

            try
            {
                using (var myDb = new Model1())
                {
                    Operation existingOperation = myDb.Operations.Find(operation.OperationId);

                    if (existingOperation != null)
                    {
                        // Update
                        existingOperation.OperationTypeId = operation.OperationTypeId;
                        existingOperation.userId = operation.userId;
                        existingOperation.OperationDate = operation.OperationDate;
                        existingOperation.Amount = operation.Amount;
                        existingOperation.CurrencyFrom = operation.CurrencyFrom;
                        existingOperation.CurrencyTo = operation.CurrencyTo;

                        // Save changes
                        myDb.SaveChanges();

                        MessageBox.Show("Data updated successfully");
                    }
                    else
                    {
                        MessageBox.Show("Operation not found");
                    }
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                MessageBox.Show("Data updated unsuccessfully " + ex.Message);
            }
        }

        public decimal transferMoney(decimal amount, decimal rate)
        {
            return amount * rate;
        }
      
        public decimal SearchRateFromExchangeRates(string currencyFrom, string currencyTo)
        {
            using (var myDb = new Model1())
            {
                var query = myDb.ExchangeRates
                    .FirstOrDefault(exchangeRate => exchangeRate.CurrencyFrom == currencyFrom &&
                                            exchangeRate.CurrencyTo == currencyTo &&
                                            exchangeRate.IsActive);

                //Handle Null exception
                if (query == null) return 0.0m;

                return query.Rate;
            }
        }

    }
}
