using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.IRMS
{
    public static class clsCommon
    {
        public static Guid? Country(string CountryName)
        {
            if (CountryName.Trim() == string.Empty)
                return null;

            List<Country> lstCountry = null;
            Country objCountry = new Country();
            objCountry.CountryName = CountryName;
            objCountry.IsActive = true;
            lstCountry = CountryBLL.GetAll(objCountry);
            if (lstCountry.Count != 0)
                return lstCountry[0].CountryID;
            else
            {
                CountryBLL.Save(objCountry);
                return objCountry.CountryID;
            }
        }

        public static Guid? State(string StateName)
        {
            if (StateName.Trim() == string.Empty)
                return null;

            List<State> lstState = null;
            State objState = new State();
            objState.StateName = StateName;
            objState.IsActive = true;
            lstState = StateBLL.GetAll(objState);
            if (lstState.Count != 0)
                return lstState[0].StateID;
            else
            {
                StateBLL.Save(objState);
                return objState.StateID;
            }
        }

        public static Guid? City(string CityName)
        {
            if (CityName.Trim() == string.Empty)
                return null;

            List<City> lstCity = null;
            City objCity = new City();
            objCity.CityName = CityName;
            objCity.IsActive = true;
            lstCity = CityBLL.GetAll(objCity);
            if (lstCity.Count != 0)
                return lstCity[0].CityID;
            else
            {
                CityBLL.Save(objCity);
                return objCity.CityID;
            }
        }
    }
}