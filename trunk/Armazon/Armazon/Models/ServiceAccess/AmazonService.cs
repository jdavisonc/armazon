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

        public List<Producto> searchProducts(string fullText, Tienda tienda)
        {
            List<Producto> list = new List<Producto>();
            ItemSearchRequest request = new ItemSearchRequest();
            request.SearchIndex = "All";
            request.Keywords = fullText;
            //request.Power = "title: " + fullText;
            request.ResponseGroup = new string[] { "Small", "Images", "Offers" };
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
                        Producto p = new Producto();
                        p.Tienda = tienda;
                        p.Nombre = item.ItemAttributes.Title;
                        p.ExternalID = item.ASIN;
                        //string gg = item.OfferSummary.LowestNewPrice.Amount;
                        p.Precio = float.Parse(item.OfferSummary.LowestNewPrice.Amount)/100;
                        //dt.Attrs.Add(new DTProductAttrString(-1,"Nombre", item.ItemAttributes.Title));
                        
                        //dt.Images.Add(new DTImagen(-1, item.ItemAttributes.Title, item.MediumImage.URL));
                        if (item.MediumImage != null)
                        {
                            Imagen img = new Imagen();
                            img.ImagenURL = item.MediumImage.URL;
                            p.Imagens.Add(img);
                        }
                        
                        list.Add(p);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                //throw new Exception("Service Access: AmazonService, Error: " + ex.Message);
                return list;
            }
        }

        public Producto getProduct(string externalID, Tienda tienda)
        {
            Producto p = null;

            ItemLookupRequest request = new ItemLookupRequest();
            request.IdType = ItemLookupRequestIdType.ASIN;
            request.ItemId = new string[] { externalID };
            request.ResponseGroup = new string[] { "Large", "ItemAttributes", "Images", "Offers" };

            ItemLookupRequest[] requests = new ItemLookupRequest[] { request };

            ItemLookup itemLookup = new ItemLookup();
            itemLookup.AssociateTag = _associateTag;
            itemLookup.SubscriptionId = _subscriptionId;
            itemLookup.Request = requests;

            try
            {
                ItemLookupResponse response = _aws.ItemLookup(itemLookup);
                Items info = response.Items[0];
                if (info.Item != null)
                {
                    Item[] items = info.Item;
                    if (items.Length > 0)
                    {
                        Item item = items[0];
                        p = new Producto();
                        p.Tienda = tienda;
                        p.Nombre = item.ItemAttributes.Title;
                        p.ExternalID = item.ASIN;
                        //string gg = item.OfferSummary.LowestNewPrice.Amount;
                        p.Precio = float.Parse(item.OfferSummary.LowestNewPrice.Amount) / 100;
                        //dt.Attrs.Add(new DTProductAttrString(-1,"Nombre", item.ItemAttributes.Title));
                        string pp = item.DetailPageURL;
                        
                        // Tags
                        if (item.Tags != null)
                        {
                            foreach (Armazon.AWS.Tag tag in item.Tags.Tag)
                            {
                                string ss = tag.Name;
                            }
                        }
                        //dt.Images.Add(new DTImagen(-1, item.ItemAttributes.Title, item.MediumImage.URL));
                        if (item.LargeImage != null)
                        {
                            Imagen img = new Imagen();
                            img.ImagenURL = item.LargeImage.URL;
                            p.Imagens.Add(img);
                        }
                        else if (item.MediumImage != null)
                        {
                            Imagen img = new Imagen();
                            img.ImagenURL = item.MediumImage.URL;
                            p.Imagens.Add(img);
                        }
                        return p;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Service Access: AmazonService, Error: " + ex.Message);
            }        
        }

        #endregion
    }
}
