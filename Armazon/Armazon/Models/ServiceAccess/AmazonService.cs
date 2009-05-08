using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Armazon.Models.DataTypes;
using Armazon.AWS;

namespace Armazon.Models.ServiceAccess
{
    public class AmazonService : IAccessStore
    {
        private AWSECommerceServicePortTypeClient _aws = null;
        private const string _subscriptionId = "AKIAJRPGVMYFICCS3WUA";
        private const string _associateTag = "armtsifinpro-20";

        public AmazonService()
        {
            _aws = new AWSECommerceServicePortTypeClient();
        }

        #region IAccessStore Members

        public List<DTProduct> searchProducts(string fullText)
        {
            List<DTProduct> list = new List<DTProduct>();
            ItemSearchRequest request = new ItemSearchRequest();
            request.SearchIndex = "Books";
            request.Power = "title: " + fullText;
            request.ResponseGroup = new string[] { "Small" };
            request.Sort = "salesrank";

            ItemSearchRequest[] requests = new ItemSearchRequest[] { request };

            ItemSearch itemSearch = new ItemSearch();
            itemSearch.AssociateTag = _subscriptionId;
            itemSearch.SubscriptionId = _associateTag;
            itemSearch.Request = requests;

            try
            {
                ItemSearchResponse response = _aws.ItemSearch(itemSearch);
                Items info = response.Items[0];
                Item[] items = info.Item;
                for (int i = 0; i < items.Length; i++)
                {
                    Item item = items[i];
                    System.Console.WriteLine(item.ItemAttributes.Title);
                }
                return list;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                return null;
            }
        }

        #endregion
    }
}
