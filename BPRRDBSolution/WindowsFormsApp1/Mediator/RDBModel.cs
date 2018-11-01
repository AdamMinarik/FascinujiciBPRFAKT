using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Mediator
{
    interface RDBModel
    {
        //GETS
        Project getProject(int projectID);
        EProjectItemList getItems(int projectID, String month, String type);
        EProjectItemList getFilterItems(int projectID, String month, String field, String fieldValue);
        EProjectItemList getRemovedItems(int projectID, String month);
        EProjectItemList getWatchlistItems(int projectID, String month);
        EProjectItemList getClosedItems(int projectID, String month);
        //INSERTS
        void addItem(EProjectItem item, bool approval);
        //UPDATES
        void updateProject(Project project);
        void updateItem(EProjectItem item, bool projectOwner);
        void updateNewItem(EProjectItem item);
        void updateChangedItem(EProjectItem item);

    }
}
