using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    string[,] items =
 
    {
 
     {"1","Bread","5","MO"},
 
     {"2","Pizza","6","NY"},
 
     {"3","Burger","7","TX"},
 
     {"4","Coke","8","CA"},
 
    
 
    };

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
 
    public string GetItem(string ItemID)
 
    {
 
     
 
     for (int i = 0; i < items.GetLength(0);i++)
 
     {
 
       if (String.Compare(ItemID,items[i,0],true) == 0)
 
         return items[i,1];
 
     }
 
     return "Item does not exist with this ID";
 
    }
 
    
 
 
    [WebMethod]
 
    public float GetPrice(string ItemID)
 
    {
 

 
     for (int i = 0; i < items.GetLength(0);i++)
 
     {
 
       if (String.Compare(ItemID,items[i,0],true) == 0)
 
         return float.Parse(items[i,2]);
 
     }
 
     return 0;
 
    }
 
 
 
    [WebMethod]
 
    public string GetPlace(string ItemID)
 
    {
 

 
     for (int i = 0; i < items.GetLength(0);i++)
 
     {
 
       if (String.Compare(ItemID,items[i,0],true) == 0)
 
         return items[i,3];
 
     }
 
     return "Item does not exist with this ID";
 
    }
 
    [WebMethod]
 
    public string[] GetAllItems()
 
    {
 

 
     string [] its = new string[items.GetLength(0)];
 
     for (int i = 0; i < items.GetLength(0);i++)
 
     {
 
       its[i]=items[i,0];
 
     }
 
     return its;
 
    }

}
