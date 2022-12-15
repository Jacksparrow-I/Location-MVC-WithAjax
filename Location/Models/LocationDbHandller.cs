using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Location.Models
{
    public class LocationDbHandller
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["ServiceRequestconn"].ToString();
            con = new SqlConnection(constring);
        }

        public List<Locations> GetLocationsList()
        {
            connection();
            List<Locations> Locationslist = new List<Locations>();

            SqlCommand cmd = new SqlCommand("GetAllLocations", con);
            //cmd.Parameters.AddWithValue("@CompanyId", CompanyId);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Locationslist.Add(
                    new Locations
                    {
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        CountryName = Convert.ToString(dr["CountryName"]),
                        //StateId = Convert.ToInt32(dr["StateId"]),
                        StateName = Convert.ToString(dr["StateName"]),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        CityName = Convert.ToString(dr["CityName"])
                    });
            }
            return Locationslist;
        }

        public List<Locationssave> GetLocation()
        {
            connection();
            List<Locationssave> Locationslist = new List<Locationssave>();

            SqlCommand cmd = new SqlCommand("GetAllLocations", con);
            //cmd.Parameters.AddWithValue("@CompanyId", CompanyId);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Locationslist.Add(
                    new Locationssave
                    {
                        CountryId = Convert.ToInt32(dr["CountryId"]),
                        CountryName = Convert.ToString(dr["CountryName"]),
                        StateId = Convert.ToInt32(dr["StateId"]),
                        StateName = Convert.ToString(dr["StateName"]),
                        CityName = Convert.ToString(dr["CityName"])
                    });
            }
            return Locationslist;
        }

        public List<StateLocations> GetAllStateLocation(StateLocations CompanyId)
        {
            connection();
            List<StateLocations> Locationslist = new List<StateLocations>();

            SqlCommand cmd = new SqlCommand("GetAllLocations", con);
            cmd.Parameters.AddWithValue("@CompanyId", CompanyId);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Locationslist.Add(
                    new StateLocations
                    {
                        CountryId = Convert.ToInt32(dr["CountryId"]),
                        StateId = Convert.ToInt32(dr["ServiceRequestId"]),
                        StateName = Convert.ToString(dr["StateName"])
                    });
            }
            return Locationslist;
        }


        public List<Locationssave> GetStateLocationByCountry(string CountryName)
        {
            connection();
            List<Locationssave> Locationslist = new List<Locationssave>();

            //GetByLocationID(Location);
            var cid = CountryName;

            SqlCommand cmd = new SqlCommand("GetAllStateByCountry", con);
            cmd.Parameters.AddWithValue("@CompanyId", cid);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Locationslist.Add(
                    new Locationssave
                    {
                        CountryId = Convert.ToInt32(dr["CountryId"]),
                        StateId = Convert.ToInt32(dr["StateId"]),
                        StateName = Convert.ToString(dr["StateName"])
                    });
            }
            return Locationslist;
        }


        public List<Locationssave> GetCityLocationByState(string CountryName, string StateName)
        {
            connection();
            List<Locationssave> Locationslist = new List<Locationssave>();

            //GetByLocationID(Location);
            var cid = CountryName;
            var sid = StateName;

            SqlCommand cmd = new SqlCommand("GetAllCityByState", con);
            cmd.Parameters.AddWithValue("@StateId", sid);
            cmd.Parameters.AddWithValue("@CountryId", cid);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Locationslist.Add(
                    new Locationssave
                    {
                        StateId = Convert.ToInt32(dr["StateId"]),
                        CityName = Convert.ToString(dr["CityName"])
                    });
            }
            return Locationslist;
        }


        public bool DeleteByCompanyId(string CountryId)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteCountry", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CountryId", CountryId);

            con.Open();
            int EnQ = cmd.ExecuteNonQuery();
            con.Close();

            if (EnQ >= 1)
                return true;
            else
                return false;
        }

        public List<Locationssave> GetByLocationID(Locationssave Location)
        {
            List<Locationssave> Locationslist = new List<Locationssave>();

            //if (Location.CountryName == "India")
            //{
            //    Location.CountryId = 1;
            //}
            //else if (Location.CountryName == "China")
            //{
            //    Location.CountryId = 2;
            //}
            //else if (Location.CountryName == "UnitedStates")
            //{
            //    Location.CountryId = 3;
            //}
            //else if (Location.CountryName == "Russian")
            //{
            //    Location.CountryId = 4;
            //}

            //if (StateName == "Gujarat" || StateName == "Beijing" || StateName == "Alabama" || StateName == "Buryat")
            //{
            //    StateName = "1";
            //}
            //else if (StateName == "Rajasthan" || StateName == "Chengdu" || StateName == "Colorado" || StateName == "Omsk")
            //{
            //    StateName = "2";
            //}
            //else if (StateName == "Punjab" || StateName == "Chongqing" || StateName == "New Jersey" || StateName == "Rostov")
            //{
            //    StateName = "3";
            //}
            //else if (StateName == "Bihar")
            //{
            //    StateName = "4";
            //}

            //if (StateName == "1" || StateName == "2" || StateName == "3" || StateName == "4")
            //{
            //    StateName = StateName;
            //}

            if (Location.StateName == "Gujarat" || Location.StateName == "Beijing" || Location.StateName == "Alabama" || Location.StateName == "Buryat")
            {
                Location.StateId = 1;
            }
            else if (Location.StateName == "Rajasthan" || Location.StateName == "Chengdu" || Location.StateName == "Colorado" || Location.StateName == "Omsk")
            {
                Location.StateId = 2;
            }
            else if (Location.StateName == "Punjab" || Location.StateName == "Chongqing" || Location.StateName == "New Jersey" || Location.StateName == "Rostov")
            {
                Location.StateId = 3;
            }
            else if (Location.StateName == "Bihar")
            {
                Location.StateId = 4;
            }

            if (Location.StateName == "1" || Location.StateName == "2" || Location.StateName == "3" || Location.StateName == "4")
            {
                Location.StateId = Convert.ToInt32(Location.StateName);
            }

            return Locationslist;
        }

    }
}