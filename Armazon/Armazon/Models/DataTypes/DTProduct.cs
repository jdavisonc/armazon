﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class DTProduct
    {
        private int _id = -1;
        private IList<DTProductAttr> _attrs;
        private int _subcaterogiaID;
        private string _subcategoria;
        private int _caterogiaID;
        private string _categoria;
        private string _nombre;
        private double _precio;
        private int _tienda = -1;
        private string _externalID;
        private List<string> _tags;
        private List<DTImagen> _images;
        private List<DTComment> _comments;

        public List<DTComment> Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public string ExternalID
        {
            get { return _externalID; }
            set { _externalID = value; }
        }

        public List<DTImagen> Images
        {
            get { return _images; }
            set { _images = value; }
        }

        public List<string> Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }

        public int Tienda
        {
            get { return _tienda; }
            set { _tienda = value; }
        }

        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public int CaterogiaID
        {
            get { return _caterogiaID; }
            set { _caterogiaID = value; }
        }
        
        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }
        
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int SubcaterogiaID
        {
            get { return _subcaterogiaID; }
            set { _subcaterogiaID = value; }
        }
        

        public string Subcategoria
        {
            get { return _subcategoria; }
            set { _subcategoria = value; }
        }

        public IList<DTProductAttr> Attrs
        {
            get { return _attrs; }
            set { _attrs = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DTProduct()
        {
            _attrs = new List<DTProductAttr>();
            _images = new List<DTImagen>();
            _tags = new List<string>();
            _comments = new List<DTComment>();
        }
        
    }
}
