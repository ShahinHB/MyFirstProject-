﻿using MyFirst.Infrastructure.Interfaces;
using MyFirst.Infrastructure.Enums;
using MyFirst.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFirst.Infrastructure.Services
{
    public class MarketableService : IMarketable
    {
        #region Private Lists
        private List<Sale> _sales;
        private List<Product> _products;
        private List<SaleItem> _saleItems;
        #endregion

        #region Public Lists
        public List<Sale> Sales => _sales;
        public List<Product> Products => _products;
        public List<SaleItem> SaleItems => _saleItems;
        #endregion

        public MarketableService()
        {


            #region Product List
            _products = new List<Product>()
            {
                new Product // Tv Product
                {
                    ProductCode = 109665,
                    ProductName = "SAMSUNG 50-inch Class QLED Q60T Series",
                    ProductCategory = Category.Televisions,
                    ProductPrice = 699.99,
                    Count = 14
                },
                new Product // Phone Product
            {
                ProductCode = 105012,
                ProductName = "BLU G90 - 6.5” HD + Smartphone",
                ProductCategory = Category.Phones,
                ProductPrice = 290.48,
                Count = 67
            },
            new Product // Tablet Product
            {
                ProductCode = 103992,
                ProductName = "Amazon Fire 7 tablet ",
                ProductCategory = Category.Tablets,
                ProductPrice = 49.99,
                Count = 1
            },
            new Product // Phone Product
            {
                ProductCode = 175662,
                ProductName = "Xiaomi Mi 9 T Redmi K20",
                ProductCategory = Category.Phones,
                ProductPrice = 279,
                Count = 97

            },
            new Product // Videocard Product
            {
                ProductCode = 281883,
                ProductName = "Gigabyte GeForce RTX 2070 Gaming OC 8G",
                ProductCategory = Category.ComputerAccesories,
                ProductPrice = 1189,
                Count = 5
            },
            new Product // Book Product
            {
                ProductCode = 215615,
                ProductName = "Deadly Cross (Alex Cross Book 28)",
                ProductCategory = Category.Books,
                ProductPrice = 14.99,
                Count = 14
            },
            new Product
            {
                ProductCode = 221690,
                ProductName = "Cutiefox 3D Print Crew Neck Pullover Ugly Christmas Sweater Sweatshirts",
                ProductCategory = Category.Clothes,
                ProductPrice = 23.99,
                Count = 21
            }
            #endregion
        };
            _sales = new List<Sale>(){
                new Sale //first Sale
            #region Sale List
                {
                SaleNumber = 128103,
                SalePrice = 404.73,
                Date = new DateTime(2020, 11, 15),
                SaleItems = new List<SaleItem>()
                {
                    new SaleItem
                    {
                        SaleItemNumber= 0001,
                        SaleItemCount = 27,
                        ProductName =_products.Find(s=>s.ProductCode == 215615)

                    }

                }

            },
            new Sale //Second Sale
            {
                SaleNumber = 183910,
                SalePrice = 6696,
                Date = new DateTime(2020, 12, 30),
                SaleItems = new List<SaleItem>()
                {
                    new SaleItem
                    {
                        SaleItemNumber= 0002,
                        SaleItemCount = 2,
                        ProductName = _products.Find(s=>s.ProductCode == 175662)
                        
                    }
                }

            },
            new Sale {
                SaleNumber = 427819,
                SalePrice = 56026.94,
                Date = new DateTime(2020, 09, 22),
                SaleItems = new List<SaleItem>()
                {
                    new SaleItem
                    {
                        SaleItemNumber= 0003,
                        SaleItemCount = 47,
                        ProductName = _products.Find(s=>s.ProductCode == 281883)



                    },
                    new SaleItem
                    {
                        SaleItemNumber= 0004,
                        SaleItemCount = 6,
                        ProductName = _products.Find(s=>s.ProductCode == 221690)



                    }
                }

            },        
            #endregion
        };

        }

        #region All Methods
        public void AddSale(int code, int Count, int Number, DateTime Date) //Add new saling to Sale Table
        {
            List<SaleItem> saleItems = new List<SaleItem>();
            double price = 0;
            var product = _products.FindAll(p => p.ProductCode.Equals(code)).FirstOrDefault();
            var saleItem = new SaleItem();
            var Code = code;
            saleItem.SaleItemCount = Count;
            saleItem.ProductName = product;
            saleItem.SaleItemNumber = saleItems.Count + 1;
            saleItems.Add(saleItem);
            price += Count * saleItem.ProductName.ProductPrice;
            var saleNo = Number;
            var saleDate = Date;
            var sale = new Sale();
            sale.SaleNumber = saleNo;
            sale.SalePrice = price;
            sale.Date = saleDate;
            sale.SaleItems = saleItems;
            _sales.Add(sale);

       
        
    }
        public void AddProduct(Product product) //Add Product Information to Product Table
        {
            _products.Add(product);

        } 
        public List<Product> CategoryProduct(Category category) // if Product Category equal this Category, show this Product Information 
        {
            var list = _products.FindAll(s => s.ProductCategory == category).ToList();
            // if Fineded word(s) have a product name. Show this Product Information

            foreach (var item in list)
            {
                Console.WriteLine("Sayı: " + item.Count);
                Console.WriteLine("Kodu: " + item.ProductCode);
                Console.WriteLine("Adı: " + item.ProductName);
                Console.WriteLine("Qiyməti: " + item.ProductPrice);
                Console.WriteLine();
                Console.WriteLine();
            }
            return list;
        }

        public List<Product> ProductforTwoPrice(double StartPrice, double EndPrice)
        {

            var list = _products.FindAll(s => s.ProductPrice >= StartPrice && s.ProductPrice <= EndPrice).ToList();
            // if Product Price between StartPrice and EndPrice. Show this Product Information

            foreach (var item in list)
            {
                Console.WriteLine("Sayı: " + item.Count);
                Console.WriteLine("Kodu: " + item.ProductCode);
                Console.WriteLine("Adı: " + item.ProductName);
                Console.WriteLine("Qiyməti: " + item.ProductPrice);
                Console.WriteLine();
                Console.WriteLine();
            }

            return list;
        }  

        public List<Product> ChangeProductInfo(int Code) //Changed Product Name, Count, Category, Code
        {
            return _products.FindAll(p => p.ProductCode == Code).ToList();
            // fineded product which its Product Code equal this Code
        }

        public void RemoveProduct(int code) //remove product from table (Allproduct)
        {
            var ProductList = _products.ToList();
            var RemovedItem = ProductList.Find(r => r.ProductCode == code);
            _products.Remove(RemovedItem);
        }
        public void RemoveProductBySale(int salecode, int Removecount, int productcode) // removed finded Product from finded Sale
        {
            var prolist = _products.ToList();
            var salelist = _sales.ToList();

            var sale = salelist.Find(r => r.SaleNumber == salecode);

            bool findproduct = prolist.Exists(r => r.ProductCode == productcode);
            if (findproduct == true)
            {
                var list = prolist.Find(r => r.ProductCode == productcode);
                if (sale.SalePrice > list.ProductPrice * Removecount)
                {
                    sale.SalePrice -= list.ProductPrice * Removecount;

                }
                else if (sale.SalePrice == list.ProductPrice *Removecount)
                {
                    _sales.Remove(sale);
                }
            }
            return  ;

        }
        public List<Product> SearchingProduct(string Search) // searching all product which contains input symbol
        {
            var list = _products.FindAll(s => s.ProductName.Contains(Search)).ToList();
            foreach (var item in list)
            {
                Console.WriteLine("Sayı: " + item.Count);
                Console.WriteLine("Kodu: " + item.ProductCode);
                Console.WriteLine("Adı: " + item.ProductName);
                Console.WriteLine("Qiyməti: " + item.ProductPrice);
                Console.WriteLine("Kateqoriya: " + item.ProductCategory);
                Console.WriteLine();
                Console.WriteLine();
            }
            return list;
        }

        public List<Sale> TotalSaleDatebyDate(DateTime StartDate, DateTime EndDate) // if Product Saling Date between StartDate and EndDate.Show this Product Information
        {
            var list = _sales.FindAll(s => s.Date >= StartDate && s.Date <= EndDate).ToList();
            //finding this Product 
            foreach (var item in list)
            {
                Console.WriteLine("Satışın Nömrəsi: " + item.SaleNumber);
                Console.WriteLine("Ümumi məbləğ: " + item.SalePrice);
                Console.WriteLine("Satış edilən tarix: " + item.Date.ToString("dd.MM.yyyy"));
                Console.WriteLine("Sayı: " + item.SaleItems.Count);
                Console.WriteLine();
                Console.WriteLine();
            }
            return list;
        }

        public List<Sale> SearchingSaleForNumber(int Number) //if input Number equals any SaleNumber. Show this Sale Information
        {
            List<SaleItem> products = new List<SaleItem>();
            var list = _sales.FindAll(s => s.SaleNumber == Number).ToList();
            foreach (var item in list)
            {
                Console.WriteLine("Satışın Nömrəsi: " + item.SaleNumber);
                Console.WriteLine("Ümumi məbləğ: " + item.SalePrice);
                Console.WriteLine("Tarix: " + item.Date.ToString("dd.MM.yyyy"));
                Console.WriteLine("Satış miqdarı: " + item.SaleItems.Count());
                Console.WriteLine();
                
            }
           
            
            return list;
        }

        public List<Sale> TotalSaleForPrice(double StartPrice, double EndPrice) 
        {
            var list = _sales.FindAll(s => s.SalePrice >= StartPrice && s.SalePrice <= EndPrice).ToList();
            // if Product Price between StartPrice and EndPrice. Show this Product Information

            foreach (var item in list)
            {
                Console.WriteLine("Satışın Nömrəsi: " + item.SaleNumber);
                Console.WriteLine("Ümumi məbləğ: " + item.SalePrice);
                Console.WriteLine("Tarix: " + item.Date.ToString("dd.MM.yyyy"));
                Console.WriteLine("Satış miqdarı: " + item.SaleItems.Count());
                Console.WriteLine();
            }

            return list;
        }

        public List<Sale> TotalSaleForDate(DateTime Date)
        {
            //return _sales.Where(s => s.Date == Date).Sum(s => s.SalePrice);
            var list = _sales.FindAll(s => s.Date == Date).ToList();

            foreach (var item in list)
            {
                Console.WriteLine("Satışın Nömrəsi: " + item.SaleNumber);
                Console.WriteLine("Ümumi məbləğ: " + item.SalePrice);
                Console.WriteLine("Tarix: " + item.Date.ToString("dd.MM.yyyy"));
                Console.WriteLine("Satış miqdarı: " + item.SaleItems.Count());
                Console.WriteLine();
            }
            return list;
        }

        public void RemoveSale(int Number) //Removed Sale from table
        {
            var SalesList = _sales.ToList();
            var RemovedItem = SalesList.Find(p =>p.SaleNumber == Number);
            _sales.Remove(RemovedItem);
        }

        public List<SaleItem> ShowSaleItem(int saleNumber) //extending method
        {
            return _sales.Find(s => s.SaleNumber == saleNumber).SaleItems.ToList();
        }
        #endregion
    }
}