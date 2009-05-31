using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Armazon.ArmazonWS;

namespace Armazon.Models.ServiceAccess
{
    // NOTE: If you change the interface name "IArmazonWS" here, you must also update the reference to "IArmazonWS" in Web.config.
    [ServiceContract]
    public interface IArmazonWS
    {

        [OperationContract]
        ICollection<DCProduct> search(String fullText);
        
        [OperationContract]
        DCProduct getProduct(int idProduct);
        
        [OperationContract]
        ICollection<DCRating> getRatings(int idProduct);

        [OperationContract]
        bool CartBuy(String user, ICollection<DCCartItem> items);

    }
}
