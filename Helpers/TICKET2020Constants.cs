using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudApiWebApp.Helpers
{
    public static class TICKET2020Constants
    {
        #region Others
        public const string dateFormat = "dd-MM-yyyy"; 
        public const string dateTimeFormat = "dd-MM-yyyy hh:mm:ss";
        #endregion

        #region GSL
        public const int TYPE_COMPANY = 1;
        public const int TYPE_EMPLOYEE = 2;
        public const int TYPE_BUS = 3;
        public const int TYPE_VOUCHER = 4;
        public const int TYPE_POLICY = 5;
        #endregion

        #region LOOKUP
        public const string ATT_TYPE_LOGO = "LKUP000000054";
        public const string ADD_TYPE_PHONE = "LKUP000000032";
        public const string OUD_TYPE_BRANCH = "LKUP000000003";
        public const string OUD_TYPE_ROLE = "LKUP000000043";
        public const string BUS_RELATION = "LKUP000000021";
        public const string TRIP_RELATION = "LKUP000000020";
        public const string SEAT = "LKUP000000023";
        public const string AILE = "LKUP000000024";
        public const string EMPTY = "LKUP000000025";
        public const string ODD = "LKUP000000026";
        public const string SOLD = "LKUP000000027";
        public const string ROUTES_RELATION_TYPE = "LKUP000000046";
        public const string ROUTES_RELATION_SUB_ROUTE = "LKUP000000047";
        public const string TRIP_ROUTE_RELATION = "LKUP000000050";
        public const string TRIP_SUB_ROUTE_RELATION_LEVEL = "LKUP000000051";

        #endregion

        #region MODULE
        public const int MD_BACK_OFFICE = 1000;
        public const int MD_COMPANY_SETTING = 1001;
        public const int MD_EMPLOYE = 1002;
        public const int MD_BUS = 1003;
        public const int MD_TRIP = 1004;
        public const int MD_CUSTOMER = 1005;
        public const int MD_SALES = 1006;
        public const int MD_SECURITY = 1007;
        public const int MD_REPORT = 1008;
        #endregion

        #region CONFIGURATION ATTRIBUTES
        public const string PL_ENABLE_REFUND = "Enable Refund";
        public const string PL_REFUND_ACTIVE_HOUR = "Refund Active Hour";
        public const string PL_REFUND_PENALITY_PERCENTAGE = "Refund Penality";
        public const string PL_ENABLE_EXTENSSION = "Enable Extenssion";
        public const string PL_EXTENSSION_ACTIVE_HOURE = "Extenssion Active Hour";
        public const string PL_EXTENSSION_PENALITY_PERCENTAGE = "Extenssion Penality";
        public const string PL_ENABLE_CHILDREN_POLICY = "Enable Children Policy";
        public const string PL_CHILDREN_DISCOUNT_AMOUNT = "Children Discount";
        #endregion

        #region ACTIVITY DEFINITION DESCRIPTION
        public const string AD_MAINTAIN = "MAINTAIN";
        public const string AD_EDIT = "EDIT";
        public const string AD_DOCUMENT_BROWSE = "DOCUMENT BROWSE";
        public const string AD_EXPIRE = "EXPIRE";
        #endregion

        #region LOOKUP TYPES
        public const string BRANCH_SPECIALAIZETION = "BRANCH SPECIALAIZETION";
        public const string LT_ADDRESS = "ADDRESS TYPE";
        public const string LT_POSITIONS = "EMPLOYEE POSITION";
        public const string LT_GENDER = "GENDER";
        public const string LT_TITLES = "TITLE";
        public const string LT_BUS_RELATION_TYPE = "BUS RELATION TYPE";
        public const string LT_BUS_RELATION = "BUS RELATION";
        public const string LT_TRIP_RELATION_TYPE = "TRIP RELATION TYPE";
        public const string LT_TRIP_RELATION = "TRIP RELATION";
        public const string LT_CITY = "CITY";
        public const string LT_ROUTES_RELATION_TYPE = "ROUTE RELATION TYPE";
        public const string LT_ROUTES_RELATION = "ROUTE RELATION LEVEL";

        #endregion

        #region PREFERENCES
        public const string PREFERENCE_POLICY = "LKUP000000003";
        #endregion

        #region PREFERENCE TYPES
        public const string PT_BUS_TYPE = "BUS TYPE";
        #endregion

    }
}
