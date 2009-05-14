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
            request.SearchIndex = "All";
            request.Keywords = fullText;
            //request.Power = "title: " + fullText;
            //request.ResponseGroup = new string[] { "Small" };
            //request.Sort = "salesrank";

            ItemSearchRequest[] requests = new ItemSearchRequest[] { request };

            ItemSearch itemSearch = new ItemSearch();
            itemSearch.AssociateTag = _associateTag;
            itemSearch.SubscriptionId = _subscriptionId;
            itemSearch.Request = requests;

            try
            {
                ItemSearchResponse response = _aws.ItemSearch(itemSearch);
                Items info = response.Items[0];
                if (info.Item != null)
                {
                    Item[] items = info.Item;
                    for (int i = 0; i < items.Length; i++)
                    {
                        Item item = items[i];
                        DTProduct dt = new DTProduct();
                        dt.Attrs.Add(new DTProductAttrString("Titulo", item.ItemAttributes.Title));
                        list.Add(dt);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Service Access: AmazonService, Error: " + ex.Message);
            }
        }

        #endregion
    }
}
