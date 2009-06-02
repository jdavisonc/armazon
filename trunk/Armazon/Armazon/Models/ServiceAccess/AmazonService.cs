using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Armazon.Models.DataTypes;
using Armazon.AWS;
using System.Reflection;

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
            int page = 1;
            List<Producto> list = new List<Producto>();

            while (page < 2)
            {

                ItemSearchRequest request = new ItemSearchRequest();

                request.SearchIndex = "All";
                request.Keywords = fullText;
                //request.Power = "title: " + fullText;
                request.ResponseGroup = new string[] { "Small", "Images", "Offers" };
                //request.Sort = "salesrank";
                request.ItemPage = page.ToString();

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
                        if (int.Parse(info.TotalPages) > 1)
                            page++;
                        for (int i = 0; i < items.Length; i++)
                        {
                            Item item = items[i];
                            Producto p = new Producto();
                            p.Tienda = tienda;
                            p.Nombre = item.ItemAttributes.Title;
                            p.ExternalID = item.ASIN;
                            //string gg = item.OfferSummary.LowestNewPrice.Amount;
                            float price = 0;
                            if (item.OfferSummary.LowestNewPrice.Amount != null)
                                price = float.Parse(item.OfferSummary.LowestNewPrice.Amount);
                            else if (item.OfferSummary.LowestRefurbishedPrice.Amount != null)
                                price = float.Parse(item.OfferSummary.LowestRefurbishedPrice.Amount);
                            else if (item.OfferSummary.LowestUsedPrice.Amount != null)
                                price = float.Parse(item.OfferSummary.LowestUsedPrice.Amount);
                            else if (item.OfferSummary.LowestCollectiblePrice.Amount != null)
                                price = float.Parse(item.OfferSummary.LowestCollectiblePrice.Amount);
                            p.Precio = price/100;
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
                }
                catch (Exception ex)
                {
                    //throw new Exception("Service Access: AmazonService, Error: " + ex.Message);
                    return list;
                }
            }
            return list;
        }

        public Producto getProduct(string externalID, Tienda tienda)
        {
            Producto p = null;

            ItemLookupRequest request = new ItemLookupRequest();
            request.IdType = ItemLookupRequestIdType.ASIN;
            request.ItemId = new string[] { externalID };
            request.ResponseGroup = new string[] { "Large", "ItemAttributes", "Images", "Offers", "Tags" };

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
                        Usuario uu = new Usuario();
                        uu.Nombre = tienda.Nombre;
                        //string gg = item.OfferSummary.LowestNewPrice.Amount;                            
                        float price = 0;
                        if (item.OfferSummary.LowestNewPrice.Amount != null)
                            price = float.Parse(item.OfferSummary.LowestNewPrice.Amount);
                        else if (item.OfferSummary.LowestRefurbishedPrice.Amount != null)
                            price = float.Parse(item.OfferSummary.LowestRefurbishedPrice.Amount);
                        else if (item.OfferSummary.LowestUsedPrice.Amount != null)
                            price = float.Parse(item.OfferSummary.LowestUsedPrice.Amount);
                        else if (item.OfferSummary.LowestCollectiblePrice.Amount != null)
                            price = float.Parse(item.OfferSummary.LowestCollectiblePrice.Amount);
                        p.Precio = price / 100;
                        //dt.Attrs.Add(new DTProductAttrString(-1,"Nombre", item.ItemAttributes.Title));

                        foreach (PropertyInfo infoe in item.ItemAttributes.GetType().GetProperties())
                        {
                            if (infoe.CanRead)
                            {
                                object os = infoe.GetValue(item.ItemAttributes, null);
                                if (os != null)
                                {
                                    Propiedad prop = new Propiedad();
                                    prop.Nombre = infoe.Name;
                                    Valor v = new Valor();
                                    v.PropiedadID = -1;
                                    v.Propiedad = prop;
                                    if (os.GetType() == typeof(string))
                                    {
                                        v.Valor1 = (string)os;
                                        p.Valors.Add(v);
                                    }
                                    else if (os.GetType() == typeof(string[]) && ((string[])os).Length > 0)
                                    {
                                        v.Valor1 = String.Join(", ", (string[])os);
                                        p.Valors.Add(v);
                                    }
                                }
                            }
                        } 


                        // Comentarios
                        if (item.CustomerReviews != null)
                        {
                            foreach (Review re in item.CustomerReviews.Review)
                            {
                                Producto_Usuario com = new Producto_Usuario();
                                com.Comentario = re.Content;
                                com.Usuario = uu;
                                com.Puntaje = double.Parse(re.Rating.ToString());
                                p.Producto_Usuarios.Add(com);
                            }
                        }
                        
                        // Tags
                        if (item.Tags != null)
                        {
                            foreach (Armazon.AWS.Tag tag in item.Tags.Tag)
                            {
                                Tag t = new Tag();
                                t.Nombre = tag.Name;
                                Producto_Tag pt = new Producto_Tag();
                                pt.Producto = p;
                                pt.Tag = t;
                                p.Producto_Tags.Add(pt);
                            }
                        }
                        //dt.Images.Add(new DTImagen(-1, item.ItemAttributes.Title, item.MediumImage.URL));
                        /*if (item.LargeImage != null)
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
                        }*/
                        foreach (ItemImageSets imgset in item.ImageSets)
                        {
                            foreach (ImageSet imgsetset in imgset.ImageSet)
	                        {
                                Imagen img = new Imagen();
                                img.ImagenURL = imgsetset.LargeImage.URL;
                                p.Imagens.Add(img);
	                        }
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

        public bool cartBuy(List<DCCartItem> cart, Tienda tienda)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
