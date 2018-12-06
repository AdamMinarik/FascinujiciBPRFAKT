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
        ExecutionProject getExecutionProject(int projectID);
        EProjectItemList getItems(int projectID, String month, String type);
        EProjectItemList getFilterItems(int projectID, String month, String field, String fieldValue);
        EProjectItemList getRemovedItems(int projectID, String month, String type);
        EProjectItemList getWatchlistItems(int projectID, String month, String type);
        EProjectItemList getClosedItems(int projectID, String month, String type);
        ExecutionUser getExecutionUser(string userName);
        
        //INSERTS
        void addItem(EProjectItem item, bool approval, String Type, int ProjectID);
        //UPDATES
        void updateProject(Project project);
        void updateItem(EProjectItem item, bool projectOwner, String type);
        void updateNewItem(EProjectItem item);
        void updateChangedItem(EProjectItem item);

    }
}
