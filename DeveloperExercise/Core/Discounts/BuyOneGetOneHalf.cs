﻿using Core.Interfaces;
using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Discounts
{
    public class BuyOneGetOneHalf : IDiscount
    {
        public void ApplyDiscount(ref List<GroseryItem> scannedItems, ref List<SpecialDeal> specialDeals, ref int sum)
        {
            sum = 0;
            var prev = new List<GroseryItem>();
            var deal = specialDeals.FirstOrDefault(x => x.DealType == (DealTypes)Enum.Parse(typeof(DealTypes), "BuyOneGetOneHalfPrice"));
            for (int i = 0; i < scannedItems.Count; i++)
            {

                if (deal != null && deal.Items[0].Name==scannedItems[i].Name)
                {
                    prev.Add(scannedItems[i]);
                    scannedItems.Remove(scannedItems[i]);
                    i--;
                }
            }
            for (int i = 0; i < prev.Count; i++)
            {
                if (i % 2 != 0)
                {
                    sum += prev[i].PriceInClouds / 2;
                }
                else
                {
                    sum += prev[i].PriceInClouds;
                }

            }
        }
    }
}
