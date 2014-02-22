using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class PortalAddress
    {

        #region Constructors

        public PortalAddress()
        {

        }

        //This is used to store the infn of the address data while retrieving
        public PortalAddress(DataRow AddressRow)
        {
            try
            {
                if (AddressRow.Table.Rows.Count > 0)
                {
                    //m_nAddressId = CommonFunctions.StringToInt(AddressRow["iAddressid"].ToString());
                    AddressId = CommonFunctions.StringToInt(AddressRow["iAddressid"].ToString());
                    AddressType = "Primary";
                    AddressLine1 = AddressRow["vAddress1"].ToString();
                    AddressLine2 = AddressRow["vAddress2"].ToString();
                    City = AddressRow["iCityId"].ToString();
                    State = AddressRow["vStateName"].ToString();
                    Country = "United States";
                    Zipcode = AddressRow["vZipcode"].ToString();


                }

            }
            catch
            {
                throw;
            }

        }

        #endregion

        #region Private members

        protected int m_nAddressId = 0;
        private string m_eAddressType = string.Empty;
        private int m_nObjectId = 0;
        private TypeOfOwner m_strObjectType = TypeOfOwner.None;
        private string m_strAddressLine1 = string.Empty;
        private string m_strAddressLine2 = string.Empty;
        private string m_strAddressLine3 = string.Empty;
        private string m_strState = string.Empty;
        private string m_strCity = string.Empty;
        private string m_strLocation = string.Empty;
        private string m_strCountry = string.Empty;
        private int m_strStateId = 0;
        private int m_strCountryId = 0;
        private string m_nZipcode = string.Empty;

        #endregion

        #region Properties

        public int AddressId
        {
            get { return m_nAddressId; }
            set { m_nAddressId = value; }
        }

        public string AddressType
        {
            get { return m_eAddressType; }
            set { m_eAddressType = value; }
        }
        public int ObjectId
        {
            get { return m_nObjectId; }
            set { m_nObjectId = value; }
        }
        public TypeOfOwner ObjectType
        {
            get { return m_strObjectType; }
            set { m_strObjectType = value; }
        }

        [StringLength(100)]
        public string AddressLine1
        {
            get { return m_strAddressLine1; }
            set { m_strAddressLine1 = value; }
        }

        [StringLength(100)]
        public string AddressLine2
        {
            get { return m_strAddressLine2; }
            set { m_strAddressLine2 = value; }
        }

        [StringLength(100)]
        public string AddressLine3
        {
            get { return m_strAddressLine3; }
            set { m_strAddressLine3 = value; }
        }

        [StringLength(50)]
        public string State
        {
            get { return m_strState; }
            set { m_strState = value; }
        }

        [StringLength(50)]
        public string City
        {
            get { return m_strCity; }
            set { m_strCity = value; }
        }

        [StringLength(50)]
        public string Location
        {
            get { return m_strLocation; }
            set { m_strLocation = value; }
        }

        [StringLength(50)]
        public string Country
        {
            get { return m_strCountry; }
            set { m_strCountry = value; }
        }

        [StringLength(10)]
        public string Zipcode
        {
            get { return m_nZipcode; }
            set { m_nZipcode = value; }
        }

        #endregion
    }

    public class PortalContact
    {
        #region Private members

        public string id = "";
        public int bearerid = 0;
        public string m_eContact { get; set; }
        public string title { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string officephone { get; set; }
        public string mobilephone { get; set; }
        public string fax { get; set; }
        public string emailaddress { get; set; }
        public string secondaryemail { get; set; }
        public string createby { get; set; }
        public DateTime createddate;
        public string modifiedby { get; set; }
        public DateTime modifieddate;
        public string m_strDayPhone = string.Empty;
        public string objecttype { get; set; }
      
        public string Companyname { get; set; }
        public string designation { get; set; }

        #endregion




        public PortalContact()
        {
            this.middlename = "";
            this.Companyname = "";
        }


    }


    public class portaluser
    {
        public string usermail { get; set; }
        public string userpassword { get; set; }
        public string usertitle { get; set; }
    }
}