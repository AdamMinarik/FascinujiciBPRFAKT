using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    class EProjectItemList
    {
        private List<EProjectItem> itemList;



        public EProjectItemList()
        {
            this.itemList = new List<EProjectItem>();
        }

        public void add(EProjectItem item)
        {
            this.itemList.Add(item);
        }

        public int noOfItems()
        {
            return this.itemList.Count();
        }

        public EProjectItem getItem(long ID)
        {
            return itemList.Find(x => x.getItemID() == ID);
        }

        public List<EProjectItem> getWatchlist()
        {
            List<EProjectItem> watchList = new List<EProjectItem>();

            foreach (var item in itemList)
            { 
                if (item.watchlist == true)
                {
                    watchList.Add(item);
                };
            }

            return watchList;
        }

        public List<EProjectItem> getRemoved()
        {
            List<EProjectItem> removedList = new List<EProjectItem>();

            foreach (var item in itemList)
            {
                if (item.removedItem == true)
                {
                    removedList.Add(item);
                };
            }

            return removedList;
        }

        public List<EProjectItem> getnewChanges()
        {
            List<EProjectItem> newChangesList = new List<EProjectItem>();
            ERisk riskItem;
            EProjImpact projectImpactItem;
            EOpportunity opportunityItem;

            for (int i = 0; i < this.itemList.Count; i++)
            {
                //Risks
                if (itemList[i].GetType() == typeof(ERisk))
                {
                    riskItem = (ERisk)itemList[i];
                    if (riskItem.newChanges == true)
                    {
                        newChangesList.Add(riskItem);
                    }
                }
                //Project Impacts
                else if (itemList[i].GetType() == typeof(EProjImpact))
                {
                    projectImpactItem = (EProjImpact)itemList[i];
                    if (projectImpactItem.newChanges == true)
                    {
                        newChangesList.Add(projectImpactItem);
                    }
                }
                //Opportunities
                else if (itemList[i].GetType() == typeof(EOpportunity))
                {
                    opportunityItem = (EOpportunity)itemList[i];
                    if (opportunityItem.newChanges == true)
                    {
                        newChangesList.Add(opportunityItem);
                    }
                }
            }

            return newChangesList;
        }

    }
}

