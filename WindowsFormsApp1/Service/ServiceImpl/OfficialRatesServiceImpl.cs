﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using WindowsFormsApp1.NBRMServiceReference;

namespace WindowsFormsApp1.Service.ServiceImpl
{
    internal class OfficialRatesServiceImpl : IOfficialRatesService
    {
        public void AddNewDataInOfficialRateTable(object toSave)
        {
            //OfficialRate officialRate = toSave as OfficialRate;

            //try
            //{
            //    con.Open();
            //    SqlCommand sqlCommand = new SqlCommand("OfficialRates_Insert", con);
            //    sqlCommand.CommandType = CommandType.StoredProcedure;
            //    sqlCommand.Parameters.AddWithValue("ValidityDate", officialRate.ValidityDate);
            //    sqlCommand.Parameters.AddWithValue("Currency", officialRate.Currency);
            //    sqlCommand.Parameters.AddWithValue("Rate", officialRate.Rate);
            //    sqlCommand.Parameters.AddWithValue("isActive", officialRate.isActive);
            //    sqlCommand.ExecuteNonQuery();

            //    MessageBox.Show("Data saved Successfull");
            //    con.Close();

            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

            OfficialRate officialRate = toSave as OfficialRate;

            try
            {
                using (var myDb = new Model1())
                {
                    // Create a new OfficialRate entity
                    OfficialRate newOfficialRate = new OfficialRate
                    {
                        ValidityDate = officialRate.ValidityDate,
                        Currency = officialRate.Currency,
                        Rate = officialRate.Rate,
                        isActive = officialRate.isActive
                    };

                    // Add the new OfficialRate entity to the DbContext
                    myDb.OfficialRates.Add(newOfficialRate);

                    // Save changes to the database
                    myDb.SaveChanges();
                }

                MessageBox.Show("Data saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data saved unsuccessfully" + ex.Message);
            }

        }
        public void UpdateDataInOfficialRatesTable(object toSave)
        {
            //OfficialRate officialRate = toSave as OfficialRate;
            //try
            //{
            //    con.Open();

            //    SqlCommand sqlCommand = new SqlCommand("OfficialRates_Update", con);
            //    sqlCommand.CommandType = CommandType.StoredProcedure;
            //    sqlCommand.Parameters.AddWithValue("OfficialRatesId", officialRate.OfficialRatesId);
            //    sqlCommand.Parameters.AddWithValue("ValidityDate", officialRate.ValidityDate);
            //    sqlCommand.Parameters.AddWithValue("Currency", officialRate.Currency);
            //    sqlCommand.Parameters.AddWithValue("Rate", officialRate.Rate);
            //    sqlCommand.Parameters.AddWithValue("isActive", officialRate.isActive);
            //    sqlCommand.ExecuteNonQuery();

            //    MessageBox.Show("Data updated Successfull");
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

            OfficialRate officialRate = toSave as OfficialRate;

            try
            {
                using (var myDb = new Model1())
                {
                    // Find officialRate
                    OfficialRate existingOfficialRate = myDb.OfficialRates.Find(officialRate.OfficialRatesId);

                    if (existingOfficialRate != null)
                    {
                        // Update
                        existingOfficialRate.ValidityDate = officialRate.ValidityDate;
                        existingOfficialRate.Currency = officialRate.Currency;
                        existingOfficialRate.Rate = officialRate.Rate;
                        existingOfficialRate.isActive = officialRate.isActive;

                        // Save changes to the database
                        myDb.SaveChanges();

                        MessageBox.Show("Data updated successfully");
                    }
                    else
                    {
                        MessageBox.Show("OfficialRate not found");
                    }
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                MessageBox.Show("Data updated successfully " + ex.Message);
            }
        }

        public List<OfficialRate> getAllData()
        {
            using (var myDb = new Model1())
            {
                var officialRatesProperties = myDb.OfficialRates.Select(officialRate => new
                {
                    officialRate.OfficialRatesId,
                    officialRate.ValidityDate,
                    officialRate.Currency,
                    officialRate.Rate,
                    officialRate.isActive,
                }).ToList();

                List<OfficialRate> myOfficialRates = officialRatesProperties.Select(officialProp => new OfficialRate
                {
                    OfficialRatesId = officialProp.OfficialRatesId,
                    ValidityDate = officialProp.ValidityDate,
                    Currency = officialProp.Currency,
                    Rate = officialProp.Rate,
                    isActive = officialProp.isActive
                }).ToList();

                return myOfficialRates;
            }
        }

        public void AddNBRMDataInDataBase()
        {
            var service = new KursSoapClient();
            string xmlResponse = service.GetExchangeRate(DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.AddDays(1).ToString("dd.MM.yyyy")); //Test global exception

            using (var myDb = new Model1())
            {
                using (var reader = new System.IO.StringReader(xmlResponse))
                {
                    var dataSet = new System.Data.DataSet();
                    dataSet.ReadXml(reader);


                    // Update existing rows to set isActive to false
                    //foreach (var existingRate in myDb.OfficialRates)
                    //{
                    //    existingRate.isActive = false;
                    //}

                    myDb.OfficialRates.ToList().ForEach(rate => rate.isActive = false);

                    foreach (System.Data.DataRow row in dataSet.Tables[0].Rows)
                    {
                        DateTime validityDate = Convert.ToDateTime(row["Datum"]);
                        string currency = row["Oznaka"].ToString();
                        decimal rate = Convert.ToDecimal(row["Sreden"]);
                        bool isActive = true;

                        var officialRate = new OfficialRate
                        {
                            ValidityDate = validityDate,
                            Currency = currency,
                            Rate = rate,
                            isActive = isActive
                        };

                        myDb.OfficialRates.Add(officialRate);
                    }

                    myDb.SaveChanges();
                }
            }
            MessageBox.Show("Latest OfficialRates downloaded!");
        }
    }
}
